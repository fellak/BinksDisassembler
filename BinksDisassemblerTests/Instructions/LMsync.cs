using BinksDisassembler.Disassembler;
using BinksDisassembler.Disassembler.Instructions.Orbis;
using BinksDisassembler.Tools;
using NUnit.Framework;

namespace BinksDisassemblerTests.Instructions
{
    public class Tests
    {
        private Resolver _instructionSet;

        [SetUp]
        public void Setup()
        {
            _instructionSet = Resolver.CreateInstructionSet();
        }

        [Test]
        public void Test1()
        {
            Assert.IsInstanceOf(
                typeof(LMsync),
                _instructionSet.Resolve(
                    BitArrayFactory.FromUnsignedInt(0x22000000, 32)
                )
            );
        }
    }
}