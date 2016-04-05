using NUnit.Framework;

namespace SingletonPattern.Tests
{
  [TestFixture]
  class MySettingsExampleTests
  {
    private MySettingsExample _firstSettings;
    private const string ExpectedUsername = "test user";
    private const string ExpectedPassword = "test password";

    [SetUp]
    public void Setup()
    {
      _firstSettings = MySettingsExample.GetSettings();
      _firstSettings.Username = ExpectedUsername;
      _firstSettings.Password = ExpectedPassword;
    }

    [Test]
    public void GivenAnInstance_EnsureValuesAreSet()
    {
      Assert.That(_firstSettings.Username, Is.EqualTo(ExpectedUsername));
      Assert.That(_firstSettings.Password, Is.EqualTo(ExpectedPassword));
    }

    [Test]
    public void GivenANewInstance_EnsureSingleton(){
      var secondSettings = MySettingsExample.GetSettings();
      
      Assert.That(secondSettings.Username, Is.EqualTo(ExpectedUsername));
      Assert.That(secondSettings.Password, Is.EqualTo(ExpectedPassword));
    }

  }
}
