namespace DecoratorPattern
{
  public class Car : ICar
  {
    private readonly decimal _price;
    private readonly int _topSpeed;

    public Car(decimal price, int topSpeed)
    {
      _price = price;
      _topSpeed = topSpeed;
    }

    public decimal Price
    {
      get
      {
        return _price;
      }
    }

    public int TopSpeed
    {
      get { return _topSpeed; }
    }
  }

  public interface ICar
  {
    decimal Price { get; }
    int TopSpeed { get; }
  }
}
