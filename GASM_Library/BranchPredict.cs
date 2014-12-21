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
    class BranchPredict
    {
        private List<int> instrMap;
        private List<uint> branchDests;

        public BranchPredict(int initState, int numInstrs)
        {
            if (initState < 0 || initState > 1)
            {
                throw new ArgumentOutOfRangeException("Internal Error: Bad initState val " + initState.ToString());
            }

            this.instrMap = new List<int>(numInstrs);
            this.branchDests = new List<uint>(numInstrs);
            for (int i = 0; i < numInstrs; ++i)
            {
                this.instrMap.Add(initState);
                this.branchDests.Add(0);
            }
        }

        public void tookBranch(uint pc, uint dest)
        {
            branchDests[(int)pc] = dest;
            if (instrMap[(int)pc] < 3)
            {
                instrMap[(int)pc] += 1;
            }
        }

        public void skippedBranch(uint pc)
        {
            if (instrMap[(int)pc] > 0)
            {
                instrMap[(int)pc] -= 1;
            }
        }

        public uint getBranchDest(uint pc)
        {
            return branchDests[(int)pc];
        }

        public bool willProbablyBranch(uint pc)
        {
            if (instrMap[(int)pc] > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
