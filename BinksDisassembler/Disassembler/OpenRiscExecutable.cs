using System;
using System.Collections;
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
            _instructionSet = new Resolver();

            // Build instruction mapping from instruction rule factories
            foreach (var factory in typeof(IInstructionFactory).GetImplementingTypes())
            {
                var inst = (IInstructionFactory) Activator.CreateInstance(factory);
                var rules = inst.GetRules();
                _instructionSet.Add(new Queue<Rule>(rules), inst);
            }
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
                )
                
            };

            return instructions;
        }

        public List<Instruction> Disassemble()
        {
            var instructions = new List<Instruction>();
            var sectionsToLoad = _elf.GetSections<ProgBitsSection<uint>>()
                .Where(x => x.LoadAddress != 0); 
            
            foreach (var s in sectionsToLoad)
            {
                Console.WriteLine(s.Name);
                var stream = new MemoryStream(s.GetContents());
                var reader = new SimpleEndianessAwareReader(stream, _elf.Endianess);
                uint position = 0;

                while (position < s.Size)
                {
                    var chunk = reader.ReadBytes(InstructionSize);
                    instructions.Add(new Unknown(chunk));
                    position += InstructionSize;
                }
                
                Console.WriteLine();
                Console.WriteLine();
            }

            return instructions;
        }
    }
}