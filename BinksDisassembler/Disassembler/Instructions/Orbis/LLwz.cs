using System.Collections;
using System.Collections.Generic;

namespace BinksDisassembler.Disassembler.Instructions.Orbis
{
    public class LLwzFactory : IInstructionFactory
    {
        public List<Rule> GetRules()
        {
            return new List<Rule>()
            {
                new Rule(0x21, 6)
            };
        }

        public Instruction CreateFromBitArray(BitArray data)
        {
            return new LLwz(data);
        }
    }

    public class LLwz : Instruction
    {
        public LLwz(BitArray data) : base(data)
        {
        }

        public LLwz(byte[] data) : base(data)
        {
        }

        public override string ToString()
        {
            return "l.lwz";
        }
    }
}