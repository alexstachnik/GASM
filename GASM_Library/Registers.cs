/**
 * Alexander Stachnik
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GASM_Library
{
    public class RawInput
    {
        public uint addr { get; private set; }
        public bool predictedBranch { get; private set; }

        public RawInput() : this(0, false) { }

        public RawInput(uint addr, bool predictedBranch)
        {
            this.addr = addr;
            this.predictedBranch = predictedBranch;
        }
    }

    public class DecodedInput : BinInstr
    {
        public uint addr { get; private set; }
        public bool predictedBranch { get; private set; }

        public DecodedInput() : this(0, 0, false) { }

        public DecodedInput(uint addr, UInt16 ins, bool predictedBranch)
            : base(ins)
        {
            this.addr = addr;
            this.predictedBranch = predictedBranch;
        }

        public DecodedInput(UInt16 ins, RawInput lastInput)
            : base(ins)
        {
            this.addr = lastInput.addr;
            this.predictedBranch = lastInput.predictedBranch;
        }
    }

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

        public Latch<uint> IFStallCount = new Latch<uint>(0);
        public Latch<uint> IDStallCount = new Latch<uint>(0);
        public Latch<uint> EXStallCount = new Latch<uint>(0);
        public Latch<uint> WBStallCount = new Latch<uint>(0);

        public Latch<uint> EXLongInstruction = new Latch<uint>(0);

        public uint a = 0;
        public uint b = 0;

        public bool halt { get; set; }
        public bool mispredicted { get; set; }
        public bool tookBranch { get; set; }
        public bool skippedBranch { get; set; }
        public bool probablyBranch { get; set; }

        public Latch<RawInput> IDInput;
        public Latch<DecodedInput> EXInput;
        public Latch<DecodedInput> WBInput;

        public DecodedInput LastEXInput;

        public const uint zero = 0;
        public const uint one = 1;

        public Registers() {
            halt = false;
            mispredicted = false;
            tookBranch = false;
            skippedBranch = false;
            probablyBranch = false;

            IDInput = new Latch<RawInput>(new RawInput());
            EXInput = new Latch<DecodedInput>(new DecodedInput());
            WBInput = new Latch<DecodedInput>(new DecodedInput());

            LastEXInput = new DecodedInput();
        }

        public void flushID()
        {
            IR.setVal(0);
            IDInput.setVal(new RawInput());
        }

        public void flushEX()
        {
            EXInput.setVal(new DecodedInput());
        }

        public void flushWB()
        {
            WBInput.setVal(new DecodedInput());
        }

        public void signalEdge()
        {
            PC.updateVal();
            IR.updateVal();
            CC.updateVal();
            acc.updateVal();
            mar.updateVal();
            mdr.updateVal();

            IFStallCount.updateVal();
            IDStallCount.updateVal();
            EXStallCount.updateVal();
            WBStallCount.updateVal();
            
            IDInput.updateVal();
            EXInput.updateVal();
            WBInput.updateVal();
        }

        public uint dec(uint x)
        {
            return (x <= 0) ? x : x - 1;
        }

        public void decrementStallCounts()
        {
            IFStallCount.setVal(dec(IFStallCount.val));
            IFStallCount.updateVal();

            IDStallCount.setVal(dec(IDStallCount.val));
            IDStallCount.updateVal();

            EXStallCount.setVal(dec(EXStallCount.val));
            EXStallCount.updateVal();

            WBStallCount.setVal(dec(WBStallCount.val));
            WBStallCount.updateVal();
        }
    }
}

