using NUnit.Framework;

namespace BankManager.Tests
{
    [TestFixture]
    public abstract class TransactionTests : BaseTestClass
    {
        public abstract Transaction GetTransactionWith(int baseAmount);

        [SetUp]
        public void Setup()
        {
            base.Setup();
        }
        [Test]
        public void BaseAmount_AmountPassedToConstructor_ReturnsSameAmount()
        {
            const int nonZeroAmount = 0;
            var transaction = GetTransactionWith(nonZeroAmount);

            Assert.That(transaction.BaseAmount, Is.EqualTo(nonZeroAmount), "the base amount of a transaction should be the same as the amount passed into the constructor.");
        }
        
    }
}