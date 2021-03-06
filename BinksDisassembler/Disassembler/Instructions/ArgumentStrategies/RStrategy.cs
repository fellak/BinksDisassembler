using System.Collections;
using BinksDisassembler.Tools;

namespace BinksDisassembler.Disassembler.Instructions.ArgumentStrategies
{
    public class RStrategy : IArgumentStrategy
    {
        public string Format(BitArray value, uint position)
        {
            return $"r{value.ToUnsignedInt()}";
        }
    }
}