namespace FacadePattern.Tests
{
  internal class FakeCustomer : ICustomer
  {
    public FakeCustomer(int balance, string pin)
    {
      Balance = balance;
      Pin = pin;
    }

    public string Pin { get; private set; }
    public decimal Balance { get; set; }
  }
}