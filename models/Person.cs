public class Person
{
    public int Id { get; set; }
    public bool Driver { get; set; }

    public string? Name { get; set; }
    public int Age { get; set; }

    public string? Rego { get; set; }

    public Person()
    {
        // This is required for Entity Framework
    }

    public Person(int id, bool driver, string name, int age, string rego)
    {
        Id = id;
        Driver = driver;
        Name = name;
        Age = age;
        Rego = rego;
    }

}