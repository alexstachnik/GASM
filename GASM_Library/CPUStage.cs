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
    abstract class CPUStage
    {
        private Registers registers;

        public AutoResetEvent stageDone { get; set; }
        public AutoResetEvent signal { get; set; }

        public Thread thread { get; set; }

        public CPUStage(Registers registers)
        {
            this.registers = registers;
            this.stageDone = new AutoResetEvent(false);
            this.signal = new AutoResetEvent(false);
        }

        public Thread run()
        {
            thread = new Thread(new ThreadStart(mainLoop));
            thread.Start();
            return thread;
        }

        protected abstract void step();

        private void mainLoop()
        {
            while (!registers.halt)
            {
                signal.WaitOne();
                step();
                stageDone.Set();
            }
        }
    }
}
