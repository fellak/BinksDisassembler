using System.Collections;
using System.Collections.Generic;

namespace BinksDisassembler.Disassembler.Instructions.Orbis
{
    public class LJFactory : IInstructionFactory
    {
        public List<Rule> GetRules()
        {
            return new List<Rule>()
            {
                new Rule(0x00, 6)
            };
        }

        public Instruction CreateFromBitArray(BitArray data)
        {
            return new LJ(data);
        }
    }


    public class LJ : Instruction
    {
        public LJ(BitArray data) : base(data)
        {
        }

        public LJ(byte[] data) : base(data)
        {
        }

        public override string ToString()
        {
            return "l.j";
        }
    }
}