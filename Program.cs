var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.MapGet("/get-people", () => PersonRepository.GetPeople());
app.MapGet("/get-cars", () => CarRepository.GetCars());
app.MapGet("/get-cars-with-people", () => CarsWithPeopleRepository.GetCarsWithPeople());

app.Run();



// Person p1 = new Person();

// Person p2 = new Person(1, "John", 20);

// app.MapGet("/", () => p2);
// app.MapGet("/people/{id}", (int id) => getPersonById(id));
// app.MapGet("/carspassengers", () => getCarsWithPassengers());


// Post endpoints
// app.MapPost("/cars", (Car newCar) => InsertNewCar(newCar));

// string InsertNewCar(Car newCar)
// {
//     // connect to the database
//     using (var conn = getDbConnection())
//     {
//         try
//         {
//             conn.Open();
//             // query
//             // map values from the newCar object to the query
//             string query = $"INSERT INTO \"Car\" (rego, colour, make, model) VALUES (@regoVal, @colourVal, @makeVal, @modelVal)";

//             using (var cmd = new NpgsqlCommand(query, conn))
//             {
//                 cmd.Parameters.AddWithValue("regoVal", newCar.Rego);
//                 cmd.Parameters.AddWithValue("colourVal", newCar.Colour);
//                 cmd.Parameters.AddWithValue("makeVal", newCar.Make);
//                 cmd.Parameters.AddWithValue("modelVal", newCar.Model);
//                 cmd.ExecuteNonQuery();
//             }


//         }
//         catch (Exception e)
//         {
//             Console.WriteLine(e.Message);
//             return e.Message;
//         }
//     }


//     return newCar.Rego;
// }

// app.MapPost("/findCarByRego", (Car findCar) => FindCarByRego(findCar));



// Car FindCarByRego(Car findCar)
// {
//     return getCars().Find(car => car.Rego == findCar.Rego);
// }

// Person getPersonById(int id)
// {
//     return getPeople().Find(person => person.Id == id);
// }





// List<Car> getCarsWithPassengers()
// {
//     List<Car> cars = new List<Car>();

//     using (var conn = getDbConnection())
//     {
//         try
//         {
//             conn.Open();
//             string query = "Select * From \"Car\" Join \"Person\" on \"Car\".rego = \"Person\".rego";
//             using (var cmd = new NpgsqlCommand(query, conn))
//             {
//                 using (var reader = cmd.ExecuteReader())
//                 {
//                     while (reader.Read())
//                     {
//                         Car tempCar = new Car(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));

//                         Person tempPerson = new Person(reader.GetInt32(4), reader.GetString(5), reader.GetInt32(6));

//                         if (!carInList(cars, tempCar))
//                         {
//                             cars.Add(tempCar);
//                         }

//                         // Add person to the correct car
//                         int carIndex = getCarIndexFromRego(cars, tempCar.Rego);

//                         if (carIndex != -1)
//                         {
//                             cars[carIndex].Passengers.Add(tempPerson);
//                         }

//                         // Add driver to the correct car
//                         if (reader.GetBoolean(8))
//                         {
//                             cars[carIndex].Driver = tempPerson;
//                         }

//                     }
//                 }
//             }
//         }
//         catch (Exception e)
//         {
//             Console.WriteLine(e.Message);
//         }
//     }
//     return cars;
// }

// bool carInList(List<Car> cars, Car newCar)
// {
//     foreach (Car c in cars)
//     {
//         if (c.Rego == newCar.Rego)
//         {
//             return true;
//         }
//     }
//     return false;
// }

// int getCarIndexFromRego(List<Car> car, string rego)
// {
//     for (int i = 0; i < car.Count; i++)
//     {
//         if (car[i].Rego == rego)
//         {
//             return i;
//         }
//     }
//     return -1;
// }

