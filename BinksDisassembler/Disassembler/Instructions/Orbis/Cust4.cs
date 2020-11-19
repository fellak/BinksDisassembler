using System.Collections;
using System.Collections.Generic;

namespace BinksDisassembler.Disassembler.Instructions.Orbis
{
    public class Cust4 : IInstructionFactory
    {
        public IEnumerable<Opcode> GetOpcodes()
        {
            return new List<Opcode>()
            {
                new Opcode(0x1f, 6)
            };
        }

        public Instruction Create()
        {
            return new Instruction("l.cust4");
        }
    }
}