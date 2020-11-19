using System.Collections;
using BinksDisassembler.Tools;

namespace BinksDisassembler.Disassembler.Instructions.ArgumentStrategies
{
    public class HexStrategy : IArgumentStrategy
    {
        public string Format(BitArray value, uint position)
        {
            return $"0x{value.ToUnsignedInt():x8}";
        }
    }
}