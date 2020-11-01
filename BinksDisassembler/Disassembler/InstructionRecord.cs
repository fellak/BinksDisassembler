using BinksDisassembler.Disassembler.Instructions;

namespace BinksDisassembler.Disassembler
{
    public class InstructionRecord
    {
        public readonly string Section;
        public readonly uint Address;
        public readonly Instruction Instruction;

        public InstructionRecord(string section, uint address, Instruction instruction)
        {
            Section = section;
            Address = address;
            Instruction = instruction;
        }
    }
}