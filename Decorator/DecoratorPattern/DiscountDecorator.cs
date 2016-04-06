namespace DecoratorPattern
{
  public class DiscountDecorator : CarDecorator
  {
    public DiscountDecorator(ICar car) : base(car) { }

    /// <summary>
    /// If price is over 1000 then give a 20% discount.
    /// </summary>
    public override decimal Price
    {
      get { return base.Price > 1000 ? base.Price - (base.Price*0.2m) : base.Price; }
    }
  }
}