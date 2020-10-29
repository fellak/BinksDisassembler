using System.Collections;
using System.Collections.Generic;
using BinksDisassembler.Tools;

namespace BinksDisassembler.Disassembler.Instructions.Orbis
{
    public class LCsyncFactory : IInstructionFactory
    {
        public List<Rule> GetRules()
        {
            return new List<Rule>()
            {
                new Rule(BitArrayFactory.FromUnsignedInt(0x23000000, 32)),
            };
        }

        public Instruction CreateFromBytes(byte[] data)
        {
            return new LCsync(data);
        }

        public Instruction CreateFromBitArray(BitArray data)
        {
            return new LCsync(data);
        }
    }
    
    public class LCsync : Instruction
    {
        public LCsync(BitArray data) : base(data)
        {
        }

        public LCsync(byte[] data) : base(data)
        {
        }

        public override string ToString()
        {
            return "l.csync";
        }
    }
}