# Entity Framework Setup

## Install Dotent EF CLI Tool

Current version of dotnet core SDK doesn't include `dotnet-ef` out of the box.
</br>You have to manually install it.

<code>dotnet tool install --global dotnet-ef</code>

## Steps

Step 1: Add code inside of the Startup class of the API project to configure our DataContext class with the SQLite client.

_This is an example of using our wired up SQLite instance with a custom EF type (DataContext) as a service within our application._

```csharp
// Startup.cs
public void ConfigureServices(IServiceCollection services)
{
    // {1} Add the DataContext object as a service
    services.AddDbContext<DataContext>(dbContextOptionsBuilder =>
    {
        dbContextOptionsBuilder.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
    });
    services.AddControllers();
}
```

Step 2: Perform a dotnet-ef **migration**.

<code>dotnet ef migrations add InitialCreate -p Persistence -s API/</code>

_-p Specifies the project path containing the data context_
_-s Specifies the startup project path_
