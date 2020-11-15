using System.Collections;
using System.Collections.Generic;

namespace BinksDisassembler.Disassembler.Instructions.Orbis
{
    public class LNopFactory : IInstructionFactory
    {
        public List<Opcode> GetOpcodes()
        {
            return new List<Opcode>()
            {
                new Opcode(0x15, 8)
            };
        }

        public Instruction Create(BitArray data)
        {
            var instruction = new Instruction("l.nop");
            return instruction;
        }
    }
}