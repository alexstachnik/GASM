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
    class InstructionDecode : CPUStage
    {
        Registers registers;

        public InstructionDecode(Registers registers)
            : base(registers)
        {
            this.registers = registers;
        }

        protected override void step()
        {
            if (this.registers.IDStallCount.val > 0)
            {
                return;
            }

            UInt16 IR = (UInt16)this.registers.IR.val;
            DecodedInput ins = new DecodedInput(IR, this.registers.IDInput.val);
            this.registers.EXInput.setVal(ins);
        }
    }
}
