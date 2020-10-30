using System.Collections;
using System.Collections.Generic;

namespace BinksDisassembler.Disassembler.Instructions.Orbis
{
    public class LMsbFactory : IInstructionFactory
    {
        public List<Rule> GetRules()
        {
            return new List<Rule>()
            {
                new Rule(0x31, 6),
                new Rule(0x2, 4, 28),
            };
        }

        public Instruction CreateFromBitArray(BitArray data)
        {
            return new LMsb(data);
        }
    }
    
    public class LMsb : Instruction
    {
        public LMsb(BitArray data) : base(data)
        {
        }

        public LMsb(byte[] data) : base(data)
        {
        }

        public override string ToString()
        {
            return $"l.msb rA,rB";
        }
    }
}