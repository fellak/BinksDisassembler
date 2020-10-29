using System.Collections;
using System.Collections.Generic;
using BinksDisassembler.Tools;

namespace BinksDisassembler.Disassembler.Instructions.Orbis
{
    public class LMsyncFactory : IInstructionFactory
    {
        public List<Rule> GetRules()
        {
            return new List<Rule>()
            {
                new Rule(BitArrayFactory.FromUnsignedInt(0x22000000, 32))
            };
        }

        public Instruction CreateFromBytes(byte[] data)
        {
            return new LMsync(data);
        }

        public Instruction CreateFromBitArray(BitArray data)
        {
            return new LMsync(data);
        }
    }
    
    public class LMsync : Instruction
    {
        public LMsync(BitArray data) : base(data)
        {
        }

        public LMsync(byte[] data) : base(data)
        {
        }

        public override string ToString()
        {
            return "l.msync";
        }
    }
}