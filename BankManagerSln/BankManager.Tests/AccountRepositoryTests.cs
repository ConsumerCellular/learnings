using System.Collections;
using NUnit.Framework;
using System.Linq;

namespace BankManager.Tests
{
    [TestFixture]
    class AccountRepositoryTests : BaseTestClass
    {
        private AccountRepository _accountRepository;
        [SetUp]
        public void Setup()
        {
            _accountRepository = new AccountRepository();
        }
        [Test]
        public void CheckBalance_WithNoTransactions_Returns0Balance()
        {

            var accountBalance = _accountRepository.GetBalance();

            const int expectedBalance = 0;
            Assert.That(accountBalance, Is.EqualTo(expectedBalance), "Empty Account should return a 0 balance");
        }

        [Test]
        public void ProcessTansaction_FirstTransaction_ReturnsCurrentBalanceSameAsTransaction()
        {

           var transaction = new SimpleTransaction(10);
            _accountRepository.ProcessTransactions(transaction);

            var transactions = _accountRepository.GetTransactions();
            Assert.That(transactions.Count(), Is.EqualTo(1),
                "First transaction should be stored in the transaction list.");
            Assert.That(transactions.Single(), Is.EqualTo(transaction),
                "First transaction should be the only item stored.");
        }

        public static IEnumerable Transactions
        {
            get
            {
                yield return new TestCaseData(new SimpleTransaction(10));
                yield return new TestCaseData(new SimpleTransaction(0));
                yield return new TestCaseData(new SimpleTransaction(-1));
                yield return new TestCaseData(new FeeTransaction(10,2));

            }
        }
        [TestCaseSource("Transactions")]
        public void GetBalance_WithOneTransaction_ReturnsTotalOfTransaction(Transaction transaction)
        {
            _accountRepository.ProcessTransactions(transaction);
            var totalOfTransaction = transaction.CalculateTotalTransaction();

            var currentBalance = _accountRepository.GetBalance();

            Assert.That(currentBalance, Is.EqualTo(totalOfTransaction),
                "Balance of one transaction should equal the total of that on transaction.");
        }

    }
}
