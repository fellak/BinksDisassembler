using System.Collections;
using BinksDisassembler.Tools;

namespace BinksDisassembler.Disassembler.Instructions
{
    public class InstructionArgument
    {
        public string Name { get; }
        
        public ushort Size { get; }
        
        public ushort Offset { get; }

        public readonly IFormatStrategy Strategy;

        public interface IFormatStrategy
        {
            public string Format(uint value);
        }

        public class RegisterStrategy : IFormatStrategy
        {
            public string Format(uint value)
            {
                return $"r{value}";
            }
        }

        public InstructionArgument(string name, ushort size, ushort offset, IFormatStrategy strategy = null)
        {
            Name = name;
            Size = size;
            Offset = offset;
            Strategy = strategy;
        }

        public uint Resolve(BitArray data)
        {
            return data.CopySlice(Offset, Size).ToUnsignedInt();
        }

        public string Format(BitArray data)
        {
            if (Strategy == null)
            {
                return $"0x{Resolve(data):x8}";
            }

            return Strategy.Format(Resolve(data));
        }
    }
    
    
}