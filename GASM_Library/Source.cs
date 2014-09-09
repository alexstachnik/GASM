using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GASM_Library
{
    /**
     * Label in assembly code, contains a string and a location
     */
    public class Label
    {
        public string label { get; set; }

        public Location loc { get; set; }
    }

    /**
     * Name of a TU
     */
    public class TranslationUnit
    {
        public string fileName { get; set; }
    }

    /**
     * Location in an assembly file
     */
    public class Location
    {
        public int lineNum { get; set; }

        public TranslationUnit tu { get; set; }
    }

    /**
     * Opcodes that can appear in an assembly file
     */
    public enum AsmOpCode
    { LDA, STA, ADD, SUB, MUL, DIV, AND, OR, SHL, NOTA, BA, BE, BL, BG, NOP, HLT };

    /**
     * Various static maps from AsmOpCode objects to associated properties
     */
    public static class OpCodeMap
    {
        public class OpCodeProps {
            public string str {get;set;}
            public bool expectLabel {get;set;}
        }

        private static Dictionary<AsmOpCode,OpCodeProps> map = new Dictionary<AsmOpCode,OpCodeProps>()
        {
            {AsmOpCode.LDA,new OpCodeProps {str="lda",expectLabel=false}},
            {AsmOpCode.STA,new OpCodeProps {str="sta",expectLabel=false}},
            {AsmOpCode.ADD,new OpCodeProps {str="add",expectLabel=false}},
            {AsmOpCode.SUB,new OpCodeProps {str="sub",expectLabel=false}},
            {AsmOpCode.MUL,new OpCodeProps {str="mul",expectLabel=false}},
            {AsmOpCode.DIV,new OpCodeProps {str="div",expectLabel=false}},
            {AsmOpCode.AND,new OpCodeProps {str="and",expectLabel=false}},
            {AsmOpCode.OR,new OpCodeProps {str="or",expectLabel=false}},
            {AsmOpCode.SHL,new OpCodeProps {str="shl",expectLabel=false}},
            {AsmOpCode.NOTA,new OpCodeProps {str="nota",expectLabel=false}},
            {AsmOpCode.BA,new OpCodeProps {str="ba",expectLabel=false}},
            {AsmOpCode.BE,new OpCodeProps {str="be",expectLabel=false}},
            {AsmOpCode.BL,new OpCodeProps {str="bl",expectLabel=false}},
            {AsmOpCode.BG,new OpCodeProps {str="bg",expectLabel=false}},
            {AsmOpCode.NOP,new OpCodeProps {str="nop",expectLabel=false}},
            {AsmOpCode.HLT,new OpCodeProps {str="hlt",expectLabel=false}}
        };

        public static string getStr(AsmOpCode op)
        {
            return OpCodeMap.map[op].str;
        }

        public static bool expectLabel(AsmOpCode op)
        {
            return OpCodeMap.map[op].expectLabel;
        }
    }

    /**
     * The value part of an assembly instruction
     */
    public class InstrVal
    {
        public bool isImmediate { get; set; }

        private int simpleVal;

        private string label;

        private bool isLabel;

        public InstrVal(int mSimpleVal)
        {
            simpleVal = mSimpleVal;
            isLabel = false;
        }

        public InstrVal(string mLabel)
        {
            label = mLabel;
            isLabel = true;
            isImmediate = true;
        }

        public delegate int LookupLabel(string label);

        public void update(LookupLabel map)
        {
            if (isLabel)
            {
                simpleVal = map(label);
                isLabel = false;
            }
        }

        public int getVal()
        {
            if (isLabel)
            {
                throw new System.InvalidOperationException("Error dereferencing label");
            }
            return simpleVal;
        }
    }

    /**
     * An assembly instruction
     */
    public class Instr
    {
        public string comments { get; set; }

        public Location loc { get; set; }

        public AsmOpCode opCode { get; set; }

        public InstrVal val { get; set; }
    }

    /**
     * One or more translation units consituting a single object
     */
    public class Source
    {
        public List<Instr> instrs { get; set; }
    }

}
