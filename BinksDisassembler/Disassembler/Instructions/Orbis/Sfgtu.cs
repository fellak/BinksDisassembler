using System.Collections;
using System.Collections.Generic;
using BinksDisassembler.Disassembler.Instructions.ArgumentStrategies;

namespace BinksDisassembler.Disassembler.Instructions.Orbis
{
    public class SfgtuFactory : IInstructionFactory
    {
        public List<Opcode> GetOpcodes()
        {
            return new List<Opcode>()
            {
                new Opcode(0x722, 11)
            };
        }

        public Instruction Create(uint position, BitArray data)
        {
            var instruction = new Instruction("l.sfgtu", "A,B");
            instruction.AddArgument("A", 5, 11, new RStrategy());
            instruction.AddArgument("B", 5,16, new RStrategy());
            return instruction;
        }
    }
}