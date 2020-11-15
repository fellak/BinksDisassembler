using System.Collections;
using BinksDisassembler.Tools;

namespace BinksDisassembler.Disassembler.Instructions
{
    public class Opcode
    {
        public BitArray Value { get; }
        
        public ushort Offset { get; }

        public Opcode(uint value, ushort size, ushort offset = 0)
        {
            Value = BitArrayFactory.FromUnsignedInt(value, size);
            Offset = offset;
        }
    }
}