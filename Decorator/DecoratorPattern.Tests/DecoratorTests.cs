using NUnit.Framework;

namespace DecoratorPattern.Tests
{
  [TestFixture]
  public class DecoratorTests
  {
    private Car _car;
    private const int Speed = 100;
    private const decimal BasePrice = 1000m;

    [SetUp]
    public void Setup()
    {
      _car = new Car(BasePrice, Speed);
    }

    [Test]
    public void GivenABasicCar_Ensure(){
      Assert.That(_car.Price, Is.EqualTo(BasePrice));
      Assert.That(_car.TopSpeed, Is.EqualTo(Speed));
    }

    [Test]
    public void GivenIAddATurbo_EnsurePropertiesAreEffected()
    {
      var fastCar = new TurboDecorator(_car);
      Assert.That(fastCar.Price, Is.EqualTo(BasePrice + 100));
      Assert.That(fastCar.TopSpeed, Is.EqualTo(Speed + 10));
    }

    [Test]
    public void GivenIAddATurboAndSunroof_EnsurePropertiesAreEffected()
    {
      var fastCar = new TurboDecorator(_car);
      var sunroof = new CabrioletDecorator(fastCar);

      Assert.AreEqual(sunroof.Price, 2100);
      Assert.AreEqual(sunroof.TopSpeed, 90);
    }

    [Test]
    public void GivenIAddATurboAndSunroof_WithDiscount_EnsurePropertiesAreEffected()
    {
      var fastCar = new TurboDecorator(_car);
      var sunroof = new CabrioletDecorator(fastCar);
      var discount = new DiscountDecorator(sunroof);

      Assert.AreEqual(discount.Price, 1680);
      Assert.AreEqual(discount.TopSpeed, 90);
    }

    [Test]
    public void GivenIAddATurboAndSunroof_WithDiscount_WhenIApplyDiscountFirst_EnsureDiscountIsNotAdded()
    {
      var discount = new DiscountDecorator(_car);
      var fastCar = new TurboDecorator(discount);
      var sunroof = new CabrioletDecorator(fastCar);

      Assert.AreEqual(sunroof.Price, 2100);
      Assert.AreEqual(sunroof.TopSpeed, 90);
    }
  }
}