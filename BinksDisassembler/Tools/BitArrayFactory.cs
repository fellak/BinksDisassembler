using System.Collections;
using System.Linq;

namespace BinksDisassembler.Tools
{
    public static class BitArrayFactory
    {
        public static BitArray FromUnsignedInt(uint value, ushort size)
        {
            return new BitArray(Enumerable.Range(0, size)
                .Select(bitIndex => 1 << bitIndex)
                .Select(bitMask => (value & bitMask) == bitMask)
                .ToArray()
            );
        }
    }
}