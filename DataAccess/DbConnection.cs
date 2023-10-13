using Npgsql;
using DotNetEnv;

public class DbConnection
{
    public static NpgsqlConnection GetDbConnection()
{
    Env.Load();
    var url = Environment.GetEnvironmentVariable("SUPABASE_URL");
    var key = Environment.GetEnvironmentVariable("SUPABASE_KEY");
    return new NpgsqlConnection($"User Id=postgres;Password={key};Server={url};Port=5432;Database=postgres");
}
}
