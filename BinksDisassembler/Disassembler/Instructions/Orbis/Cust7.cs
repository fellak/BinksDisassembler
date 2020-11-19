using System.Collections;
using System.Collections.Generic;

namespace BinksDisassembler.Disassembler.Instructions.Orbis
{
    public class Cust7Factory : IInstructionFactory
    {
        public IEnumerable<Opcode> GetOpcodes()
        {
            return new List<Opcode>()
            {
                new Opcode(0x3e, 6)
            };
        }

        public Instruction Create()
        {
            return new Instruction("l.cust7");
        }
    }
}