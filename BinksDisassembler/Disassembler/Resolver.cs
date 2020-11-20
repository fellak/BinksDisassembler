using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BinksDisassembler.Disassembler.Instructions;
using BinksDisassembler.Tools;

namespace BinksDisassembler.Disassembler
{
    public class Resolver
    {
        // [sizes][opcodes] = Resolved
        // SortedDictionary<uint, Dictionary<uint, Resolved>>
        private readonly SortedDictionary<uint, Dictionary<uint, Resolver>> _opSizes 
            = new SortedDictionary<uint, Dictionary<uint, Resolver>>(new DescendingComparer<uint>());
        private IInstructionFactory _instructionFactory;
        private ushort _offset = 0;
        
        public static Resolver CreateInstructionSet()
        {
            var result = new Resolver();
            
            // Build instruction mapping from instruction rule factories
            foreach (var factory in typeof(IInstructionFactory).GetImplementingTypes())
            {
                var inst = (IInstructionFactory) Activator.CreateInstance(factory);
                var opcodes = inst.GetOpcodes();
                result.Add(new Queue<Opcode>(opcodes), inst);
            }

            return result;
        }

        public void Add(Queue<Opcode> opcodes, IInstructionFactory factory)
        {
            if (opcodes.Any())
            {
                var opcode = opcodes.Dequeue();
                _offset = opcode.Offset;

                if (!_opSizes.ContainsKey((uint) opcode.Value.Length))
                {
                    _opSizes[(uint) opcode.Value.Length] = new Dictionary<uint, Resolver>();
                }

                if (!_opSizes[(uint) opcode.Value.Length].ContainsKey(opcode.Value.ToUnsignedInt()))
                {
                    _opSizes[(uint) opcode.Value.Length][opcode.Value.ToUnsignedInt()] = new Resolver();
                }

                _opSizes[(uint) opcode.Value.Length][opcode.Value.ToUnsignedInt()].Add(opcodes, factory);
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
                return _instructionFactory.Create();
            }

            foreach (var resolverConfig in _opSizes)
            {
                var sample = rawInstruction.CopySlice(_offset, (int) resolverConfig.Key);

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