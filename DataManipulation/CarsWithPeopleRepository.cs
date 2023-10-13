public class CarsWithPeopleRepository
{
    public static List<Car> GetCarsWithPeople()
    {
        List<Car> cars = CarRepository.GetCars();
        List<Person> people = PersonRepository.GetPeople();

        foreach (Person person in people)
        {
            string? rego = person.Rego;
            Car? car = cars.Find(c => c.Rego == rego);

            if (car != null)
            {
                car.Passengers ??= new List<Person>();
                car.Passengers.Add(person);
            }
        }

        return cars;
    }


}