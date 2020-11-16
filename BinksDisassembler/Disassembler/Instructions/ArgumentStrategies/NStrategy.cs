using System.Collections;
using BinksDisassembler.Tools;

namespace BinksDisassembler.Disassembler.Instructions.ArgumentStrategies
{
    public class NStrategy : IArgumentStrategy
    {
        public string Format(BitArray value, uint position)
        {
            var result = (value.ToUnsignedInt() << 2) + position;
            return $"0x{result:x8}";
        }
    }
}