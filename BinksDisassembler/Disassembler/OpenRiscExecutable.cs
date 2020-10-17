using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using BinksDisassembler.Disassembler.Instructions;
using ELFSharp.ELF;
using ELFSharp.ELF.Sections;
using ELFSharp.Utilities;

namespace BinksDisassembler.Disassembler
{
    public class OpenRiscExecutable
    {
        private const int InstructionSize = 4;
        private List<Instruction> _instructions;

        public OpenRiscExecutable(IELF elf)
        {
            _instructions = new List<Instruction>();

            var sectionsToLoad = elf.GetSections<ProgBitsSection<uint>>()
                .Where(x => x.LoadAddress != 0); 
            
            foreach (var s in sectionsToLoad)
            {
                Console.WriteLine(s.Name);
                var stream = new MemoryStream(s.GetContents());
                var reader = new SimpleEndianessAwareReader(stream, elf.Endianess);
                uint position = 0;

                while (position < s.Size)
                {
                    var chunk = reader.ReadBytes(InstructionSize);
                    _instructions.Add(new Instruction(chunk));
                    position += InstructionSize;
                }
                
                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}