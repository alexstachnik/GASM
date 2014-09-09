using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GASM_Library
{
    public class Registers
    {
        public class Latch<T>
        {
            public T val { get; private set; }
            private T nextVal;

            public Latch(T initVal)
            {
                nextVal = initVal;
                val = initVal;
            }

            public void updateVal()
            {
                this.val = this.nextVal;
            }

            private System.Object nextValLock = new Object();

            public void setVal(T newVal)
            {
                lock (nextValLock)
                {
                    this.nextVal = newVal;
                }
            }
        }
        public Latch<uint> PC = new Latch<uint>(0);
        public Latch<uint> IR = new Latch<uint>(0);
        public Latch<uint> CC = new Latch<uint>(0);
        public Latch<uint> acc = new Latch<uint>(0);
        public Latch<uint> mar = new Latch<uint>(0);
        public Latch<uint> mdr = new Latch<uint>(0);
        public Latch<bool> storing = new Latch<bool>(false);

        public uint a = 0;
        public uint b = 0;

        public bool halt { get; set; }
        public bool flush { get; set; }
        public bool bubbleID {get; set;}
        public bool retry { get; set; }
        public bool branchPredict { get; set; }
        public bool branchACC { get; set; }

        public Latch<BinInstr> ACInput;
        public Latch<BinInstr> EXInput;
        public Latch<BinInstr> WBInput;

        public const uint zero = 0;
        public const uint one = 1;

        public Registers() {
            halt = false;
            flush = false;
            bubbleID = false;
            branchPredict = false;
            branchACC = false;

            ACInput = new Latch<BinInstr>(BinInstr.makeNOOP());
            EXInput = new Latch<BinInstr>(BinInstr.makeNOOP());
            WBInput = new Latch<BinInstr>(BinInstr.makeNOOP());
        }

        public void signalEdge()
        {
            PC.updateVal();
            IR.updateVal();
            CC.updateVal();
            acc.updateVal();
            mar.updateVal();
            mdr.updateVal();

            storing.updateVal();

            ACInput.updateVal();
            EXInput.updateVal();
            WBInput.updateVal();
        }
    }
}

