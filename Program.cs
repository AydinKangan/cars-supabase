var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Use((ctx, next) =>
{
    ctx.Response.Headers["Access-Control-Allow-Origin"] = "*";

    return next();
});

app.MapGet("/get-people", () => PersonRepository.GetPeople());
app.MapGet("/get-cars", () => CarRepository.GetCars());
app.MapGet("/get-cars-with-people", () => CarsWithPeopleRepository.GetCarsWithPeople());
app.MapGet("/find-full-cars", () => CarsWithPeopleRepository.FindFullCars());
app.Run();
















// UpdatePeople.MovePeopleIntoOtherCars();

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








