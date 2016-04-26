using System.Collections.Generic;

namespace BuilderPattern
{
    public class PublishingPipelineBuilder : IBuild
    {
      private readonly IList<IFilter> _filters = new List<IFilter>();

      public PublishingPipelineBuilder(params IFilter[] filters)
      {
      }

      public PublishingPipelineBuilder(IFilter filter)
      {
        _filters.Add(filter);
      }

      public PublishingPipelineBuilder Append(IFilter filter)
      {
        _filters.Add(filter);
        return this;
      }

      public IEnumerable<IFilter> Build()
      {
        return _filters;
      }
    }

  public interface IBuild
  {
    PublishingPipelineBuilder Append(IFilter filter);
    IEnumerable<IFilter> Build();
  }

  public interface IFilter
  {
    void Execute();
  }
}
