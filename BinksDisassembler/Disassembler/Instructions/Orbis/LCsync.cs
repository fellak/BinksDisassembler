using System.Collections;
using System.Collections.Generic;
using BinksDisassembler.Tools;

namespace BinksDisassembler.Disassembler.Instructions.Orbis
{
    public class LCsync : Instruction
    {
        private class RuleFactory : InstructionRuleFactory
        {
            public override List<Rule> Rules { get; } = new List<Rule>()
            {
                new Rule(BitArrayFactory.FromUnsignedInt(0x23000000, 32))
            };
        }
        
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