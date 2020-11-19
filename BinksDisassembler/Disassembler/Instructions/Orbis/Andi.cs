using System.Collections;
using System.Collections.Generic;
using BinksDisassembler.Disassembler.Instructions.ArgumentStrategies;

namespace BinksDisassembler.Disassembler.Instructions.Orbis
{
    public class AndiFactory : IInstructionFactory
    {
        public IEnumerable<Opcode> GetOpcodes()
        {
            return new List<Opcode>()
            {
                new Opcode(0x29, 6)
            };
        }

        public Instruction Create()
        {
            var instruction = new Instruction("l.andi", "D,A,K");
            instruction.AddArgument("D", 5, 6, new RStrategy());
            instruction.AddArgument("A", 5, 11, new RStrategy());
            instruction.AddArgument("K", 16, 16, new HexStrategy());
            return instruction;
        }
    }
}