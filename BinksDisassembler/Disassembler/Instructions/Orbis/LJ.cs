using System.Collections;
using System.Collections.Generic;

namespace BinksDisassembler.Disassembler.Instructions.Orbis
{
    public class LJFactory : IInstructionFactory
    {
        public List<Opcode> GetOpcodes()
        {
            return new List<Opcode>()
            {
                new Opcode(0x00, 6)
            };
        }

        public Instruction Create(BitArray data)
        {
            var instruction = new Instruction("l.j");
            return instruction;
        }
    }
}