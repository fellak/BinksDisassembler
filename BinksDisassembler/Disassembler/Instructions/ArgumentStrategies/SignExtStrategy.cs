using System;
using System.Collections;
using BinksDisassembler.Tools;

namespace BinksDisassembler.Disassembler.Instructions.ArgumentStrategies
{
    public class SignExtStrategy : IArgumentStrategy
    {
        public string Format(BitArray value, uint position)
        {
            var result = new BitArray(value);
            result.Not();

            var numericResult = (int) -(result.ToUnsignedInt() + 1);
            return numericResult.ToString();
        }
    }
}