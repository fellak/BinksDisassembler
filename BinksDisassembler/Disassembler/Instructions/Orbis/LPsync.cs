using System.Collections;
using System.Collections.Generic;
using BinksDisassembler.Tools;

namespace BinksDisassembler.Disassembler.Instructions.Orbis
{
    public class LPsync : Instruction
    {
        private class RuleFactory : InstructionRuleFactory
        {
            public override List<Rule> Rules { get; } = new List<Rule>()
            {
                new Rule(BitArrayFactory.FromUnsignedInt(0x22800000, 32))
            };
        }
        
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