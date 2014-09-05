
namespace Gasm {

  using System;
  using System.Collections.Generic;

  public class Label {
    public string label{get; set;}

    public Loc loc{get; set;}
  }

  public class TranslationUnit {
    public string fileName{get; set;}
  }

  public class Loc {
    public int lineNum{get; set;}

    public TranslationUnit tu{get; set;}
  }

  public enum OpCode
  {LDA,STA,ADD,SUB,MUL,DIV,AND,OR,SHL,NOTA,BA,BE,BL,BG,NOP,HLT};

  public class OpCodeMap {

    public static string getStr(OpCode op) {
      return op.ToString().ToLower();
    }

    public static bool expectLabel(OpCode op) {
      switch(op) {
      case OpCode.BA:
      case OpCode.BE:
      case OpCode.BL:
      case OpCode.BG:
        return true;
      default:
        return false;
      }
    }
  }

  public class InstrVal {
    public bool isImmediate{get; set;}

    private int simpleVal;

    private string label;

    private bool isLabel;

    public InstrVal(int mSimpleVal) {
      simpleVal=mSimpleVal;
      isLabel=false;
    }

    public InstrVal(string mLabel) {
      label=mLabel;
      isLabel=true;
    }

    public delegate int LookupLabel(string label);

    public void update(LookupLabel map) {
      if (isLabel) {
        simpleVal=map(label);
        isLabel=false;
      }
    }

    public int getVal() {
      if (isLabel) {
        throw new System.InvalidOperationException("Error dereferencing label");
      }
      return simpleVal;
    }
  }

  public class Instr {
    public string comments{get; set;}

    public Loc loc{get; set;}

    public OpCode opCode{get; set;}

    public InstrVal val{get; set;}
  }

  public class AsmFile {
    public List<Instr> instrs{get; set;}
  }

}
