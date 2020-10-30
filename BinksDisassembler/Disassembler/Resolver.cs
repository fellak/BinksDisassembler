using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BinksDisassembler.Disassembler.Instructions;
using BinksDisassembler.Tools;
using ObjCRuntime;

using OppcodeMapping = System.Collections.Generic.Dictionary<uint, BinksDisassembler.Disassembler.Resolver>;

namespace BinksDisassembler.Disassembler
{
    public class Resolver
    {
        private readonly SortedDictionary<uint, OppcodeMapping> _resolvers 
                = new SortedDictionary<uint, OppcodeMapping>(new DescendingComparer<uint>())
            ; 
        private IInstructionFactory _instructionFactory;
        private ushort? _offset;

        public void Add(Queue<Rule> rules, IInstructionFactory factory)
        {
            if (rules.Any())
            {
                var rule = rules.Dequeue();

                if (_offset == null)
                {
                    _offset = rule.Offset;
                }
                else if (_offset != rule.Offset)
                {
                    throw new RuntimeException("Rule offset is not matching in resolver! Na picu :(");
                }

                if (!_resolvers.ContainsKey((uint) rule.Opcode.Length))
                {
                    _resolvers[(uint) rule.Opcode.Length] = new Dictionary<uint, Resolver>();
                }

                if (!_resolvers[(uint) rule.Opcode.Length].ContainsKey(rule.Opcode.ToUnsignedInt()))
                {
                    _resolvers[(uint) rule.Opcode.Length][rule.Opcode.ToUnsignedInt()] = new Resolver();
                }
                
                _resolvers[(uint) rule.Opcode.Length][rule.Opcode.ToUnsignedInt()].Add(rules, factory);

            }
            else
            {
                _instructionFactory = factory;
            }
        }

        public Instruction Resolve(BitArray rawInstruction)
        {
            if (_instructionFactory != null)
            {
                return _instructionFactory.CreateFromBitArray(rawInstruction);
            }

            if (_offset == null)
            {
                throw new RuntimeException("Inconsistent resolver :(");
            }

            foreach (var resolverConfig in _resolvers)
            {
                var sample = rawInstruction.CopySlice((int) _offset, (int) resolverConfig.Key);

                if (resolverConfig.Value.TryGetValue(sample.ToUnsignedInt(), out var resolver))
                {
                    var result = resolver.Resolve(rawInstruction);
                    
                    if (result != null)
                        return result;
                }
            }

            return null;
        }
    }
}