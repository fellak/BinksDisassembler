using System.Collections;
using System.Collections.Generic;

namespace BinksDisassembler.Disassembler.Instructions.Orbis
{
    public class LMsyncFactory : IInstructionFactory
    {
        public List<Opcode> GetOpcodes()
        {
            return new List<Opcode>()
            {
                new Opcode(0x22000000, 32)
            };
        }

        public Instruction Create(uint position, BitArray data)
        {
            var instruction = new Instruction("l.msync");
            return instruction;
        }
    }
}