using System.Collections;
using System.Collections.Generic;

namespace BinksDisassembler.Disassembler.Instructions.Orbis
{
    public class SysFactory : IInstructionFactory
    {
        public IEnumerable<Opcode> GetOpcodes()
        {
            return new List<Opcode>()
            {
                new Opcode(0x2000, 16)
            };
        }

        public Instruction Create()
        {
            var instruction = new Instruction("l.sys", "K");
            instruction.AddArgument("K", 16, 16);
            return instruction;
        }
    }
}