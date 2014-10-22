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
    public class DirectMapCache : CacheIF
    {
        private Memory mainMem;

        private uint blockSize;

        private uint cacheSize;

        private List<CacheLine> cache;

        bool cacheWasHit=false;

        bool cacheWasMissed=false;

        public DirectMapCache(int memorySize, uint blockSize, uint cacheSize)
        {
            this.mainMem = new Memory(memorySize);
            this.blockSize = blockSize;
            this.cacheSize = cacheSize;
            this.cache = new List<CacheLine>();
            for (uint i = 0; i < cacheSize; ++i)
            {
                cache.Add(new CacheLine());
            }
        }

        private CacheLine fetchLine(uint addr)
        {
            uint baseAddr = blockSize * (addr / blockSize);
            CacheLine retVal = new CacheLine(baseAddr, blockSize);
            for (uint i=0;i<blockSize;++i) {
                retVal.pokeEntry(i+baseAddr,mainMem.getAddr(i+baseAddr));
            }
            return retVal;
        }

        private void writeLine(int cacheLineIx)
        {
            for (uint i = 0; i < blockSize; ++i)
            {
                mainMem.setAddr(cache[cacheLineIx].baseAddr + i,cache[cacheLineIx].getEntry(i));
                cache[cacheLineIx].isDirty = false;
            }
        }

        private CacheLine loadLine(uint addr)
        {
            int cacheLineIx = (int)((addr / blockSize) % cacheSize);
            CacheLine newLine = fetchLine(addr);
            if (cache[cacheLineIx].isDirty)
            {
                writeLine(cacheLineIx);
            }
            cache[cacheLineIx] = newLine;
            return newLine;
        }

        public ushort getAddr(uint addr)
        {
            int cacheLineIx = (int)((addr / blockSize) % cacheSize);

            if (cache[cacheLineIx].hasAddr(addr))
            {
                cacheWasHit = true;
                return cache[cacheLineIx].getEntry(addr);
            }
            else
            {
                cacheWasMissed = true;
                return loadLine(addr).getEntry(addr);
            }
        }

        public ushort peek(uint addr)
        {
            int cacheLineIx = (int)((addr / blockSize) % cacheSize);

            if (cache[cacheLineIx].hasAddr(addr))
            {
                return cache[cacheLineIx].getEntry(addr);
            }
            else
            {
                return mainMem.getAddr(addr);
            }
        }

        public void setAddr(uint addr, ushort val)
        {
            int cacheLineIx = (int)((addr / blockSize) % cacheSize);

            if (cache[cacheLineIx].hasAddr(addr))
            {
                cacheWasHit = true;
                cache[cacheLineIx].setEntry(addr,val);
            }
            else
            {
                cacheWasMissed = true;
                loadLine(addr);
                cache[cacheLineIx].setEntry(addr, val);
            }
        }

        public int size()
        {
            return mainMem.size();
        }

        public bool hitCache()
        {
            return cacheWasHit;
        }

        public bool missedCache()
        {
            return cacheWasMissed;
        }

        public void clearHitMissFlags()
        {
            cacheWasHit = false;
            cacheWasMissed = false;
        }
    }
}
