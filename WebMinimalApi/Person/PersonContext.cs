using Microsoft.EntityFrameworkCore;

namespace WebMinimalApi;

public class PersonsContext : DbContext
{
    public PersonsContext(DbContextOptions<PersonsContext> options) : base(options) { }

    public DbSet<Person>? Persons { get; set; }
}