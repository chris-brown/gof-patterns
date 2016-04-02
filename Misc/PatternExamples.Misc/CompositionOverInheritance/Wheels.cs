namespace PatternExamples.Misc.CompositionOverInheritance.CompositionExample
{
  public class Wheels : IWheels
  {
    public Wheels()
    {
      RearLeft = new Wheel();
      RearRight = new Wheel();
      FrontLeft = new Wheel();
      FrontRight = new Wheel();
    }

    public IWheel RearLeft { get; set; }
    public IWheel RearRight { get; set; }
    public IWheel FrontLeft { get; set; }
    public IWheel FrontRight { get; set; }
  }
}