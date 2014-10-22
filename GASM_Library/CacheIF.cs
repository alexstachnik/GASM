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
    public interface CacheIF
    {
        UInt16 getAddr(uint addr);

        UInt16 peek(uint addr);

        void setAddr(uint addr, UInt16 val);

        int size();

        bool hitCache();

        bool missedCache();

        void clearHitMissFlags();
    }
}
