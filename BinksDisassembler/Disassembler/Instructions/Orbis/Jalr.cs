using System.Collections;
using System.Collections.Generic;
using BinksDisassembler.Disassembler.Instructions.ArgumentStrategies;

namespace BinksDisassembler.Disassembler.Instructions.Orbis
{
    public class JalrFactory : IInstructionFactory
    {
        public IEnumerable<Opcode> GetOpcodes()
        {
            return new List<Opcode>()
            {
                new Opcode(0x12, 6)
            };
        }

        public Instruction Create()
        {
            var instruction = new Instruction("l.jalr", "B");
            instruction.AddArgument("B", 5, 16, new RStrategy());
            return instruction;
        }
    }
}