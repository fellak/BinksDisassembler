using System.Collections;
using System.Collections.Generic;

namespace BinksDisassembler.Disassembler.Instructions.Orbis
{
    public class PsyncFactory : IInstructionFactory
    {
        public List<Opcode> GetOpcodes()
        {
            return new List<Opcode>()
            {
                new Opcode(0x22800000, 32)
            };
        }

        public Instruction Create(uint position, BitArray data)
        {
            return new Instruction("l.psync");
        }
    }
}