namespace BinksDisassembler.Disassembler.Instructions.ArgumentStrategies
{
    public class DefaultStrategy : IArgumentStrategy
    {
        public string Format(uint value, uint position)
        {
            return $"0x{value:x8}";
        }
    }
}