namespace FacadePattern
{
  public interface ICustomer
  {
    string Pin { get; }
    decimal Balance { get; set; }
  }

  internal class Customer : ICustomer
  {
    public Customer(decimal i, string pin, decimal balance)
    {
      Pin = pin;
      Balance = balance;
    }

    public string Pin { get; private set; }
    public decimal Balance { get; set; }
  }
}