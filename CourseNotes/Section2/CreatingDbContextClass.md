# Creating DataContext Class

The application layer handling database interaction will be the `Persistence` project.

To use entity framework we must first setup the DbContext class.

**Key Points**

<ul>
    <li>EF requires a class to model the table schemas</li>
    <li>DataContext requries parent/child inheritance from the EF type `DbContext`</li>
</ul>

## STEPS

Step 1: Define DataContext Class
Step 2: Add a field that is of EF generic type

```csharp
// DataContext.cs
namespace Persistence
{
    public class DataContext : DbContext
    {
        // {1} Define constructor and be sure to call the base class constructor with the options argument
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        // {2} Define property with a getter/setter that is of type DbSet<Value>
        public DbSet<Value> MyProperty { get; set; }

    }
}

```
