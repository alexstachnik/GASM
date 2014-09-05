
namespace Gasm {

  using System;
  using System.IO;
  using System.Collections.Generic;
  using System.Linq;

  public class ParserOptions {
    public bool bePermissive{get; set;}
  }

  public class ParserException : Exception {
    public ParserException() {}
    public ParserException(string msg) : base (msg) {}
    public ParserException(string msg,Exception inner) : base(msg,inner) {}
  }

  public class Parser {

    private StreamReader sr;

    private TranslationUnit fileName;

    private ParserOptions options;

    public Parser() {}

    public Parser(StreamReader mSr,
                  TranslationUnit mFileName,
                  ParserOptions mOptions) {
      sr=mSr;
      fileName=mFileName;
      options=mOptions;
    }

    private const char COMMENT_CHAR = '!';

    private const char LABEL_COLON = ':';

    private const string IMMEDIATE_STR = "#$";

    private const string ADDRESS_STR = "$";

    private void stripLine(ref string comments,
                           out string cmd,
                           string line) {
      int d=line.IndexOf(COMMENT_CHAR);
      if (d == -1) {
        cmd=line.Trim();
      } else {
        if (string.IsNullOrEmpty(comments)) {
          comments=line.Substring(d+1);
        } else {
          comments=comments+"\n"+line.Substring(d+1);
        }
        cmd=line.Substring(0,d).Trim();
      }
    }

    private bool isLabel(string cmd) {
      return cmd[cmd.Length-1] == LABEL_COLON;
    }

    private string getLabel(string cmd) {
      return cmd.Substring(0,cmd.Length-1);
    }


    private OpCode parseOpcode(out string args,
                               string cmd) {
      if (options.bePermissive) {
        cmd=cmd.ToLower();
      }
      foreach (OpCode op in Enum.GetValues(typeof(OpCode))) {
        string opStr=OpCodeMap.getStr(op);
        if (cmd.StartsWith(opStr)) {
          args=cmd.Substring(opStr.Length).Trim();
          return op;
        }
      }
      throw new ParserException("Invalid opcode");
    }

    private InstrVal parseArgs(bool expectLabel,
                               string args) {
      if (string.IsNullOrEmpty(args)) {
        return new InstrVal(0);
      }
      if (expectLabel) {
        return new InstrVal(args);
      } else {
        try {
          if (args.StartsWith(IMMEDIATE_STR)) {
            string intStr=args.Substring(IMMEDIATE_STR.Length);
            return new InstrVal(Int32.Parse(intStr));
          } else {
            if (!args.StartsWith(ADDRESS_STR)) {
              throw new ParserException("Invalid instruction argument");
            }
            string intStr=args.Substring(ADDRESS_STR.Length);
            return new InstrVal(Int32.Parse(intStr));
          }
        } catch (FormatException) {
          throw new ParserException("Invalid instruction argument - expected a number");
        } catch (OverflowException) {
          throw new ParserException("Invalid instruction argument - value too large");
        }
      }
    }

    private Instr parseOp(string comments,
                          int lineNum,
                          string cmd) {
      string args;
      OpCode op=parseOpcode(out args,cmd);
      InstrVal val=parseArgs(OpCodeMap.expectLabel(op),args);
      return new Instr {comments=comments,
                        loc=new Loc {lineNum=lineNum,
                                     tu=fileName},
                        opCode=op,
                        val=val};
    }

    private void parseStream(ref List<List<Label> > labels,
                             ref List<Instr> instrs) {
      string comments="";
      int lineNum=1;
      List<Label> curLabels=new List<Label>();
      while (sr.Peek() > -1) {
        string line=sr.ReadLine();
        string cmd;
        stripLine(ref comments,out cmd,line);
        if (string.IsNullOrEmpty(cmd)) {
          continue;
        } else if (isLabel(cmd)) {
          curLabels.Add(new Label {
              label=getLabel(cmd),
              loc=new Loc {
                lineNum=lineNum,
                tu=fileName
              }});
        } else {
          instrs.Add(parseOp(comments,lineNum,cmd));
          labels.Add(curLabels);
          curLabels=new List<Label>();
          comments="";
        }
        ++lineNum;
      }
    }

    public AsmFile parse() {
      List<List<Label> > labels = new List<List<Label> >();
      List<Instr> instrs = new List<Instr>();
      parseStream(ref labels,ref instrs);

      Dictionary<string,int> labelMap = new Dictionary<string,int>();
      for (int i=0;i<labels.Count;++i) {
        for (int j=0;j<labels[i].Count;++j) {
          labelMap[labels[i][j].label]=i;
        }
      }

      InstrVal.LookupLabel labelLookup = delegate(string label) {
        try {
          return labelMap[label];
        } catch (KeyNotFoundException) {
          throw new ParserException("Label not found");
        }
      };
      for (int i=0;i<instrs.Count;++i) {
        instrs[i].val.update(labelLookup);
      }

      return new AsmFile{instrs=instrs};
    }

  }

}