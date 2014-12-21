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
    class WriteBack : CPUStage
    {
        Registers registers;
        CacheIF data;

        public WriteBack(Registers registers, CacheIF data) : base(registers)
        {
            this.registers = registers;
            this.data = data;
        }

        protected override void step()
        {
            if (this.registers.WBStallCount.val > 0)
            {
                return;
            }

            if (this.registers.WBInput.val.op == BinOpCode.STA)
            {
                this.data.setAddr((uint)this.registers.WBInput.val.val,
                                   (UInt16)this.registers.acc.val);
            }
        }
    }
}
