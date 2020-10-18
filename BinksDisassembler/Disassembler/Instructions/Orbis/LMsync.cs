using System.Collections;
using System.Collections.Generic;
using BinksDisassembler.Tools;

namespace BinksDisassembler.Disassembler.Instructions.Orbis
{
    public class LMsync : Instruction
    {
        private class RuleFactory : InstructionRuleFactory
        {
            public override List<Rule> Rules { get; } = new List<Rule>()
            {
                new Rule(BitArrayFactory.FromUnsignedInt(0x22000000, 32))
            };
        }

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