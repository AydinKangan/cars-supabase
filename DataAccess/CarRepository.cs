
using Npgsql;

public class CarRepository
{
    public static List<Car> GetCars()
    {
        List<Car> cars = new List<Car>();
        using (var conn = DbConnection.GetDbConnection())
        {
            try
            {
                conn.Open();
                string query = "SELECT rego AS Rego, colour AS Colour, make AS Make, model AS Model FROM \"Car\"";

                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cars.Add(new Car(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3)));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        return cars;
    }
}
