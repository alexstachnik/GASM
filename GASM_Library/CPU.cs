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
        private Memory code;
        private Memory data=new Memory(256);

        public Registers registers { get; private set; }

        public CPU()
        {
            this.code = new Memory(1);
            registers = new Registers();
        }

        public CPU(Memory code)
        {
            this.code = code;
            registers = new Registers();
        }

        private void readToMDR()
        {
            UInt16 retVal = this.data.getAddr(this.registers.mar.val);
            this.registers.mdr.setVal(retVal);
        }

        private void setFromMDR()
        {
            this.code.setAddr(this.registers.mar.val,(UInt16)this.registers.mdr.val);
        }

        private void PCUpdate()
        {
            if (this.registers.bubbleID) {
                this.registers.IR.setVal(0);
            }
            if (this.registers.flush) {
                this.registers.ACInput.setVal(BinInstr.makeNOOP());
                this.registers.EXInput.setVal(BinInstr.makeNOOP());
            }

            if (this.registers.branchACC) {
                this.registers.PC.setVal(this.registers.acc.val);
            } else if (this.registers.branchPredict) {
                this.registers.PC.setVal((uint)this.registers.ACInput.val.val);
            } else {
                this.registers.PC.setVal(this.registers.PC.val+1);
            }

            this.registers.bubbleID = false;
            this.registers.flush = false;
            this.registers.branchACC = false;
            this.registers.branchPredict = false;
        }

        private void instructionFetch()
        {
            this.registers.IR.setVal(this.code.getAddr(this.registers.PC.val));
        }

        private bool branchPredict(BinInstr ins) {
            if (ins.op == BinOpCode.BA ||
                ins.op == BinOpCode.BE ||
                ins.op == BinOpCode.BG ||
                ins.op == BinOpCode.BL) {
                return true;
            } else {
                return false;
            }
        }

        private void instructionDecode()
        {
            BinInstr ins = new BinInstr((UInt16)this.registers.IR.val);
            this.registers.ACInput.setVal(ins);
            if (branchPredict(ins)) {
                this.registers.bubbleID = true;
                this.registers.branchPredict = true;
            }
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
                        readToMDR();//FIXME
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
                    break;
                case BinOpCode.BE:
                    if (this.registers.CC.val != 0)
                    {
                        this.registers.flush = true;
                        this.registers.branchACC = true;
                    }
                    break;
                case BinOpCode.BG:
                    if (this.registers.CC.val <= 0)
                    {
                        this.registers.flush = true;
                        this.registers.branchACC = true;
                    }
                    break;
                case BinOpCode.BL:
                    if (this.registers.CC.val >= 0)
                    {
                        this.registers.flush = true;
                        this.registers.branchACC = true;
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
        }

        private void writeBack()
        {
            if (this.registers.WBInput.val.op == BinOpCode.STA)
            {

            }
        }

        public void step()
        {
            instructionFetch();
            instructionDecode();
            accessMemory();
            executeInstruction();
            writeBack();

            registers.signalEdge();

            PCUpdate();

            registers.signalEdge();
        }
    }
}
