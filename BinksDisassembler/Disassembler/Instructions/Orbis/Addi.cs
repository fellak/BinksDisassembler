using System.Collections;
using System.Collections.Generic;
using BinksDisassembler.Disassembler.Instructions.ArgumentStrategies;

namespace BinksDisassembler.Disassembler.Instructions.Orbis
{
    public class AddiFactory : IInstructionFactory
    {
        public List<Opcode> GetOpcodes()
        {
            return new List<Opcode>()
            {
                new Opcode(0x27, 6)
            };
        }

        public Instruction Create(uint position, BitArray data)
        {
            var instruction = new Instruction("l.addi", "D,A,I");
            instruction.AddArgument("D", 5, 6, new RStrategy());
            instruction.AddArgument("A", 5, 11, new RStrategy());
            instruction.AddArgument("I", 16, 16, new SignExtensionStrategy());
            return instruction;
        }
    }
}