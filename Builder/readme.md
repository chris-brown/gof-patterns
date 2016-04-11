# [Builder Pattern](http://c2.com/cgi/wiki?BuilderPattern)

Separate the steps for constructing of a complex object from its final representation so that (a) an object with strict properties (e.g. immutable, or say, maxTemperature >= minTemperature) can be configured in less strict steps, (b) avoid hard-to-remember/understand chatty constructors with many arguments, and (c) where possible allow the caller to reuse steps for creating similar instances.

> The builder pattern is a good choice when designing classes whose constructors or static factories would have more than a handful of parameters.

### Example

``` cs
var pipeline = new PublishingPipelineBuilder(new FilterA())
	.Append(new FilterB())
	.Append(new FilterC())
	.Append(new FilterD())
	.Append(new FilterE())
	.Build();

Assert.That(pipeline.Count(), Is.EqualTo(5));
```

This is a pretty primitive example because append method accepts anything of type IFilter and can actually by resolved by adding `PublishingPipelineBuilder(params IFilter[] filters){}` as a constructor.

Alternatively the example below has better context.

``` cs
Candidate candidate = new JobCandidateBuilder("chris", "brown")
	.AddAge(30)
	.AddAvailability(5)
	.Build();

Assert.That(candidate.IsValid, Is.True);
```

This replaces the constructor for `Candidate` in being `public Candidate(string firstname, string surname, int age, int dayTillAvailable){}`