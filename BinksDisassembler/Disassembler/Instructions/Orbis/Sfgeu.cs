using System.Collections;
using System.Collections.Generic;
using BinksDisassembler.Disassembler.Instructions.ArgumentStrategies;

namespace BinksDisassembler.Disassembler.Instructions.Orbis
{
    public class SfgeuFactory : IInstructionFactory
    {
        public IEnumerable<Opcode> GetOpcodes()
        {
            return new List<Opcode>()
            {
                new Opcode(0x723, 11)
            };
        }

        public Instruction Create()
        {
            var instruction = new Instruction("l.sfgeu", "A,B");
            instruction.AddArgument("A", 5, 11, new RStrategy());
            instruction.AddArgument("B", 5,16, new RStrategy());
            return instruction;
        }
    }
}