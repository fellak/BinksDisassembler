using System;
using ELFSharp.ELF;

namespace BinksDisassembler.Disassembler
{
    public class OpenRiscExecutable
    {
        public OpenRiscExecutable(IELF elf)
        {
            Console.WriteLine(elf.Machine);
            foreach (var section in elf.Sections)
            {
                Console.WriteLine(section.Name);
            }
        }
    }
}