using System.Collections;
using System.Collections.Generic;

namespace BinksDisassembler.Disassembler.Instructions.Orbis
{
    public class Cust8Factory : IInstructionFactory
    {
        public IEnumerable<Opcode> GetOpcodes()
        {
            return new List<Opcode>()
            {
                new Opcode(0x3f, 6)
            };
        }

        public Instruction Create()
        {
            return new Instruction("l.cust8");
        }
    }
}