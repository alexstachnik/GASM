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
    class CacheLine
    {
        private UInt16[] arr;
        public uint baseAddr { get; private set; }
        public bool isDirty { get; set; }
        private uint blockSize;
        public bool isCold { get; private set; }

        public CacheLine()
        {
            isCold = true;
        }

        public CacheLine(uint baseAddr, uint blockSize)
        {
            this.arr = new UInt16[blockSize];
            this.baseAddr = baseAddr;
            this.isDirty = false;
            this.blockSize = blockSize;
        }

        public UInt16 getEntry(uint addr)
        {
            return arr[addr % arr.Length];
        }

        public void pokeEntry(uint addr, UInt16 val)
        {
            arr[addr % arr.Length] = val;
        }

        public void setEntry(uint addr, UInt16 val)
        {
            arr[addr % arr.Length] = val;
            isDirty = true;
        }

        public bool hasAddr(uint addr)
        {
            if (isCold)
            {
                return false;
            }
            return baseAddr == blockSize * (addr / blockSize);
        }
    }
}
