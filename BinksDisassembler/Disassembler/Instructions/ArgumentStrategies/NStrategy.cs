namespace BinksDisassembler.Disassembler.Instructions.ArgumentStrategies
{
    public class NStrategy : IArgumentStrategy
    {
        public string Format(uint value, uint position)
        {
            var result = (value << 2) + position;
            return $"0x{result:x8}";
        }
    }
}