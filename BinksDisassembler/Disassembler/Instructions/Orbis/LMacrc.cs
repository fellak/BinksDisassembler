using System.Collections;
using System.Collections.Generic;

namespace BinksDisassembler.Disassembler.Instructions.Orbis
{
    public class LMacrcFactory : IInstructionFactory
    {
        public List<Rule> GetRules()
        {
            return new List<Rule>()
            {
                new Rule(0x06, 6),
                new Rule(0x10000, 17, 15)
            };
        }
    
        public Instruction CreateFromBitArray(BitArray data)
        {
            return new LMacrc(data);
        }
    }

    public class LMacrc : Instruction
    {
        public LMacrc(BitArray data) : base(data)
        {
        }

        public LMacrc(byte[] data) : base(data)
        {
        }

        public override string ToString()
        {
            return "l.macrc";
        }
    }
}