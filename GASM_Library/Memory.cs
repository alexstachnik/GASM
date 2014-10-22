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
    public class MemoryException : Exception
    {
        public uint addr;

        public MemoryException() { }
        public MemoryException(string msg) : base(msg) { }
        public MemoryException(string msg, Exception inner) : base(msg, inner) { }
        public MemoryException(string msg, uint addr)
        {
            this.addr = addr;
        }
    }

    public class Memory : CacheIF
    {
        private UInt16[] arr;
        bool accessed = false;

        public Memory(int size)
        {
            arr = new UInt16[size];
        }

        public UInt16 getAddr(uint addr)
        {
            if (addr > arr.Length - 1)
            {
                throw new MemoryException("Error accessing address", addr);
            }
            accessed = true;
            return arr[addr];
        }

        public void setAddr(uint addr,UInt16 val)
        {
            if (addr > arr.Length - 1)
            {
                throw new MemoryException("Error writing to address", addr);
            }
            accessed = true;
            arr[addr] = val;
        }

        public int size()
        {
            return arr.Length;
        }

        public UInt16 peek(uint addr)
        {
            if (addr > arr.Length - 1)
            {
                throw new MemoryException("Error accessing address", addr);
            }
            return arr[addr];
        }

        public bool hitCache()
        {
            return false;
        }

        public bool missedCache()
        {
            return accessed;
        }

        public void clearHitMissFlags()
        {
            accessed = false;
        }
    }
}
