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

                if (!_offsets.ContainsKey(opcode.Offset))
                {
                    _offsets[opcode.Offset] = new SortedDictionary<uint, OppcodeMapping>(new DescendingComparer<uint>());
                }

                if (!_offsets[opcode.Offset].ContainsKey((uint) opcode.Value.Length))
                {
                    _offsets[opcode.Offset][(uint) opcode.Value.Length] = new Dictionary<uint, Resolver>();
                }

                if (!_offsets[opcode.Offset][(uint) opcode.Value.Length].ContainsKey(opcode.Value.ToUnsignedInt()))
                {
                    _offsets[opcode.Offset][(uint) opcode.Value.Length][opcode.Value.ToUnsignedInt()] = new Resolver();
                }
                
                _offsets[opcode.Offset][(uint) opcode.Value.Length][opcode.Value.ToUnsignedInt()].Add(opcodes, factory);
            }
            else
            {
                _instructionFactory = factory;
            }
        }

        public Instruction Resolve(uint position, BitArray rawInstruction)
        {
            if (_instructionFactory != null)
            {
                return _instructionFactory.Create(position, rawInstruction);
            }

            foreach (var (offset, resolvers) in _offsets)
            {
                foreach (var resolverConfig in resolvers)
                {
                    var sample = rawInstruction.CopySlice((int) offset, (int) resolverConfig.Key);

                    if (resolverConfig.Value.TryGetValue(sample.ToUnsignedInt(), out var resolver))
                    {
                        var result = resolver.Resolve(position, rawInstruction);
                    
                        if (result != null)
                            return result;
                    }
                }
            }

            return null;
        }
    }
}