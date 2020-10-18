using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BinksDisassembler.Disassembler.Instructions;
using ELFSharp.ELF;
using ELFSharp.ELF.Sections;
using ELFSharp.Utilities;

namespace BinksDisassembler.Disassembler
{
    public class OpenRiscExecutable
    {
        private const int InstructionSize = 4;
        private readonly IELF _elf; 
        
        public OpenRiscExecutable(IELF elf)
        {
            _elf = elf;
            
            // Build instruction mapping from instruction rule factories
            var factories = typeof(InstructionRuleFactory).Assembly.GetTypes().Where(
                t => t.BaseType == typeof(InstructionRuleFactory)
                );

            foreach (var factory in factories)
            {
                var instance = new TaskFactory();
                Console.WriteLine();
            }
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