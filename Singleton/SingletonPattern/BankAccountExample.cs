namespace SingletonPattern
{
  public static class BankAccountExample
  {
    private static readonly object LockThis = new object();
    private static Teller _teller;

    public static Teller Open(decimal balance)
    {
      lock (LockThis)
      {
        if (_teller == null) _teller = new Teller(balance);
      }

      return _teller;
    }
  }
}
