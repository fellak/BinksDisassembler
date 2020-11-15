using System.Collections;
using BinksDisassembler.Tools;

namespace BinksDisassembler.Disassembler.Instructions
{
    public class InstructionArgument
    {
        public string Name { get; }
        
        public ushort Size { get; }
        
        public ushort Offset { get; }

        public InstructionArgument(string name, ushort size, ushort offset)
        {
            Name = name;
            Size = size;
            Offset = offset;
        }

        public uint Resolve(BitArray data)
        {
            return data.CopySlice(Offset, Size).ToUnsignedInt();
        }
    }
    
    
}