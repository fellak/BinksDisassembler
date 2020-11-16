using System.Collections;
using System.Collections.Generic;

namespace BinksDisassembler.Disassembler.Instructions.Orbis
{
    public class CsyncFactory : IInstructionFactory
    {
        public List<Opcode> GetOpcodes()
        {
            return new List<Opcode>()
            {
                new Opcode(0x23000000, 32)
            };
        }

        public Instruction Create(uint position, BitArray data)
        {
            return new Instruction("l.csync");
        }
    }
}