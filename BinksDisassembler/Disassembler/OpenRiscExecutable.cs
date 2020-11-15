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

        public List<Instruction> TestResult()
        {
            var instructions = new List<Instruction>()
            {
                // l.msync
                _instructionSet.Resolve(
                    BitArrayFactory.FromUnsignedInt(0x22000000, 32)
                ), 
                
                // l.csync
                _instructionSet.Resolve(
                    BitArrayFactory.FromUnsignedInt(0x23000000, 32)
                ),
                
                // l.psync
                _instructionSet.Resolve(
                    BitArrayFactory.FromUnsignedInt(0x22800000, 32)
                ),
                
                
                // l.mac
                _instructionSet.Resolve(BitArrayFactory.FromUnsignedInt(0x31, 6)
                    .Append(
                        BitArrayFactory.FromUnsignedInt(0, 22)
                    )
                    .Append(
                        BitArrayFactory.FromUnsignedInt(0x1, 4))
                ),
                
                // l.movhi
                _instructionSet.Resolve(BitArrayFactory.FromUnsignedInt(0x06, 6)
                    .Append(
                        BitArrayFactory.FromUnsignedInt(0, 9)
                    )
                    .Append(
                        BitArrayFactory.FromUnsignedInt(0x0, 1)
                        )
                    .Append(
                        BitArrayFactory.FromUnsignedInt(0x0, 16)
                        )
                ),
                
                // l.lwz
                _instructionSet.Resolve(BitArrayFactory.FromUnsignedInt(0x21, 6)
                    .Append(
                        BitArrayFactory.FromUnsignedInt(0, 26)
                    )
                )
                
            };

            return instructions;
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
                    var chunk = BitArrayFactory.FromUnsignedInt(
                        reader.ReadUInt32(), InstructionSize * 8
                        );
                    var instruction = _instructionSet.Resolve(chunk) ?? new Instruction("UNKNOWN");
                    var address = s.LoadAddress + position;

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