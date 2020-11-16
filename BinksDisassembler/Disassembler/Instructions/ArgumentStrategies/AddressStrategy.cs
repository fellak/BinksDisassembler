using System.Collections;
using BinksDisassembler.Tools;

namespace BinksDisassembler.Disassembler.Instructions.ArgumentStrategies
{
    public class AddressStrategy : IArgumentStrategy
    {
        public string Format(BitArray value, uint position)
        {
            return $"0x{value.ToUnsignedInt():x8}";
        }
    }
}