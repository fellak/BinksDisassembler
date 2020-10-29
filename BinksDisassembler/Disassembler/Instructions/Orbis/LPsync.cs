using System.Collections;
using System.Collections.Generic;
using BinksDisassembler.Tools;

namespace BinksDisassembler.Disassembler.Instructions.Orbis
{
    public class LPsyncFactory : IInstructionFactory
    {
        public List<Rule> GetRules()
        {
            return new List<Rule>()
            {
                new Rule(BitArrayFactory.FromUnsignedInt(0x22800000, 32))
            };
        }

        public Instruction CreateFromBytes(byte[] data)
        {
            return new LPsync(data);
        }

        public Instruction CreateFromBitArray(BitArray data)
        {
            return new LPsync(data);
        }
    }
    
    public class LPsync : Instruction
    {
        public LPsync(BitArray data) : base(data)
        {
        }

        public LPsync(byte[] data) : base(data)
        {
        }

        public override string ToString()
        {
            return "l.psync";
        }
    }
}