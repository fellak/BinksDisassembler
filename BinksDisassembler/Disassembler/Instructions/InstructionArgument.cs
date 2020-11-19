using System.Collections;
using BinksDisassembler.Disassembler.Instructions.ArgumentStrategies;
using BinksDisassembler.Tools;

namespace BinksDisassembler.Disassembler.Instructions
{
    public class InstructionArgument
    {
        public string Name { get; }
        
        public ushort Size { get; }
        
        public ushort Offset { get; }

        public readonly IArgumentStrategy Strategy;

        public InstructionArgument(string name, ushort size, ushort offset, IArgumentStrategy strategy = null)
        {
            Name = name;
            Size = size;
            Offset = offset;
            Strategy = strategy ?? new DefaultStrategy();
        }

        public string Format(BitArray data, uint position)
        {
            return Strategy.Format(data.CopySlice(Offset, Size), position);
        }
    }
}