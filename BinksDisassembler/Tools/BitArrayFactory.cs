using System;
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

        public static uint ToUnsignedInt(this BitArray value)
        {
            var array = new byte[4];
            value.CopyTo(array, 0);
            return BitConverter.ToUInt32(array, 0);
        }
        
        public static uint EmptyZeros(this BitArray value)
        {
            for (var i = 0; i < value.Length; i++)
            {
                if (value[value.Length - i - 1])
                    return (uint) i;
            }

            return (uint) value.Length;
        }

        public static BitArray CopySlice(this BitArray source, int offset, int length)
        {
            var result = new BitArray(length);
            for (var i = 0; i < length; i++)
            {
                result[i] = source[offset + i];
            }
            return result;
        }

        public static string ToHex(this BitArray value)
        {
            return value.ToUnsignedInt().ToString("x8");
        }
    }
}