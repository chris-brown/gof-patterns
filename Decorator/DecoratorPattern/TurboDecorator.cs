namespace DecoratorPattern
{
  public class TurboDecorator : CarDecorator
  {
    public TurboDecorator(ICar car) : base(car) {}

    public override decimal Price
    {
      get { return base.Price + 100; }
    }

    public override int TopSpeed
    {
      get { return base.TopSpeed + 10; }
    }
  }
}