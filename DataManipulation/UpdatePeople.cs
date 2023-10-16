using Npgsql;

public class UpdatePeople
{ 

    static string UpdatePersonRego(int id, string rego)
{
    using (var conn = DbConnection.GetDbConnection())
    {
        try
        {
            conn.Open();
            
            string query = "UPDATE \"Person\" SET rego = @rego WHERE id = @id";
            
            using (var cmd = new NpgsqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("rego", rego);
                cmd.ExecuteNonQueryAsync(); // Use asynchronous version
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return e.Message;
        }
    }
    
    return "Person's rego updated successfully";
}



public static List<Car> MovePeopleIntoOtherCars()
    {
        List<Car> FullCars = CarsWithPeopleRepository.FindFullCars();
        List<Car> Cars = CarsWithPeopleRepository.GetCarsWithPeople();
        List<Person> People = PersonRepository.GetPeople();

        // Create a dictionary to map person IDs to their corresponding Person objects
        Dictionary<int, Person> peopleDictionary = new Dictionary<int, Person>();
        
        foreach (Person person in People)
        {
            peopleDictionary[person.Id] = person;
        }

        foreach (Car fullCar in FullCars)
        {
            int fullNumberOfPassengers = fullCar.Passengers?.Count ?? 0;
            while (fullNumberOfPassengers > 5)
            {
                int index = fullNumberOfPassengers - 1;
                Person passengerToMove = fullCar.Passengers[index];

                foreach (Car car in Cars)
                {
                    int numberOfPassengers = car.Passengers?.Count ?? 0;
                    if (numberOfPassengers < 5)
                    {
                        string newRego = car.Rego;
                        int id = passengerToMove.Id;

                        // Find the current car the person is in
                        Car currentCar = Cars.FirstOrDefault(c => c.Passengers?.Any(p => p.Id == id) == true);

                        if (currentCar != null)
                        {
                            currentCar.Passengers?.Remove(passengerToMove);

                            car.Passengers?.Add(new Person(id, passengerToMove.Driver, passengerToMove.Name, passengerToMove.Age, newRego));

                            // Update the person's Rego using the dictionary
                            if (peopleDictionary.TryGetValue(id, out var personToUpdate))
                            {
                                personToUpdate.Rego = newRego;
                            }
                        }
                    }
                }
            }
        }

        return Cars;
    }



}

