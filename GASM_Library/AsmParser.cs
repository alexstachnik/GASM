/**
 * Alexander Stachnik
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GASM_Library
{
    public class ParserOptions
    {
        public bool bePermissive { get; set; }
    }

    public static class DefaultParserOptions
    {
        public static ParserOptions options = new ParserOptions { bePermissive = true };
    }

    public class ParserException : Exception
    {
        private Location line;

        public bool hasLoc {get;private set;}

        public ParserException() {
            hasLoc = false;
        }
        public ParserException(string msg) : base(msg) {
            hasLoc = false;
        }
        public ParserException(string msg, Exception inner) : base(msg, inner) {
            hasLoc = false;
        }
        public ParserException(string msg, Location loc) : base(msg) {
            line = loc;
            hasLoc = true;
        }

        public Location loc
        {
            get {
                if (hasLoc) return line;
                else return new Location();
            }
        }
    }

    public class AsmParser
    {

        private StreamReader sr;

        private TranslationUnit fileName;

        private ParserOptions options;

        public AsmParser() { }

        public AsmParser(StreamReader mSr,
                         TranslationUnit mFileName,
                         ParserOptions mOptions)
        {
            sr = mSr;
            fileName = mFileName;
            options = mOptions;
        }

        public static Regex LINE_REGEX = new Regex(@"\s*(?<body>[^!]*)\s*(?:!(?<comment>.*))?");
        public static Regex LABEL_REGEX = new Regex(@"(?<label>[^:]*)(?<!\s)\s*:");
        public static Regex INSTR_REGEX = new Regex(@"(?<instr>[a-zA-Z]*)\s+(?:(?<flag>\#\$|\$)(?<numeric>[0-9]+)|(?<label>.*))");

        private AsmOpCode parseOpcode(string str)
        {
            if (options.bePermissive)
            {
                str = str.ToLower();
            }
            foreach (AsmOpCode op in Enum.GetValues(typeof(AsmOpCode)))
            {
                string opStr = OpCodeMap.getStr(op);
                if (str == OpCodeMap.getStr(op))
                {
                    return op;
                }
            }
            throw new ParserException("Invalid opcode");
        }

        private Instr parseInstr(string cmd)
        {
            Match instrMatch = INSTR_REGEX.Match(cmd);
            AsmOpCode op = parseOpcode(instrMatch.Groups["instr"].Value);
            InstrVal val;
            if (instrMatch.Groups["flag"].Success)
            {
                try
                {
                    val = new InstrVal(Int32.Parse(instrMatch.Groups["numeric"].Value));
                }
                catch (FormatException)
                {
                    throw new ParserException("Invalid instruction argument - expected a number"); // Impossible?
                }
                catch (OverflowException)
                {
                    throw new ParserException("Invalid instruction argument - value too large");
                }
                val.isImmediate=instrMatch.Groups["flag"].Value == "#$";
            }
            else
            {
                val = new InstrVal(instrMatch.Groups["label"].Value);
            }
            return new Instr
            {
                opCode = op,
                val = val
            };
        }

        private void parseStream(ref List<List<Label>> labels,
                                 ref List<Instr> instrs)
        {
            string comments = "";
            int lineNum = 1;
            List<Label> curLabels = new List<Label>();
            while (sr.Peek() > -1)
            {
                string line = sr.ReadLine();
                Match lineMatch = LINE_REGEX.Match(line);
                string body = lineMatch.Groups["body"].Value;
                if (lineMatch.Groups["comment"].Success)
                {
                    comments += lineMatch.Groups["comment"].Value;
                }

                if (string.IsNullOrEmpty(body))
                {
                    continue;
                }

                Location loc = new Location {
                    lineNum = lineNum,
                    tu = this.fileName
                };

                Match labelMatch = LABEL_REGEX.Match(body);
                if (labelMatch.Success)
                {
                    curLabels.Add(new Label
                    {
                        label = labelMatch.Groups["label"].Value,
                        loc = loc
                    });
                } else {
                    Instr instr = parseInstr(body);
                    instr.comments = comments;
                    instr.loc = loc;
                    instrs.Add(instr);
                    labels.Add(curLabels);
                    curLabels = new List<Label>();
                    comments = "";
                }
                ++lineNum;
            }
        }

        public Source parse()
        {
            List<List<Label>> labels = new List<List<Label>>();
            List<Instr> instrs = new List<Instr>();
            parseStream(ref labels, ref instrs);

            Dictionary<string, int> labelMap = new Dictionary<string, int>();
            for (int i = 0; i < labels.Count; ++i)
            {
                for (int j = 0; j < labels[i].Count; ++j)
                {
                    labelMap[labels[i][j].label] = i;
                }
            }

            InstrVal.LookupLabel labelLookup = delegate(string label)
            {
                try
                {
                    return labelMap[label];
                }
                catch (KeyNotFoundException)
                {
                    throw new ParserException("Label not found");
                }
            };
            for (int i = 0; i < instrs.Count; ++i)
            {
                instrs[i].val.update(labelLookup);
            }

            return new Source { instrs = instrs };
        }

    }

}
