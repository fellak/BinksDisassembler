using System.Collections;
using System.Collections.Generic;

namespace BinksDisassembler.Disassembler.Instructions.Orbis
{
    public class NopFactory : IInstructionFactory
    {
        public IEnumerable<Opcode> GetOpcodes()
        {
            return new List<Opcode>()
            {
                new Opcode(0x15, 8)
            };
        }

        public Instruction Create()
        {
            var instruction = new Instruction("l.nop", "K");
            instruction.AddArgument("K", 16, 16);
            return instruction;
        }
    }
}