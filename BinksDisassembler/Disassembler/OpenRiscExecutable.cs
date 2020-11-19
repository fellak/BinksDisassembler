using System.Collections.Generic;
using System.IO;
using System.Linq;
using BinksDisassembler.Disassembler.Instructions;
using BinksDisassembler.Tools;
using ELFSharp.ELF;
using ELFSharp.ELF.Sections;
using ELFSharp.Utilities;

namespace BinksDisassembler.Disassembler
{
    public class OpenRiscExecutable
    {
        private const int InstructionSize = 4;
        private readonly IELF _elf;
        private readonly Resolver _instructionSet;


        public OpenRiscExecutable(IELF elf)
        {
            _elf = elf;
            _instructionSet = Resolver.CreateInstructionSet();
        }
        
        public List<InstructionRecord> Disassemble()
        {
            var instructions = new List<InstructionRecord>();
            var sectionsToLoad = _elf.GetSections<ProgBitsSection<uint>>()
                .Where(x => x.Type == SectionType.ProgBits && x.Flags.HasFlag(SectionFlags.Executable));
            foreach (var s in sectionsToLoad)
            {
                var stream = new MemoryStream(s.GetContents());
                var reader = new SimpleEndianessAwareReader(stream, _elf.Endianess);
                uint position = 0;

                while (position < s.Size)
                {
                    var address = s.LoadAddress + position;
                    var chunk = BitArrayFactory.FromUnsignedInt(
                        reader.ReadUInt32(), InstructionSize * 8
                        );
                    var instruction = _instructionSet.Resolve(chunk) ?? new Instruction("UNKNOWN");
                    instruction.Position = address;
                    instruction.Data = chunk;

                    instructions.Add(
                        new InstructionRecord(s.Name, address, instruction)
                    );
                    position += InstructionSize;
                }
            }

            return instructions;
        }
    }
}