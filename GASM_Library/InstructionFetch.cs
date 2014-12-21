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
    class InstructionFetch : CPUStage
    {
        private Registers registers;
        private BranchPredict branchTable;
        private CacheIF code;

        public InstructionFetch(Registers registers,
            BranchPredict branchTable, CacheIF code) : base(registers)
        {
            this.registers = registers;
            this.branchTable = branchTable;
            this.code = code;
        }

        protected override void step()
        {
            if (this.registers.IFStallCount.val > 0)
            {
                return;
            }

            uint pc = this.registers.PC.val;
            bool probablyBranch = this.branchTable.willProbablyBranch(pc);

            this.registers.probablyBranch = probablyBranch;
            this.registers.IR.setVal(this.code.getAddr(pc));
            this.registers.IDInput.setVal(new RawInput(pc, probablyBranch));
        }
    }
}
