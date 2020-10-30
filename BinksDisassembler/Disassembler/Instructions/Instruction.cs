using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BinksDisassembler.Disassembler.Instructions
{
    public interface IInstructionFactory
    {
        public List<Rule> GetRules();
        public Instruction CreateFromBitArray(BitArray data);
    }

    public abstract class Instruction
    {
        protected readonly BitArray Data;

        public abstract override string ToString(); 

        public Instruction(BitArray data)
        {
            Data = data;
        }

        public Instruction(byte[] data)
        {
            Data = new BitArray(data);
            
            Console.WriteLine(ToHexString());
        }

        public string ToHexString()
        {
            var sb = new StringBuilder(Data.Length / 4);

            for (var i = 0; i < Data.Length; i += 4) {
                var v = (Data[i] ? 8 : 0) | (Data[i + 1] ? 4 : 0) | (Data[i + 2] ? 2 : 0) | (Data[i + 3] ? 1 : 0);
                sb.Append(v.ToString("x1"));
            }

            return sb.ToString();
        }
    }
}