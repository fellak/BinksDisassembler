using System.Collections;
using System.Collections.Generic;

namespace BinksDisassembler.Disassembler.Instructions.Orbis
{
    public class LMovhiFactory : IInstructionFactory
    {
        public List<Rule> GetRules()
        {
            return new List<Rule>()
            {
                new Rule(0x06, 6),
                new Rule(0x0, 1, 15)
            };
        }
    
        public Instruction CreateFromBitArray(BitArray data)
        {
            return new LMovhi(data);
        }
    }
    
    public class LMovhi : Instruction
    {
        public LMovhi(BitArray data) : base(data)
        {
        }

        public LMovhi(byte[] data) : base(data)
        {
        }

        public override string ToString()
        {
            return "l.movhi";
        }
    }
}