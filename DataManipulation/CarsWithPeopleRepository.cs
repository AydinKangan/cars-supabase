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

    public static List<Car> FindFullCars()
    {
        List<Car> CarsWithPeople = GetCarsWithPeople();
        List<Car> CarsNeedingReassignment = new List<Car>();

        foreach (Car car in CarsWithPeople)
        {
            if (car.Passengers != null && car.Passengers.Count > 5)
            {
                CarsNeedingReassignment.Add(car);
            }
        }



        return CarsNeedingReassignment; 
    }

    
}