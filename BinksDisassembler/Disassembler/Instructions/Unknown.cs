using System.Collections;
using System.Collections.Generic;

namespace BinksDisassembler.Disassembler.Instructions
{
    public class Unknown : Instruction
    {
        public Unknown(BitArray data) : base(data)
        {
        }

        public Unknown(byte[] data) : base(data)
        {
        }

        public override string ToString()
        {
            return "UNKNOWN";
        }
    }
}