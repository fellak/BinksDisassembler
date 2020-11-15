using System.Collections;
using System.Collections.Generic;

namespace BinksDisassembler.Disassembler.Instructions.Orbis
{
    public class LMacrcFactory : IInstructionFactory
    {
        public List<Opcode> GetOpcodes()
        {
            return new List<Opcode>()
            {
                new Opcode(0x06, 6),
                new Opcode(0x10000, 17, 15)
            };
        }

        public Instruction Create(uint position, BitArray data)
        {
            var instruction = new Instruction("l.macrc", "D");
            instruction.AddArgument("D", 5, 6);
            instruction.Data = data;
            return instruction;
        }
    }
}