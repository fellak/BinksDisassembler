using System.Collections;

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
    }
}