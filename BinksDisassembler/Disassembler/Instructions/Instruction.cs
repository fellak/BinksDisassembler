using System;
using System.Collections;
using System.Text;

namespace BinksDisassembler.Disassembler.Instructions
{
    public class Instruction
    {
        private BitArray _data;

        public Instruction(BitArray data)
        {
            _data = data;
        }

        public Instruction(byte[] data)
        {
            _data = new BitArray(data);
            
            this.PrintAsHex(_data);
        }

        private void PrintAsHex(BitArray bits)
        {
            StringBuilder sb = new StringBuilder(bits.Length / 4);

            for (int i = 0; i < bits.Length; i += 4) {
                int v = (bits[i] ? 8 : 0) | 
                        (bits[i + 1] ? 4 : 0) | 
                        (bits[i + 2] ? 2 : 0) | 
                        (bits[i + 3] ? 1 : 0);

                sb.Append(v.ToString("x1")); // Or "X1"
            }

            Console.Write(sb.ToString());
        }
    }
}