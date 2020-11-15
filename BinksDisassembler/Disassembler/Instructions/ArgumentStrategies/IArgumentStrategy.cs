namespace BinksDisassembler.Disassembler.Instructions.ArgumentStrategies
{
    public interface IArgumentStrategy
    {
        public string Format(uint value, uint position);
    }
}