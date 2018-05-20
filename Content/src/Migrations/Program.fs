module Program

open System.Reflection
open SimpleMigrations
open SimpleMigrations.DatabaseProvider
open SimpleMigrations.Console
open Npgsql

[<EntryPoint>]
let main argv =
    let assembly = Assembly.GetExecutingAssembly()
    use db = new NpgsqlConnection "Host=localhost;Username=test;Password=test;Database=test"
    let provider = PostgresqlDatabaseProvider(db)
    let migrator = SimpleMigrator(assembly, provider)
    let consoleRunner = ConsoleRunner(migrator)
    consoleRunner.Run(argv)
    0
