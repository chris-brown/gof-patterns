# [Decorator Pattern](http://c2.com/cgi/wiki?DecoratorPattern)

The decorator pattern is a design pattern that extends the functionality of individual objects by wrapping them with one or more decorator classes. These decorators can modify existing members and add new methods and properties at run-time.

This provides a flexible alternative to using inheritance to modify behaviour.

### Example

``` cs
var fastCar = new TurboDecorator(_car);
var sunroof = new CabrioletDecorator(fastCar);
var discount = new DiscountDecorator(sunroof);

Assert.AreEqual(discount.Price, 1680);
Assert.AreEqual(discount.TopSpeed, 90);
```
