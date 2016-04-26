namespace DecoratorPattern
{
  public class CabrioletDecorator : CarDecorator
  {
    public CabrioletDecorator(ICar car) : base(car) { }

    public override decimal Price
    {
      get { return base.Price + 1000; }
    }

    public override int TopSpeed
    {
      get { return base.TopSpeed - 20; }
    }
  }
}