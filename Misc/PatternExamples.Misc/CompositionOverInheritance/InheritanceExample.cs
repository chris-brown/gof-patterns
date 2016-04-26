 // ReSharper disable CheckNamespace

namespace PatternExamples.Misc.CompositionOverInheritance.InheritanceExample
{
  /// <summary>
  ///   Inheritance example
  /// </summary>
  public class Wheel
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

  public abstract class Car
  {
    protected Car()
    {
      FrontLeft = new Wheel();
      FrontRight = new Wheel();
      RearLeft = new Wheel();
      RearRight = new Wheel();
    }

    public Wheel FrontLeft { get; set; }
    public Wheel FrontRight { get; set; }
    public Wheel RearLeft { get; set; }
    public Wheel RearRight { get; set; }
    public abstract string Manufacturer { get; }

    public abstract void Accelerate(double mph);
  }

  public class ToyotaMr2 : Car
  {
    public override string Manufacturer
    {
      get { return "Toyota"; }
    }

    public override void Accelerate(double mph)
    {
      RearLeft.Rotate(mph);
      RearRight.Rotate(mph);
    }
  }

  public class SubaruImpreza : Car
  {
    public override string Manufacturer
    {
      get { return "Subaru"; }
    }

    public override void Accelerate(double mph)
    {
      FrontRight.Rotate(mph);
      FrontLeft.Rotate(mph);
      RearRight.Rotate(mph);
      RearLeft.Rotate(mph);
    }
  }
}