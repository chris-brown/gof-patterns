namespace BuilderPattern
{
  public class JobCandidateBuilder
  {
    private readonly string _firstname;
    private readonly string _surname;
    private int _age;
    private int _dayTillAvailable;

    private string FullName => $"{_firstname} {_surname}";

    public JobCandidateBuilder(string firstname, string surname)
    {
      _firstname = firstname;
      _surname = surname;
    }

    public JobCandidateBuilder AddAge(int age)
    {
      _age = age;
      return this;
    }

    public JobCandidateBuilder AddAvailability(int inDays)
    {
      _dayTillAvailable = inDays;
      return this;
    }

    public Candidate Build() => new Candidate(FullName, Validate);

    private bool Validate => _age > 18 && _dayTillAvailable <= 30;
  }

  public class Candidate
  {
    public Candidate(string name, bool isValid)
    {
      Name = name;
      IsValid = isValid;
    }

    public string Name { get; private set; }
    public bool IsValid { get; private set; }
  }
}
