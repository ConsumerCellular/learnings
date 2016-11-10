using Moq;
using NUnit.Framework;

namespace BankManager.Tests
{
    public abstract class BaseTestClass
    {
        [SetUp]
        public virtual void Setup()
        {
            Logging.Logger = Mock.Of<ILogger>();
        }
    }
}