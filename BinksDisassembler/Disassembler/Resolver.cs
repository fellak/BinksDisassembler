using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BinksDisassembler.Disassembler.Instructions;
using BinksDisassembler.Tools;

using OppcodeMapping = System.Collections.Generic.Dictionary<uint, BinksDisassembler.Disassembler.Resolver>;

namespace BinksDisassembler.Disassembler
{
    public class Resolver
    {
        private readonly SortedDictionary<uint, SortedDictionary<uint, OppcodeMapping>> _offsets 
            = new SortedDictionary<uint, SortedDictionary<uint, OppcodeMapping>>(new DescendingComparer<uint>());
        private IInstructionFactory _instructionFactory;
        
        public static Resolver CreateInstructionSet()
        {
            var result = new Resolver();
            
            // Build instruction mapping from instruction rule factories
            foreach (var factory in typeof(IInstructionFactory).GetImplementingTypes())
            {
                var inst = (IInstructionFactory) Activator.CreateInstance(factory);
                var rules = inst.GetRules();
                result.Add(new Queue<Rule>(rules), inst);
            }

            return result;
        }

        public void Add(Queue<Rule> rules, IInstructionFactory factory)
        {
            if (rules.Any())
            {
                var rule = rules.Dequeue();

                if (!_offsets.ContainsKey(rule.Offset))
                {
                    _offsets[rule.Offset] = new SortedDictionary<uint, OppcodeMapping>(new DescendingComparer<uint>());
                }

                if (!_offsets[rule.Offset].ContainsKey((uint) rule.Opcode.Length))
                {
                    _offsets[rule.Offset][(uint) rule.Opcode.Length] = new Dictionary<uint, Resolver>();
                }

                if (!_offsets[rule.Offset][(uint) rule.Opcode.Length].ContainsKey(rule.Opcode.ToUnsignedInt()))
                {
                    _offsets[rule.Offset][(uint) rule.Opcode.Length][rule.Opcode.ToUnsignedInt()] = new Resolver();
                }
                
                _offsets[rule.Offset][(uint) rule.Opcode.Length][rule.Opcode.ToUnsignedInt()].Add(rules, factory);
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

            foreach (var (offset, resolvers) in _offsets)
            {
                foreach (var resolverConfig in resolvers)
                {
                    var sample = rawInstruction.CopySlice((int) offset, (int) resolverConfig.Key);

                    if (resolverConfig.Value.TryGetValue(sample.ToUnsignedInt(), out var resolver))
                    {
                        var result = resolver.Resolve(rawInstruction);
                    
                        if (result != null)
                            return result;
                    }
                }
            }

            return null;
        }
    }
}