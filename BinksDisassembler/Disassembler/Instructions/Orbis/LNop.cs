using System.Collections;
using System.Collections.Generic;
using BinksDisassembler.Tools;

namespace BinksDisassembler.Disassembler.Instructions.Orbis
{
    public class LNopFactory : IInstructionFactory
    {
        public List<Rule> GetRules()
        {
            return new List<Rule>()
            {
                new Rule(BitArrayFactory.FromUnsignedInt(0x15, 8))
            };
        }

        public Instruction CreateFromBitArray(BitArray data)
        {
            return new LNop(data);
        }
    }

    public class LNop : Instruction
    {
        public LNop(BitArray data) : base(data)
        {
        }

        public LNop(byte[] data) : base(data)
        {
        }

        public override string ToString()
        {
            return "l.nop";
        }
    }
}