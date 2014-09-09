using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GASM_Library
{

    public enum BinOpCode
    { ADD = 0, LDA, STA, SUB, MUL, DIV, AND, OR, SHL, NOTA, BA, BE, BL, BG, HLT };

    public class ObjectFileReaderException :Exception
    {
        public ObjectFileReaderException() { }
        public ObjectFileReaderException(string msg) : base(msg) { }
        public ObjectFileReaderException(string msg, Exception inner) : base(msg,inner) { }
    }

    public class InvalidOpcodeException : Exception
    {
        public InvalidOpcodeException() { }
        public InvalidOpcodeException(string msg) : base(msg) { }
        public InvalidOpcodeException(string msg, Exception inner) : base(msg, inner) { }
    }

    public class ObjectFile
    {
        public static void writeBinary(Source asmFile,
                                       BinaryWriter os)
        {
            foreach (Instr asmIns in asmFile.instrs)
            {
                BinInstr binIns = new BinInstr(asmIns);
                os.Write(binIns.getInstr());
            }
        }

        public static Memory readBinary(BinaryReader br)
        {
            List<UInt16> words = new List<UInt16>();
            try
            {
                while (br.PeekChar() > -1)
                {
                    words.Add(br.ReadUInt16());
                }
            }
            catch (EndOfStreamException)
            {
                throw new ObjectFileReaderException("File ended in middle of word");
            }

            Memory retVal = new Memory(words.Count);
            for (uint i = 0; i < (uint)words.Count; ++i)
            {
                retVal.setAddr(i, words[(int)i]);
            }
            return retVal;
        }

    }

    public class BinInstr
    {
        public int val { get; set; }
        public bool notImm { get; set; }
        public BinOpCode op { get; set; }

        public BinInstr(Instr asmIns)
        {
            this.val = asmIns.val.getVal();
            this.notImm = !asmIns.val.isImmediate;
            #region Big Switch Block
            switch (asmIns.opCode)
            {
                case AsmOpCode.NOP:
                    op = BinOpCode.ADD;
                    this.val = 0;
                    this.notImm = false;
                    break;
                case AsmOpCode.ADD:
                    op = BinOpCode.ADD;
                    break;
                case AsmOpCode.LDA:
                    op = BinOpCode.LDA;
                    break;
                case AsmOpCode.STA:
                    op = BinOpCode.STA;
                    break;
                case AsmOpCode.SUB:
                    op = BinOpCode.SUB;
                    break;
                case AsmOpCode.MUL:
                    op = BinOpCode.MUL;
                    break;
                case AsmOpCode.DIV:
                    op = BinOpCode.DIV;
                    break;
                case AsmOpCode.AND:
                    op = BinOpCode.AND;
                    break;
                case AsmOpCode.OR:
                    op = BinOpCode.OR;
                    break;
                case AsmOpCode.SHL:
                    op = BinOpCode.SHL;
                    break;
                case AsmOpCode.NOTA:
                    op = BinOpCode.NOTA;
                    this.notImm = false;
                    break;
                case AsmOpCode.BA:
                    op = BinOpCode.BA;
                    break;
                case AsmOpCode.BE:
                    op = BinOpCode.BE;
                    break;
                case AsmOpCode.BL:
                    op = BinOpCode.BL;
                    break;
                case AsmOpCode.BG:
                    op = BinOpCode.BG;
                    break;
                case AsmOpCode.HLT:
                    op = BinOpCode.HLT;
                    this.notImm = false;
                    break;
            }
            #endregion
        }

        public BinInstr(UInt16 ins)
        {
            this.op = (BinOpCode)((ins & 0xF000) >> 12);
            if (!System.Enum.IsDefined(typeof(BinOpCode), this.op))
            {
                throw new InvalidOpcodeException("Invalid opcode");
            }
            this.notImm = Convert.ToBoolean((ins & 0x0800) >> 11);
            this.val = ins & 0x04FF;
        }

        public UInt16 getInstr()
        {
            return (UInt16)((Convert.ToUInt16(this.op) << 12) |
                            (Convert.ToUInt16(this.notImm) << 11) |
                            (Convert.ToUInt16(this.val) & 0x4FF));
        }

        public static BinInstr makeNOOP()
        {
            return new BinInstr(0);
        }
    }

}
