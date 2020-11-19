using System.Collections;
using System.Collections.Generic;

namespace BinksDisassembler.Disassembler.Instructions.Orbis
{
    public class CsyncFactory : IInstructionFactory
    {
        public IEnumerable<Opcode> GetOpcodes()
        {
            return new List<Opcode>()
            {
                new Opcode(0x23000000, 32)
            };
        }

        public Instruction Create()
        {
            return new Instruction("l.csync");
        }
    }
}