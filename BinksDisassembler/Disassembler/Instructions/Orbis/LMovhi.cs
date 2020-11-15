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

        public Instruction Create(uint position, BitArray data)
        {
            var instruction = new Instruction("l.movhi", "D,K")
                .AddArgument("D", 5, 6, new RegisterStrategy())
                .AddArgument("K", 16, 16)
                ;
            instruction.Data = data;
            return instruction;
        }
    }
}