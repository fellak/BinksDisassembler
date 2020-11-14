using System;
using System.Collections;

namespace BinksDisassembler.Tools
{
    public static class BitArrayFactory
    {
        public static BitArray FromUnsignedInt(uint value, ushort size)
        {
            var result = new BitArray(size);
            var myVal = value;
            var position = 0;
            
            while (myVal != 0)
            {
                result[size - position - 1] = myVal % 2 == 1;
                myVal = myVal / 2;
                position++;
            }

            return result;
        }

        public static uint ToUnsignedInt(this BitArray value)
        {
            uint result = 0;
            uint position = 0;
            foreach (bool b in value.Reverse())
            {
                if (b)
                {
                    result += (uint) (1 << (int) position);
                }

                position++;
            }

            return result;
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
        
        public static BitArray Reverse(this BitArray input)
        {
            var result = new BitArray(input.Length);

            for (int i = 0; i < input.Length; i++)
            {
                result[input.Length - i - 1] = input[i];
            }

            return result;
        }


        public static BitArray CopySlice(this BitArray source, int offset, int length)
        {
            try
            {
                var result = new BitArray(length);
                for (var i = 0; i < length; i++)
                {
                    result[i] = source[offset + i];
                }
                return result;
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public static BitArray Append(this BitArray current, BitArray after) {
            var result = new bool[current.Count + after.Count];
            current.CopyTo(result, 0);
            after.CopyTo(result, current.Count);
            return new BitArray(result);
        }

        public static string ToHex(this BitArray value)
        {
            return value.ToUnsignedInt().ToString("x8");
        }

        public static string ToBinary(this BitArray value)
        {
            var result = "";
            foreach (bool current in value)
            {
                result += current ? "1" : "0";
            }

            return result;
        }
    }
}
