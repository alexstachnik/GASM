/**
 * Alexander Stachnik
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GASM_Library
{
    class ExecuteInstruction : CPUStage
    {
        Registers registers;
        CacheIF data;

        public ExecuteInstruction(Registers registers,
            CacheIF data) : base(registers)
        {
            this.registers = registers;
            this.data = data;
        }

        private void readToMDR(uint addr)
        {
            UInt16 val = this.data.getAddr(addr);
            this.registers.mdr.setVal(val);
        }

        private void accessMemory(DecodedInput EXInput)
        {
            if (EXInput.notImm)
            {
                switch (EXInput.op)
                {
                    case BinOpCode.ADD:
                        goto case BinOpCode.LDA;
                    case BinOpCode.SUB:
                        goto case BinOpCode.LDA;
                    case BinOpCode.MUL:
                        goto case BinOpCode.LDA;
                    case BinOpCode.DIV:
                        goto case BinOpCode.LDA;
                    case BinOpCode.AND:
                        goto case BinOpCode.LDA;
                    case BinOpCode.OR:
                        goto case BinOpCode.LDA;
                    case BinOpCode.LDA:
                        this.registers.mar.setVal((uint)EXInput.val);
                        readToMDR((uint)EXInput.val);
                        break;
                    default:
                        break;
                }
            }
        }

        private void updateCC(uint acc)
        {
            if ((int)acc > 0)
            {
                this.registers.CC.setVal(1);
            }
            else if (acc == 0)
            {
                this.registers.CC.setVal(0);
            }
            else
            {
                this.registers.CC.setVal(0xFFFFFFFF);
            }
        }

        private void branch(DecodedInput EXInput)
        {
            this.registers.mispredicted = !EXInput.predictedBranch;
            this.registers.tookBranch = true;
        }

        private void noBranch(DecodedInput EXInput)
        {
            this.registers.skippedBranch = true;
            this.registers.mispredicted = EXInput.predictedBranch;
        }

        protected override void step()
        {
            DecodedInput EXInput = this.registers.EXInput.val;
            if (this.registers.EXStallCount.val > 1)
            {
                return;
            }

            if (this.registers.EXLongInstruction.val > 1)
            {
                EXInput = this.registers.LastEXInput;
                this.registers.EXLongInstruction.setVal(this.registers.EXLongInstruction.val - 1);
            }

            accessMemory(EXInput);

            if (EXInput.notImm)
            {
                this.registers.b = this.registers.mdr.val;
            }
            else
            {
                this.registers.b = (uint)EXInput.val;
            }

            this.registers.a = this.registers.acc.val;
            uint result;
            DecodedInput WBInput = EXInput;
            switch (EXInput.op)
            {
                case BinOpCode.LDA:
                    this.registers.a = Registers.zero;
                    goto case BinOpCode.ADD;
                case BinOpCode.ADD:
                    result = this.registers.a + this.registers.b;
                    this.registers.acc.setVal(result);
                    updateCC(result);
                    break;
                case BinOpCode.AND:
                    result = this.registers.a & this.registers.b;
                    this.registers.acc.setVal(result);
                    updateCC(result);
                    break;
                case BinOpCode.BA:
                    branch(EXInput);
                    break;
                case BinOpCode.BE:
                    if (this.registers.CC.val == 0)
                    {
                        branch(EXInput);
                    }
                    else
                    {
                        noBranch(EXInput);
                    }
                    break;
                case BinOpCode.BG:
                    if (this.registers.CC.val == 1)
                    {
                        branch(EXInput);
                    }
                    else
                    {
                        noBranch(EXInput);
                    }
                    break;
                case BinOpCode.BL:
                    if (this.registers.CC.val == 0xFFFFFFFF)
                    {
                        branch(EXInput);
                    }
                    else
                    {
                        noBranch(EXInput);
                    }
                    break;
                case BinOpCode.DIV:
                    result = (uint)((int)this.registers.a / (int)this.registers.b);
                    this.registers.acc.setVal(result);
                    updateCC(result);
                    this.registers.IFStallCount.setVal(5);
                    this.registers.EXStallCount.setVal(5);
                    WBInput = new DecodedInput();
                    break;
                case BinOpCode.HLT:
                    this.registers.halt = true;
                    break;
                case BinOpCode.MUL:
                    result = (uint)((int)this.registers.a * (int)this.registers.b);
                    this.registers.acc.setVal(result);
                    updateCC(result);
                    this.registers.IFStallCount.setVal(5);
                    this.registers.EXStallCount.setVal(5);
                    WBInput = new DecodedInput();
                    break;
                case BinOpCode.NOTA:
                    result = ~this.registers.a;
                    this.registers.acc.setVal(result);
                    updateCC(result);
                    break;
                case BinOpCode.OR:
                    result = this.registers.a | this.registers.b;
                    this.registers.acc.setVal(result);
                    updateCC(result);
                    break;
                case BinOpCode.SHL:
                    result = this.registers.a << (int)this.registers.b;
                    this.registers.acc.setVal(result);
                    updateCC(result);
                    break;
                case BinOpCode.STA:
                    break;
                case BinOpCode.SUB:
                    result = this.registers.a - this.registers.b;
                    this.registers.acc.setVal(result);
                    updateCC(result);
                    break;
            }
            this.registers.WBInput.setVal(WBInput);
            this.registers.LastEXInput = EXInput;
        }
    }
}
