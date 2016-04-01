namespace FacadePattern
{
  using Validators;

  /// <summary>
  /// Facade example
  /// </summary>
  public class AutomatedTellerMachine
  {
    private readonly ICustomer _customer;
    private readonly PinValidation _tellerValidation;
    private readonly AccountValidator _accountValidator;

    public AutomatedTellerMachine(ICustomer customer)
    {
      _customer = customer;
      _tellerValidation = new PinValidation(customer);
      _accountValidator = new AccountValidator(customer);
    }

    public void Withdraw(decimal amount, string pin)
    {
      if (_tellerValidation.Validate(pin) && _accountValidator.Validate(amount))
      {
        _customer.Balance -= amount;
      }
    }
  }
}