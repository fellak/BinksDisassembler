using System.Collections;
using BinksDisassembler.Tools;

namespace BinksDisassembler.Disassembler.Instructions.ArgumentStrategies
{
    public class DefaultStrategy : IArgumentStrategy
    {
        public string Format(BitArray value, uint position)
        {
            return value.ToUnsignedInt().ToString();
        }
    }
}