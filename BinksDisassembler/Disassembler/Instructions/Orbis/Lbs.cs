using System.Collections;
using System.Collections.Generic;
using BinksDisassembler.Disassembler.Instructions.ArgumentStrategies;

namespace BinksDisassembler.Disassembler.Instructions.Orbis
{
    public class LbsFactory : IInstructionFactory
    {
        public IEnumerable<Opcode> GetOpcodes()
        {
            return new List<Opcode>()
            {
                new Opcode(0x24, 6)
            };
        }

        public Instruction Create()
        {
            var instruction = new Instruction("l.lbs", "D,I(A)");
            instruction.AddArgument("D", 5, 6, new RStrategy());
            instruction.AddArgument("I", 16, 16);
            instruction.AddArgument("A", 5, 11, new RStrategy());
            return instruction;
        }
    }
}