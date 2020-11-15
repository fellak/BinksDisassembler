namespace BinksDisassembler.Disassembler.Instructions.ArgumentStrategies
{
    public class RStrategy : IArgumentStrategy
    {
        public string Format(uint value, uint position)
        {
            return $"r{value}";
        }
    }
}