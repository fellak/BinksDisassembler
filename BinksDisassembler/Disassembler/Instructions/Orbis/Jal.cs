using System.Collections;
using System.Collections.Generic;
using BinksDisassembler.Disassembler.Instructions.ArgumentStrategies;

namespace BinksDisassembler.Disassembler.Instructions.Orbis
{
    public class JalFactory : IInstructionFactory
    {
        public IEnumerable<Opcode> GetOpcodes()
        {
            return new List<Opcode>()
            {
                new Opcode(0x1, 6)
            };
        }

        public Instruction Create()
        {
            var instruction = new Instruction("l.jal", "N");
            instruction.AddArgument("N", 26, 6, new NStrategy());
            return instruction;
        }
    }
}