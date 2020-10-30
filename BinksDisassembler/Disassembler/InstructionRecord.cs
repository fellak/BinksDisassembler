using BinksDisassembler.Disassembler.Instructions;

namespace BinksDisassembler.Disassembler
{
    public class InstructionRecord
    {
        public readonly uint Section;
        public readonly Instruction Instruction;

        public InstructionRecord(uint section, Instruction instruction)
        {
            Section = section;
            Instruction = instruction;
        }
    }
}