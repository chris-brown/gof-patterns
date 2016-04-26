using NUnit.Framework;
using PatternExamples.Misc.CompositionOverInheritance.CompositionExample;

namespace PatternExamples.Misc.Tests.CompositionOverInheritance
{
  [TestFixture]
  class CompositionExampleTests
  {
    /*
      X-----X
      |  C  |
      |  A  |
      |  R  |
      0-----0
    * */
    [Test]
    public void GivenAToyota_IsRearWheelDrive(){
      // GIVEN:
      var car = CarFactory.BuildToyotaMr2();
      // WHEN:
      car.Drive(10);
      // THEN:
      Assert.That(car.Manufacturer, Is.TypeOf<Toyota>());
      Assert.That(car.Manufacturer.Name, Is.EqualTo("Toyota"));
      Assert.That(car.Wheels.RearLeft.IsMoving);
      Assert.That(car.Wheels.RearRight.IsMoving);
      Assert.That(car.Wheels.FrontLeft.IsMoving, Is.Not.True);
      Assert.That(car.Wheels.FrontRight.IsMoving, Is.Not.True);
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
      var car = CarFactory.BuildSubaruImpreza();
      // WHEN:
      car.Drive(10);
      // THEN:
      Assert.That(car.Manufacturer, Is.TypeOf<Subaru>());
      Assert.That(car.Manufacturer.Name, Is.EqualTo("Subaru"));
      Assert.That(car.Wheels.RearLeft.IsMoving);
      Assert.That(car.Wheels.RearRight.IsMoving);
      Assert.That(car.Wheels.FrontLeft.IsMoving);
      Assert.That(car.Wheels.FrontRight.IsMoving);
    }
  }
}
