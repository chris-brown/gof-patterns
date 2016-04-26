using System;

namespace SingletonPattern
{
  public sealed class Teller
  {
    private decimal _balance;
    private static readonly object LockThis = new object();

    public Teller(decimal balance)
    {
      _balance = balance;
    }

    public decimal Withdraw(decimal amount)
    {
      if (_balance < 0)
      {
        throw new Exception("Negative balance");
      }

      // test will fail if singleton doesnt have an exclusive lock.
      lock (LockThis)
      {
        if (_balance >= amount)
        {
          _balance -= amount;
        }
        else
        {
          return 0;
        }
      }

      return _balance;
    }

    public decimal GetBalance()
    {
      return _balance;
    }
  }
}