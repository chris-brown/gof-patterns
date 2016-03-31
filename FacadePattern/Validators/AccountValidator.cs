namespace FacadePattern.Validators
{
  internal class AccountValidator
  {
    private readonly ICustomer _customer;

    internal AccountValidator(ICustomer customer)
    {
      _customer = customer;
    }

    internal bool Validate(decimal amountToWithdraw)
    {
      return amountToWithdraw <= _customer.Balance;
    }
  }
}