using NUnit.Framework;

namespace BuilderPattern.Tests
{
  [TestFixture]
  class JobCandidateBuilderTests
  {
    private JobCandidateBuilder _candidateBuilder;

    [SetUp]
    public void Setup()
    {
      _candidateBuilder = new JobCandidateBuilder("chris", "brown");
    }

    [Test]
    public void Build_GivenACandidate_EnsureNameIsSet(){
      // GIVEN: // WHEN:
      var candidate = _candidateBuilder.Build();
      // THEN:
      Assert.That(candidate.Name, Is.EqualTo("chris brown"));
    }

    [Test]
    public void Build_GivenACandidate_WhenISetTheirAgeTo16_ThenCandidateIsTooYoung()
    {
      // GIVEN: // WHEN:
      _candidateBuilder.AddAge(16);
      var candidate = _candidateBuilder.Build();
      // THEN:
      Assert.That(candidate.IsValid, Is.False);
    }

    [Test]
    public void Build_GivenACandidate_WhenISetTheirAgeTo30_AndAvailabilityToImmediate_ThenCandidateIsValid()
    {
      // GIVEN: // WHEN:
      _candidateBuilder.AddAge(30);
      _candidateBuilder.AddAvailability(0);
      var candidate = _candidateBuilder.Build();
      // THEN:
      Assert.That(candidate.IsValid, Is.True);
    }

    [Test]
    public void Build_GivenACandidate_WhenISetTheirAgeTo30_AndAvailabilityToImmediate_Fluently_ThenCandidateIsValid()
    {
      // GIVEN: // WHEN:
      var candidate = _candidateBuilder
        .AddAge(30)
        .AddAvailability(5)
        .Build();
      // THEN:
      Assert.That(candidate.IsValid, Is.True);
    }
  }
}
