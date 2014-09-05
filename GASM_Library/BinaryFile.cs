namespace Gasm {
  using System;
  using System.Collections.Generic;
  using System.IO;

  public class BinaryFile {
    public enum BinOpCode
    {ADD=0,LDA,STA,SUB,MUL,DIV,AND,OR,SHL,NOTA,BA,BE,BL,BG,HLT};

    public class BinaryExeReaderException : Exception {
      public BinaryExeReaderException() {}
      public BinaryExeReaderException(string msg) : base (msg) {}
      public BinaryExeReaderException(string msg,Exception inner) : base(msg,inner) {}
    }

    public static List<BinInstr> readBinary(BinaryReader br) {
      List<BinInstr> retVal=new List<BinInstr>();
      byte[] ins=new byte[2];
      try {
        while (br.PeekChar() > -1) {
          ins[0]=br.ReadByte();
          ins[1]=br.ReadByte();
          retVal.Add(new BinInstr(ins));
        }
      } catch (EndOfStreamException) {
        throw new BinaryExeReaderException("File ended in middle of instruction");
      }
      return retVal;
    }

    public static void writeBinary(AsmFile asmFile,
                                   BinaryWriter os) {
      foreach (Instr asmIns in asmFile.instrs) {
        BinInstr binIns=new BinInstr(asmIns);
        byte[] code=binIns.getInstr();
        for (int i=0;i<code.Length;++i) {
          os.Write(code[i]);
        }
      }
    }

    public class BinInstr {
      public int val{get; set;}
      public bool isImm{get; set;}
      public BinOpCode op{get;set;}

      public BinInstr(Instr asmIns) {
        this.val=asmIns.val.getVal();
        this.isImm=asmIns.val.isImmediate;
        switch(asmIns.opCode) {
        case OpCode.NOP:
          op=BinOpCode.ADD;
          this.val=0;
          this.isImm=false;
          break;
        case OpCode.ADD:
          op=BinOpCode.ADD;
          break;
        case OpCode.LDA:
          op=BinOpCode.LDA;
          break;
        case OpCode.STA:
          op=BinOpCode.STA;
          break;
        case OpCode.SUB:
          op=BinOpCode.SUB;
          break;
        case OpCode.MUL:
          op=BinOpCode.MUL;
          break;
        case OpCode.DIV:
          op=BinOpCode.DIV;
          break;
        case OpCode.AND:
          op=BinOpCode.AND;
          break;
        case OpCode.OR:
          op=BinOpCode.OR;
          break;
        case OpCode.SHL:
          op=BinOpCode.SHL;
          break;
        case OpCode.NOTA:
          op=BinOpCode.NOTA;
          break;
        case OpCode.BA:
          op=BinOpCode.BA;
          break;
        case OpCode.BE:
          op=BinOpCode.BE;
          break;
        case OpCode.BL:
          op=BinOpCode.BL;
          break;
        case OpCode.BG:
          op=BinOpCode.BG;
          break;
        case OpCode.HLT:
          op=BinOpCode.HLT;
          break;
        }
      }

      public BinInstr(Byte[] ins) {
        if (ins.Length != 2) {
          throw new ArgumentOutOfRangeException("Instructions must be of size 2");
        }
        this.op=(BinOpCode)((ins[0]&0xF0)>>4);
        if (!System.Enum.IsDefined(typeof(BinOpCode),this.op)) {
          throw new BinaryExeReaderException("Invalid opcode in file");
        }
        System.Console.WriteLine((int)ins[0]);
        this.isImm=Convert.ToBoolean((ins[0]&0x8)>>3);
        this.val=ins[1];
      }

      public Byte[] getInstr() {
        Byte[] retVal=new Byte[2];
        retVal[1]=0;
        retVal[1]|=(Byte)(Convert.ToByte(op)<<4);
        retVal[1]|=(Byte)(Convert.ToByte(isImm)<<3);
        retVal[0]=Convert.ToByte(val);
        return retVal;
      }
    }
  }
}