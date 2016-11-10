using System;
using System.Threading;
using System.Threading.Tasks;

namespace BankManager
{
    public class Teller
    {
        private readonly AccountRepository _accountRepository;

        public Teller(AccountRepository accountRepository)
        {
            if (accountRepository == null)
            {
                throw new ArgumentException("accountRepository");
            }
            _accountRepository = accountRepository;
        }
        public int CheckBalance()
        {
            Logging.WriteLine("Checking the user's balance");
            return _accountRepository.GetBalance();
        }

        public void ProcessTransaction(Transaction transaction)
        {
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(100);
                Logging.WriteLine("Processing a transaction of $"
                    + transaction.CalculateTotalTransaction());
                _accountRepository.ProcessTransactions(transaction);
            });
            //Logging.WriteLine("Processing a transaction of $" + transaction.CalculateTotalTransaction());
            //_accountRepository.ProcessTransactions(transaction);
            //return CheckBalance();
        }
    }
}
