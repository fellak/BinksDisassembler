using System.Collections;
using System.Collections.Generic;
using System.Text;
using BinksDisassembler.Tools;

namespace BinksDisassembler.Disassembler.Instructions
{
    public interface IInstructionFactory
    {
        public List<Opcode> GetOpcodes();

        public Instruction Create(BitArray data);
    }

    public class Instruction
    {
        private Dictionary<string, InstructionArgument> _arguments = new Dictionary<string, InstructionArgument>();
        private string _formatString;

        public readonly string Name;

        public BitArray? Data;

        public Instruction(string name, string formatString = "")
        {
            Name = name;
            _formatString = formatString;
        }

        public string ToHexString()
        {
            if (Data == null)
                return "";
            
            var sb = new StringBuilder(Data.Length / 4);

            for (var i = 0; i < Data.Length; i += 4) {
                var v = (Data[i] ? 8 : 0) | (Data[i + 1] ? 4 : 0) | (Data[i + 2] ? 2 : 0) | (Data[i + 3] ? 1 : 0);
                sb.Append(v.ToString("x1"));
            }

            return sb.ToString();
        }

        public Instruction AddArgument(string name, ushort size, ushort offset = 0, RegisterStrategy registerStrategy = null)
        {
            _arguments[name] = new InstructionArgument(name, size, offset, registerStrategy);
            return this;
        }
        
        public override string ToString()
        {
            if (Data == null || _formatString.Length == 0)
                return Name;

            var result = new StringFormatter($"{Name} {_formatString}");

            foreach (var argument in _arguments.Values)
            {
                result.Add(argument.Name, argument.Format(Data));
            }
            
            return result.ToString();
        }
    }
}