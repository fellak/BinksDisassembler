using System.Collections;
using System.Collections.Generic;

namespace BinksDisassembler.Disassembler.Instructions.Orbis
{
    public class LMacFactory : IInstructionFactory
    {
        public List<Rule> GetRules()
        {
            return new List<Rule>()
            {
                new Rule(0x32, 6),
                new Rule(0x1, 4, 28),
            };
        }

        public Instruction CreateFromBytes(byte[] data)
        {
            throw new System.NotImplementedException();
        }

        public Instruction CreateFromBitArray(BitArray data)
        {
            throw new System.NotImplementedException();
        }
    }
    
    public class LMac : Instruction
    {
        public LMac(BitArray data) : base(data)
        {
        }

        public LMac(byte[] data) : base(data)
        {
        }

        public override string ToString()
        {
            return $"l.mac rA,rB";
        }
    }
}