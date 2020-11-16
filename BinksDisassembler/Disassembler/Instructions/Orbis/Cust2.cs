using System.Collections;
using System.Collections.Generic;

namespace BinksDisassembler.Disassembler.Instructions.Orbis
{
    public class Cust2 : IInstructionFactory
    {
        public List<Opcode> GetOpcodes()
        {
            return new List<Opcode>()
            {
                new Opcode(0x1d, 6)
            };
        }

        public Instruction Create(uint position, BitArray data)
        {
            return new Instruction("l.cust2");
        }
    }
}