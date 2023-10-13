public class Person
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }

    public bool Driver { get; set; }
    public int ProofNum { get; set; }

    public Person()
    {
        // This is required for Entity Framework
    }

    public Person(int id, string name, int age, bool driver)
    {
        Id = id;
        Name = name;
        Age = age;
        Driver = driver;
        ProofNum = 0;
    }

}