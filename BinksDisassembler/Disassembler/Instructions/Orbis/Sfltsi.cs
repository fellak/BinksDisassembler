using System.Collections;
using System.Collections.Generic;
using BinksDisassembler.Disassembler.Instructions.ArgumentStrategies;

namespace BinksDisassembler.Disassembler.Instructions.Orbis
{
    public class SfltsiFactory : IInstructionFactory
    {
        public IEnumerable<Opcode> GetOpcodes()
        {
            return new List<Opcode>()
            {
                new Opcode(0x5ec, 11)
            };
        }

        public Instruction Create()
        {
            var instruction = new Instruction("l.sfltsi", "A,I");
            instruction.AddArgument("A", 5, 11, new RStrategy());
            instruction.AddArgument("I", 16, 16);
            return instruction;
        }
    }
}