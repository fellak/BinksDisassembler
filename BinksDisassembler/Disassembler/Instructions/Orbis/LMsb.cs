using System.Collections;
using System.Collections.Generic;

namespace BinksDisassembler.Disassembler.Instructions.Orbis
{
    public class LMsbFactory : IInstructionFactory
    {
        public List<Opcode> GetOpcodes()
        {
            return new List<Opcode>()
            {
                new Opcode(0x31, 6),
                new Opcode(0x2, 4, 28)
            };
        }

        public Instruction Create(BitArray data)
        {
            var instruction = new Instruction("l.msb", "A,B");
            instruction.AddArgument("A", 5, 11);
            instruction.AddArgument("B", 5, 16);
            return instruction;
        }
    }
}