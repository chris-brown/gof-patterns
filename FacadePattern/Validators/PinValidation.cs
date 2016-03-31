namespace FacadePattern.Validators
{
  internal class PinValidation
  {
    private readonly ICustomer _customer;

    internal PinValidation(ICustomer customer)
    {
      _customer = customer;
    }

    internal bool Validate(string pin)
    {
      return _customer.Pin.Equals(pin);
    }
  }
}