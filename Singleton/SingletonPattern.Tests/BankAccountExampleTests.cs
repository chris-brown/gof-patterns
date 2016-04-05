using System.Threading.Tasks;
using NUnit.Framework;

namespace SingletonPattern.Tests
{
  [TestFixture]
  class BankAccountExampleTests
  {
    [SetUp, Description("Ensure opening balance is 1000")]
    public void Setup()
    {
      BankAccountExample.Open(1000);
    }

    [Test]
    public void ReOpen_AndWithdraw_EnsureNoExceptionIsRaised(){
      // GIVEN:
      var account = BankAccountExample.Open(-10);
      // THEN: // WHEN:
      Assert.DoesNotThrow(() => account.Withdraw(0));
      Assert.That(account.GetBalance(), Is.Not.EqualTo(-10));
    }

    [Test]
    public void WithdrawConcurently_EnsureBalanceIsZeroAndNoExceptionIsThrown(){
      
      // GIVEN:
      var teller = BankAccountExample.Open(0);
      const int withdrawTransactions = 100;
      var tasks = new Task[withdrawTransactions];

      for (var transaction = 0; transaction < withdrawTransactions; transaction++)
      {
        tasks[transaction] = Task.Factory.StartNew(() => teller.Withdraw(10));
      }

      // WHEN:
      Task.WaitAll(tasks);
      // THEN:
      Assert.That(teller.GetBalance(), Is.EqualTo(0));
    }
  }
}
