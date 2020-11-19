using System.Collections;
using System.Collections.Generic;

namespace BinksDisassembler.Disassembler.Instructions.Orbis
{
    public class MsyncFactory : IInstructionFactory
    {
        public IEnumerable<Opcode> GetOpcodes()
        {
            return new List<Opcode>()
            {
                new Opcode(0x22000000, 32)
            };
        }

        public Instruction Create()
        {
            var instruction = new Instruction("l.msync");
            return instruction;
        }
    }
}