using System.Collections;
using System.Collections.Generic;

namespace BinksDisassembler.Disassembler.Instructions.Orbis
{
    public class LMacFactory : IInstructionFactory
    {
        public List<Opcode> GetOpcodes()
        {
            return new List<Opcode>()
            {
                new Opcode(0x32, 6),
                new Opcode(0x1, 4, 28)
            };
        }

        public Instruction Create(uint position, BitArray data)
        {
            var instruction = new Instruction("l.mac", "A,B");
            instruction.AddArgument("A", 5, 11, new RegisterStrategy());
            instruction.AddArgument("B", 5, 16, new RegisterStrategy());
            instruction.Data = data;
            return instruction;
        }
    }
}