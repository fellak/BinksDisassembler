using System.Collections;
using System.Collections.Generic;

namespace BinksDisassembler.Disassembler.Instructions.Orbis
{
    public class LMovhiFactory : IInstructionFactory
    {
        public List<Opcode> GetOpcodes()
        {
            return new List<Opcode>()
            {
                new Opcode(0x06, 6),
                new Opcode(0x0, 1, 15)
            };
        }

        public Instruction Create(BitArray data)
        {
            var instruction = new Instruction("l.movhi");
            return instruction;
        }
    }
}