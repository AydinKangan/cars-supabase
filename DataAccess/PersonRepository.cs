using Npgsql;

public class PersonRepository
{
    public static List<Person> GetPeople()
{
    List<Person> people = new List<Person>();
    using (var conn = DbConnection.GetDbConnection())
    {
        try
        {
            conn.Open();
            string query = "SELECT id AS Id, driver AS Driver, name AS Name, age AS Age, rego AS Rego FROM \"Person\"";

            using (var cmd = new NpgsqlCommand(query, conn))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        people.Add(new Person(reader.GetInt32(0), reader.GetBoolean(1), reader.GetString(2), reader.GetInt32(3), reader.GetString(4)));
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    return people;

}
}
