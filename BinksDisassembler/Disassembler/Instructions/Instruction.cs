using System.Collections;
using System.Collections.Generic;
using BinksDisassembler.Disassembler.Instructions.ArgumentStrategies;
using BinksDisassembler.Tools;

namespace BinksDisassembler.Disassembler.Instructions
{
    public interface IInstructionFactory
    {
        public IEnumerable<Opcode> GetOpcodes();

        public Instruction Create();
    }

    public class Instruction
    {
        private readonly Dictionary<string, InstructionArgument> _arguments = new Dictionary<string, InstructionArgument>();
        private readonly string _formatString;
        
        public uint Position;
        public readonly string Name;
        public BitArray Data = null;

        public Instruction(string name, string formatString = "")
        {
            Name = name;
            _formatString = formatString;
        }

        public string ToHexString()
        {
            return Data != null ? Data.ToUnsignedInt().ToString("x8") : "";
        }

        public Instruction AddArgument(string name, ushort size, ushort offset = 0, IArgumentStrategy strategy = null)
        {
            _arguments[name] = new InstructionArgument(name, size, offset, strategy);
            return this;
        }
        
        public override string ToString()
        {
            if (Data == null || _formatString.Length == 0)
                return Name;

            var result = new StringFormatter($"{Name} {_formatString}");

            foreach (var argument in _arguments.Values)
            {
                result.Add(argument.Name, argument.Format(Data, Position));
            }
            
            return result.ToString();
        }
    }
}