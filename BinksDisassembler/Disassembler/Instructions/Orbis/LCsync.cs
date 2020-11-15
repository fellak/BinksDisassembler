using System.Collections;
using System.Collections.Generic;

namespace BinksDisassembler.Disassembler.Instructions.Orbis
{
    public class LCsyncFactory : IInstructionFactory
    {
        public List<Opcode> GetOpcodes()
        {
            return new List<Opcode>()
            {
                new Opcode(0x23000000, 32)
            };
        }

        public Instruction Create(BitArray data)
        {
            var result = new Instruction("l.csync");
            return result;
        }
    }
}