using System.Collections;
using System.Collections.Generic;
using BinksDisassembler.Disassembler.Instructions.ArgumentStrategies;

namespace BinksDisassembler.Disassembler.Instructions.Orbis
{
    public class SfgeuiFactory : IInstructionFactory
    {
        public List<Opcode> GetOpcodes()
        {
            return new List<Opcode>()
            {
                new Opcode(0x5e3, 11)
            };
        }

        public Instruction Create(uint position, BitArray data)
        {
            var instruction = new Instruction("l.sfgeui", "A,I");
            instruction.AddArgument("A", 5, 11, new RStrategy());
            instruction.AddArgument("I", 11, 16);
            return instruction;
        }
    }
}