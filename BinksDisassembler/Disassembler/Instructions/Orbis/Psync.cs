using System.Collections;
using System.Collections.Generic;

namespace BinksDisassembler.Disassembler.Instructions.Orbis
{
    public class PsyncFactory : IInstructionFactory
    {
        public IEnumerable<Opcode> GetOpcodes()
        {
            return new List<Opcode>()
            {
                new Opcode(0x22800000, 32)
            };
        }

        public Instruction Create()
        {
            return new Instruction("l.psync");
        }
    }
}