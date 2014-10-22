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
    public class TwoWayCache : CacheIF
    {
        private Memory mainMem;

        private uint blockSize;

        private uint cacheSize;

        private uint modVal;

        private List<CacheLine> cache;

        bool cacheWasHit = false;

        bool cacheWasMissed = false;

        public TwoWayCache(int memorySize, uint blockSize, uint cacheSize)
        {
            if (cacheSize % 2 != 0)
            {
                throw new MemoryException("Cache size must be divisible by two for a two way cache");
            }

            this.mainMem = new Memory(memorySize);
            this.blockSize = blockSize;
            this.cacheSize = cacheSize;
            this.modVal = cacheSize/2;
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
            for (uint i = 0; i < blockSize; ++i)
            {
                retVal.pokeEntry(i + baseAddr, mainMem.getAddr(i + baseAddr));
            }
            return retVal;
        }

        private void writeLine(int cacheLineIx)
        {
            for (uint i = 0; i < blockSize; ++i)
            {
                mainMem.setAddr(cache[cacheLineIx].baseAddr + i, cache[cacheLineIx].getEntry(i));
                cache[cacheLineIx].isDirty = false;
            }
        }

        private CacheLine loadLine(uint addr, int cacheLineIx)
        {
            CacheLine newLine = fetchLine(addr);
            if (cache[cacheLineIx].isDirty)
            {
                writeLine(cacheLineIx);
            }
            cache[cacheLineIx] = newLine;
            return newLine;
        }

        private int getCacheIx(uint addr)
        {
            int cacheLineBaseIx = (int)((addr / blockSize) % modVal);
            if (cache[cacheLineBaseIx].hasAddr(addr))
            {
                return cacheLineBaseIx;
            }
            if (cache[cacheLineBaseIx+1].hasAddr(addr))
            {
                return cacheLineBaseIx + 1;
            }
            return -1;
        }

        private int getRandReplacement(uint addr)
        {
            int cacheLineBaseIx = (int)((addr / blockSize) % modVal);
            Random R = new Random();
            return cacheLineBaseIx + R.Next(2);
        }

        public ushort getAddr(uint addr)
        {
            int cacheLineIx = getCacheIx(addr);

            if (cacheLineIx != -1)
            {
                cacheWasHit = true;
                return cache[cacheLineIx].getEntry(addr);
            }
            else
            {
                cacheWasMissed = true;
                cacheLineIx = getRandReplacement(addr);
                return loadLine(addr,cacheLineIx).getEntry(addr);
            }
        }

        public ushort peek(uint addr)
        {
            int cacheLineIx = getCacheIx(addr);

            if (cacheLineIx != -1)
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
            int cacheLineIx = getCacheIx(addr);

            if (cacheLineIx != -1)
            {
                cacheWasHit = true;
                cache[cacheLineIx].setEntry(addr, val);
            }
            else
            {
                cacheWasMissed = true;
                cacheLineIx = getRandReplacement(addr);
                loadLine(addr,cacheLineIx);
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
