using System.Collections;
using System.Collections.Generic;

namespace BinksDisassembler.Disassembler.Instructions.Orbis
{
    public class LLwzFactory : IInstructionFactory
    {
        public List<Opcode> GetOpcodes()
        {
            return new List<Opcode>()
            {
                new Opcode(0x21, 6)
            };
        }

        public Instruction Create(BitArray data)
        {
            var instruction = new Instruction("l.lwz");
            instruction.AddArgument("D", 5, 6);
            instruction.AddArgument("A", 5, 16);
            instruction.AddArgument("I", 16, 16);
            instruction.Data = data;
            return instruction;
        }
    }
}