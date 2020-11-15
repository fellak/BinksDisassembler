using System.Collections;
using System.Collections.Generic;
using BinksDisassembler.Disassembler.Instructions.ArgumentStrategies;

namespace BinksDisassembler.Disassembler.Instructions.Orbis
{
    public class LLwzFactory : IInstructionFactory
    {
        public List<Opcode> GetOpcodes()
        {
            return new List<Opcode>()
            {
                new Opcode(0x21, 6)
            };
        }

        public Instruction Create(uint position, BitArray data)
        {
            var instruction = new Instruction("l.lwz", "D,I(A)");
            instruction.AddArgument("D", 5, 6, new RStrategy());
            instruction.AddArgument("A", 5, 16, new RStrategy());
            instruction.AddArgument("I", 16, 16);
            instruction.Data = data;
            return instruction;
        }
    }
}