namespace SingletonPattern
{
  public sealed class MySettingsExample
  {
    private static readonly object LockThis = new object();
    private static MySettingsExample _instance;

    public static MySettingsExample GetSettings()
    {
      lock (LockThis)
      {
        if(_instance == null) _instance = new MySettingsExample();
      }

      return _instance;
    }

    public string Username { get; set; }
    public string Password { get; set; }
  }
}
