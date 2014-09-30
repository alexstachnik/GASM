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
    public class Memory
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

        private UInt16[] arr;

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
            return arr[addr];
        }

        public void setAddr(uint addr,UInt16 val)
        {
            if (addr > arr.Length - 1)
            {
                throw new MemoryException("Error writing to address", addr);
            }
            arr[addr] = val;
        }
    }
}
