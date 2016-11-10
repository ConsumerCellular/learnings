using System;
using System.Threading;
using Moq;
using NUnit.Framework;

namespace BankManager.Tests
{
    [TestFixture]
    public class TellerTests : BaseTestClass
    {
        private Teller _teller;
        private AccountRepository _accountRepository;

        [SetUp]
        public void Setup()
        {
           _accountRepository = Mock.Of<AccountRepository>();
           _teller = new Teller(_accountRepository);
        }
        [Test]
        public void CheckBalance_RequestsTheAccountBalanceFromTheRepository()
        {
            const int nonZeroBalance = 1;
            Mock.Get(_accountRepository).Setup(x => x.GetBalance())
                .Returns(nonZeroBalance);

            var balance = _teller.CheckBalance();

            Assert.That(balance, Is.EqualTo(nonZeroBalance), "Checking the balance should return the balance retrived from the repository.");
        }

        [Test]
        public void ProcessTansaction_TransactionValuesGiven_TellerSubmitsGivenTransactionToTheRepository()
        {

            var transaction = new SimpleTransaction(10);
            var processTransactionTrigger = new ManualResetEvent(false);
            Mock.Get(_accountRepository).Setup(x => x.ProcessTransactions(transaction))
                .Callback(() => processTransactionTrigger.Set());

            _teller.ProcessTransaction(transaction);

            processTransactionTrigger.WaitOne(TimeSpan.FromSeconds(1));
            Mock.Get(_accountRepository).Verify(x => x.ProcessTransactions(transaction), Times.Once(), 
                "The teller should forward the process transaction request to the repository.");
        }
    }
}
