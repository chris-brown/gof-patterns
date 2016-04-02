// ReSharper disable CheckNamespace

namespace PatternExamples.Misc.CompositionOverInheritance.CompositionExample
{
  /// <summary>
  ///   examples of composition
  /// </summary>
  public static class CarFactory
  {
    public static ICar BuildToyotaMr2()
    {
      var wheels = new Wheels();

      return new Car(new Toyota(), wheels, new RearWheelDrive(wheels));
    }

    public static ICar BuildSubaruImpreza()
    {
      var wheels = new Wheels();

      return new Car(new Subaru(), wheels, new AllWheelDrive(wheels));
    }
  }

  public class Car : ICar
  {
    private readonly IDrive _driveChain;

    public Car(IManufacturer manufacturer, IWheels wheels, IDrive driveChain)
    {
      Manufacturer = manufacturer;
      _driveChain = driveChain;
      Wheels = wheels;
    }

    public IManufacturer Manufacturer { get; private set; }
    public IWheels Wheels { get; private set; }

    public void Drive(double mph)
    {
      _driveChain.Rotate(mph);
    }
  }

  public class RearWheelDrive : IDrive
  {
    private readonly IWheels _wheels;

    public RearWheelDrive(IWheels wheels)
    {
      _wheels = wheels;
    }

    public void Rotate(double mph)
    {
      _wheels.RearLeft.Rotate(mph);
      _wheels.RearRight.Rotate(mph);
    }
  }

  public class AllWheelDrive : IDrive
  {
    private readonly IWheels _wheels;

    public AllWheelDrive(IWheels wheels)
    {
      _wheels = wheels;
    }

    public void Rotate(double mph)
    {
      _wheels.RearLeft.Rotate(mph);
      _wheels.RearRight.Rotate(mph);
      _wheels.FrontLeft.Rotate(mph);
      _wheels.FrontRight.Rotate(mph);
    }
  }

  public class Wheel : IWheel
  {
    private double _mph;

    public bool IsMoving
    {
      get { return _mph > 0; }
    }

    public void Rotate(double mph)
    {
      _mph = mph;
    }
  }

  public class Wheels : IWheels
  {
    public Wheels()
    {
      RearLeft = new Wheel();
      RearRight = new Wheel();
      FrontLeft = new Wheel();
      FrontRight = new Wheel();
    }

    public IWheel RearLeft { get; private set; }
    public IWheel RearRight { get; private set; }
    public IWheel FrontLeft { get; private set; }
    public IWheel FrontRight { get; private set; }
  }

  public interface IWheel
  {
    bool IsMoving { get; }
    void Rotate(double mph);
  }

  public class Toyota : IManufacturer
  {
    public string Name
    {
      get { return "Toyota"; }
    }
  }

  public class Subaru : IManufacturer
  {
    public string Name
    {
      get { return "Subaru"; }
    }
  }

  public interface ICar
  {
    IManufacturer Manufacturer { get; }
    IWheels Wheels { get; }
    void Drive(double mph);
  }

  public interface IWheels
  {
    IWheel RearLeft { get; }
    IWheel RearRight { get; }
    IWheel FrontLeft { get; }
    IWheel FrontRight { get; }
  }

  public interface IDrive
  {
    void Rotate(double mph);
  }

  public interface IManufacturer
  {
    string Name { get; }
  }
}