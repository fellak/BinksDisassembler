using System.Collections;
using System.Collections.Generic;

namespace BinksDisassembler.Disassembler.Instructions.Orbis
{
    public class TrapFactory : IInstructionFactory
    {
        public List<Opcode> GetOpcodes()
        {
            return new List<Opcode>()
            {
                new Opcode(0x2100, 16)
            };
        }

        public Instruction Create(uint position, BitArray data)
        {
            var instruction = new Instruction("l.trap", "K");
            instruction.AddArgument("K", 16, 16);
            return instruction;
        }
    }
}