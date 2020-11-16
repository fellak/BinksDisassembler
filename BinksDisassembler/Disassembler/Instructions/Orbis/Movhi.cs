using System.Collections;
using System.Collections.Generic;
using BinksDisassembler.Disassembler.Instructions.ArgumentStrategies;

namespace BinksDisassembler.Disassembler.Instructions.Orbis
{
    public class MovhiFactory : IInstructionFactory
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
                .AddArgument("D", 5, 6, new RStrategy())
                .AddArgument("K", 16, 16)
                ;
            return instruction;
        }
    }
}