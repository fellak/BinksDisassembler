using System.Collections;
using BinksDisassembler.Tools;

namespace BinksDisassembler.Disassembler.Instructions
{
    public interface IFormatStrategy
    {
        public string Format(uint value);
    }

    public class DefaultStrategy : IFormatStrategy
    {
        public string Format(uint value)
        {
            return $"0x{value:x8}";
        }
    }

    public class RegisterStrategy : IFormatStrategy
    {
        public string Format(uint value)
        {
            return $"r{value}";
        }
    }
    
    public class InstructionArgument
    {
        public string Name { get; }
        
        public ushort Size { get; }
        
        public ushort Offset { get; }

        public readonly IFormatStrategy Strategy;

        public InstructionArgument(string name, ushort size, ushort offset, IFormatStrategy strategy = null)
        {
            Name = name;
            Size = size;
            Offset = offset;
            Strategy = strategy ?? new DefaultStrategy();
        }

        public uint Resolve(BitArray data)
        {
            return data.CopySlice(Offset, Size).ToUnsignedInt();
        }

        public string Format(BitArray data)
        {
            return Strategy.Format(Resolve(data));
        }
    }
    
    
}