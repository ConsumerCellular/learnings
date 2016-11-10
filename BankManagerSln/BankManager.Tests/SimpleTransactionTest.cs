using NUnit.Framework;

namespace BankManager.Tests
{
    [TestFixture]
    public class SimpleTransactionTest : TransactionTests
    {
        public override Transaction GetTransactionWith(int baseAmount)
        {
            return new SimpleTransaction(baseAmount);
        }

        [SetUp]
        public void Setup()
        {
            base.Setup();
        }
        [Test]
        public void CalculateTotalTransaction_AmountProvided_ReturnsSameAmount()
        {
            const int baseAmount = 100;
            var simpleTransaction = new SimpleTransaction(baseAmount);

            var totalTransaction = simpleTransaction.CalculateTotalTransaction();

            Assert.That(totalTransaction, Is.EqualTo(baseAmount), "Calculated transaction should equal the base amount");
        }
    }
}
