using NUnit.Framework;
using PatternExamples.Misc.CompositionOverInheritance.InheritanceExample;

namespace PatternExamples.Misc.Tests.CompositionOverInheritance
{
  [TestFixture]
  class InheritanceExampleTests
  {
    /*
      X-----X
      |  C  |
      |  A  |
      |  R  |
      0-----0
    * */
    [Test]
    public void GivenAToyota_IsRearWheelDrive() {
      // GIVEN:
      var car = new ToyotaMr2();
      // WHEN:
      car.Accelerate(10);
      // THEN:
      Assert.That(car.Manufacturer, Is.EqualTo("Toyota"));
      Assert.That(car.RearLeft.IsMoving);
      Assert.That(car.RearRight.IsMoving);
    }

    /*
      0-----0
      |  C  |
      |  A  |
      |  R  |
      0-----0
    * */
    [Test]
    public void GivenAImpreza_IsAllWheelDrive()
    {
      // GIVEN:
      var car = new SubaruImpreza();
      // WHEN:
      car.Accelerate(10);
      // THEN:
      Assert.That(car.Manufacturer, Is.EqualTo("Subaru"));
      Assert.That(car.RearLeft.IsMoving);
      Assert.That(car.RearRight.IsMoving);
      Assert.That(car.FrontLeft.IsMoving);
      Assert.That(car.FrontRight.IsMoving);
    }
  }
}
