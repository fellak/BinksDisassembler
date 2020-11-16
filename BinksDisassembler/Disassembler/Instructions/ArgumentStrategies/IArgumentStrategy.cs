using System.Collections;

namespace BinksDisassembler.Disassembler.Instructions.ArgumentStrategies
{
    public interface IArgumentStrategy
    {
        public string Format(BitArray value, uint position);
    }
}