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
    public class CPU
    {
        public CacheIF code;
        public CacheIF data;

        public Registers registers { get; private set; }

        public CPU()
        {
            this.code = new Memory(1);
            this.data = new Memory(256);
            registers = new Registers();
        }

        public CPU(CacheIF code,CacheIF data)
        {
            this.code = code;
            this.data = data;
            registers = new Registers();
        }

        public void reset()
        {
            this.registers = new Registers();
        }

        private void readToMDR(uint addr)
        {
            UInt16 val=this.data.getAddr(addr);
            this.registers.mdr.setVal(val);
        }

        private void PCUpdate()
        {
            if (!this.registers.willBranch) {
                this.registers.PC.setVal(this.registers.PC.val+1);
            }
            this.registers.willBranch = false;
        }

        private void instructionFetch()
        {
            this.registers.IR.setVal(this.code.getAddr(this.registers.PC.val));
        }

        private void instructionDecode()
        {
            BinInstr ins = new BinInstr((UInt16)this.registers.IR.val);
            this.registers.ACInput.setVal(ins);
        }

        private void accessMemory()
        {
            if (this.registers.ACInput.val.notImm) {
                switch(this.registers.ACInput.val.op) {
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
                        this.registers.mar.setVal((uint)this.registers.ACInput.val.val);
                        readToMDR((uint)this.registers.ACInput.val.val);
                        break;
                    default:
                        // Branch instruction
                        break;
                }
            }
            this.registers.EXInput.setVal(this.registers.ACInput.val);
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

        private void executeInstruction()
        {
            if (this.registers.EXInput.val.notImm)
            {
                this.registers.b = this.registers.mdr.val;
            }
            else
            {
                this.registers.b = (uint)this.registers.EXInput.val.val;
            }

            this.registers.a = this.registers.acc.val;
            uint result;
            switch (this.registers.EXInput.val.op)
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
                    this.registers.willBranch = true;
                    this.registers.PC.setVal(this.registers.b);
                    break;
                case BinOpCode.BE:
                    if (this.registers.CC.val == 0)
                    {
                        this.registers.willBranch = true;
                        this.registers.PC.setVal(this.registers.b);
                    }
                    break;
                case BinOpCode.BG:
                    if (this.registers.CC.val ==  1)
                    {
                        this.registers.willBranch = true;
                        this.registers.PC.setVal(this.registers.b);
                    }
                    break;
                case BinOpCode.BL:
                    if (this.registers.CC.val == 0xFFFFFFFF)
                    {
                        this.registers.willBranch = true;
                        this.registers.PC.setVal(this.registers.b);
                    }
                    break;
                case BinOpCode.DIV:
                    result = (uint)((int)this.registers.a / (int)this.registers.b);
                    this.registers.acc.setVal(result);
                    updateCC(result);
                    break;
                case BinOpCode.HLT:
                    this.registers.halt = true;
                    break;
                case BinOpCode.MUL:
                    result = (uint)((int)this.registers.a * (int)this.registers.b);
                    this.registers.acc.setVal(result);
                    updateCC(result);
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
            this.registers.WBInput.setVal(this.registers.EXInput.val);
        }

        private void writeBack()
        {
            if (this.registers.WBInput.val.op == BinOpCode.STA)
            {
                this.data.setAddr( (uint)this.registers.WBInput.val.val,
                                   (UInt16)this.registers.acc.val);
            }
        }


        // I have a sneaking suspicion that setting things up this
        // way will be helpful later
        public void step()
        {
            if (this.registers.halt)
            {
                return;
            }

            instructionFetch();
            registers.signalEdge();

            instructionDecode();
            registers.signalEdge();

            accessMemory();
            registers.signalEdge();

            executeInstruction();
            registers.signalEdge();

            writeBack();
            registers.signalEdge();

            PCUpdate();
            registers.signalEdge();

            if (this.registers.PC.val >= this.code.size())
            {
                this.registers.halt = true;
            }
        }
    }
}
