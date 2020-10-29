using System.Collections;
using BinksDisassembler.Tools;

namespace BinksDisassembler.Disassembler.Instructions
{
    public class Rule
    {
        public BitArray Opcode { get; }
        
        public ushort Offset { get; }
        
        public Rule(BitArray opcode, ushort offset = 0)
        {
            Opcode = opcode;
            Offset = offset;
        }

        public Rule(uint value, ushort size, ushort offset = 0)
        {
            Opcode = BitArrayFactory.FromUnsignedInt(value, size);
            Offset = offset;
        }

        public override string ToString()
        {
            return $"{Offset}: 0x{Opcode.ToHex()}";
        }
    }
}