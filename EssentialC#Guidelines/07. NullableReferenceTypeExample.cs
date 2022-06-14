namespace IntelliTect.Guidelines.CSharp;

record class Person
{
    public Person(string name) =>
        Name = name; // Use property instead of ??throw new ArgumentNullException(nameof(name));

    string? _Name;
    public string Name
    {
        get => _Name!;
        set
        { 
            ArgumentNullException
                .ThrowIfNull(value, null);
            _Name = value;
        }
    }
}

[TestClass]
public class PersonTests
{
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Name_AssignNull_ThrowsArgumentNullExceptoin()
    {
        Person _ = new(null!);
    }
}