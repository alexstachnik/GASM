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
        private BranchPredict branchTable;
        public Registers registers { get; private set; }

        public delegate void CPUCycleFinishedHandler(object sender, EventArgs args);

        public event CPUCycleFinishedHandler onFinishedCycle;

        private InstructionFetch IFStage;
        private InstructionDecode IDStage;
        private ExecuteInstruction EXStage;
        private WriteBack WBStage;

        private Thread PCUpdateThread;

        private AutoResetEvent readyToStep = new AutoResetEvent(true);

        private void setUpThreads()
        {
            IFStage = new InstructionFetch(registers, branchTable, code);
            IDStage = new InstructionDecode(registers);
            EXStage = new ExecuteInstruction(registers, data);
            WBStage = new WriteBack(registers, data);
            PCUpdateThread = new Thread(new ThreadStart(PCUpdateLoop));

            IFStage.run();
            IDStage.run();
            EXStage.run();
            WBStage.run();
            PCUpdateThread.Start();
        }

        public CPU()
        {
            this.code = new Memory(1);
            this.data = new Memory(256);
            registers = new Registers();
            branchTable = new BranchPredict(1, 1);

            setUpThreads();
        }

        public CPU(CacheIF code, CPUOptions options)
        {
            this.code = code;
            this.data = options.dataMemory;
            registers = new Registers();
            branchTable = new BranchPredict(options.initTblState, code.size());

            setUpThreads();
        }

        public void tearDown()
        {
            this.registers.halt = true;
            IFStage.signal.Set();
            IFStage.thread.Join();
            IDStage.signal.Set();
            IDStage.thread.Join();
            EXStage.signal.Set();
            EXStage.thread.Join();
            WBStage.signal.Set();
            WBStage.thread.Join();

            PCUpdateThread.Join();
        }

        private uint predictLocation()
        {
            return branchTable.getBranchDest(this.registers.PC.val);
        }

        private void PCUpdate()
        {
            if (this.registers.tookBranch)
            {
                this.branchTable.tookBranch(this.registers.WBInput.val.addr,
                        (uint)this.registers.WBInput.val.val);
            }
            if (this.registers.skippedBranch)
            {
                this.branchTable.skippedBranch(this.registers.WBInput.val.addr);
            }

            if (this.registers.mispredicted)
            {
                if (this.registers.tookBranch)
                {
                    this.registers.PC.setVal((uint)this.registers.WBInput.val.val);
                }
                else
                {
                    this.registers.PC.setVal((uint)this.registers.WBInput.val.addr + 1);
                }
                this.registers.IFStallCount.setVal(2);
                this.registers.EXLongInstruction.setVal(1);
                this.registers.flushID();
                this.registers.flushWB();
            }
            else if (this.registers.probablyBranch)
            {
                this.registers.PC.setVal(predictLocation());
            }
            else
            {
                this.registers.PC.setVal(this.registers.PC.val+1);
            }

            this.registers.mispredicted = false;
            this.registers.probablyBranch = false;
            this.registers.tookBranch = false;
            this.registers.skippedBranch = false;
        }

        private void PCUpdateLoop()
        {
            while (!this.registers.halt)
            {
                this.IFStage.stageDone.WaitOne();
                this.IDStage.stageDone.WaitOne();
                this.EXStage.stageDone.WaitOne();
                this.WBStage.stageDone.WaitOne();
                fallingEdge();
                this.readyToStep.Set();
                if (onFinishedCycle != null)
                {
                    onFinishedCycle(this, EventArgs.Empty);
                }
            }
        }

        private void risingEdge()
        {
            IFStage.signal.Set();
            IDStage.signal.Set();
            EXStage.signal.Set();
            WBStage.signal.Set();
            registers.signalEdge();
        }

        private void fallingEdge()
        {
            PCUpdate();
            registers.signalEdge();
            registers.decrementStallCounts();
        }

        public void step()
        {
            if (this.registers.halt)
            {
                return;
            }

            this.readyToStep.WaitOne();

            risingEdge();

            if (this.registers.PC.val >= this.code.size())
            {
                this.registers.halt = true;
            }
        }
    }
}
