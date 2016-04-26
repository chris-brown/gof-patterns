namespace DecoratorPattern
{
  public abstract class CarDecorator : ICar
  {
    private readonly ICar _car;

    protected CarDecorator(ICar car)
    {
      _car = car;
    }

    public virtual decimal Price
    {
      get { return _car.Price; }
    }

    public virtual int TopSpeed
    {
      get { return _car.TopSpeed; }
    }
  }
}