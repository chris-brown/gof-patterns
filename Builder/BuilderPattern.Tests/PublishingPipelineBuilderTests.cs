using System;
using System.Linq;
using NUnit.Framework;

namespace BuilderPattern.Tests
{
  [TestFixture]
  public class PublishingPipelineBuilderTests
  {
    [Test]
    public void GivenOneFilter_WhenBuild_ReturnOneFilter()
    {
      // GIVEN:
      var filterA = new FilterA();
      var pipelineBuilder = new PublishingPipelineBuilder(filterA);
      // WHEN:
      var pipeline = pipelineBuilder.Build().ToList();
      // THEN:
      Assert.That(pipeline.Count, Is.EqualTo(1));
      Assert.That(pipeline.First(), Is.EqualTo(filterA));
    }

    [Test]
    public void GivenOneFilter_WhenIAppendOneMoreAndBuild_ReturnTwoFilters()
    {
      // GIVEN:
      var pipelineBuilder = new PublishingPipelineBuilder(new FilterA());
      // WHEN:
      var pipeline = pipelineBuilder.Append(new FilterA()).Build();
      // THEN:
      Assert.That(pipeline.Count(), Is.EqualTo(2));
    }

    [Test]
    public void GivenOneFilter_WhenIAppendManyInAFluentFashionAndBuild_ReturnManyFilters()
    {
      // GIVEN: // WHEN:
      var pipeline = new PublishingPipelineBuilder(new FilterA())
        .Append(new FilterA())
        .Append(new FilterA())
        .Append(new FilterA())
        .Append(new FilterA())
        .Build();
      // THEN:
      Assert.That(pipeline.Count(), Is.EqualTo(5));
    }
  }

  public class FilterA : IFilter
  {
    public void Execute()
    {
      throw new NotImplementedException();
    }
  }
}
