using NUnit.Framework;

namespace FacadePattern.Tests
{
  [TestFixture]
  class AutomatedTellerMachineTests
  {
    private const string CorrectPin = "1234";
    private const string InCorrectPin = "incorrect pin";
    private ICustomer _customer;

    [SetUp]
    public void Setup()
    {
      _customer = new FakeCustomer(0, "1234");
    }

    [Test]
    public void WithDraw_GivenInValidPin_WithdrawNoMoney()
    {
      // GIVEN:
      var cart = new AutomatedTellerMachine(_customer);
      // WHEN:
      cart.Withdraw(10, InCorrectPin);
      // THEN:
      Assert.That(_customer.Balance, Is.EqualTo(0));
    }

    [Test]
    public void WithDraw_GivenCustomerHasNoMoney_AndCustomerWithdraws10_ThenReturnNoFund()
    {
      // GIVEN:
      var cart = new AutomatedTellerMachine(_customer);
      // WHEN:
      cart.Withdraw(10, CorrectPin);
      // THEN:
      Assert.That(_customer.Balance, Is.EqualTo(0));
    }

    [Test]
    public void WithDraw_GivenCustomerHasMoney_AndCustomerWithdraws10_ThenDecreaseBalance()
    {
      // GIVEN:
      const decimal startingBalance = 100;
      const decimal amountToWithDraw = 10;
      _customer.Balance = startingBalance;

      // WHEN:
      new AutomatedTellerMachine(_customer).Withdraw(amountToWithDraw, CorrectPin);
      // THEN:
      Assert.That(_customer.Balance, Is.EqualTo(startingBalance - amountToWithDraw));
    }
  }
}
