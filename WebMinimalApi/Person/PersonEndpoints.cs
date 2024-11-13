using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebMinimalApi;

public static class PersonEndpoints
{
    public static void MapEndpoints(WebApplication app)
    {
        app.MapGet("api/persons", async (PersonsContext db) =>
        {
            var person = await db.Persons.ToListAsync();
            if (person.Count() == 0)
            {
                return Results.NoContent();
            }
            return Results.Ok(person);
        });

        app.MapGet("api/persons/{id}", async (PersonsContext db, int id) =>
        {
            var person = await db.Persons.FindAsync(id);
            if (person is null)
            {
                return Results.NotFound(new {message = "Person not found"});
            }

            return Results.Ok(person);

        });

        app.MapDelete("api/person/{id}", async (PersonsContext db, int id) =>
        {
            var person = await db.Persons.FindAsync(id);
            if (person is null)
            {
                return Results.NotFound(new {message = "Person not found"});
            }

            db.Persons.Remove(person);
            await db.SaveChangesAsync();

            return Results.Ok(person);

        });

        app.MapPut("api/person/{id}", async (PersonsContext db, int id, Person updatedPerson) =>
        {
            var person = await db.Persons.FindAsync(id);
            if (person is null)
            {
                return Results.NotFound(new {message = "Person not found"});
            }

            var validationContext = new ValidationContext(updatedPerson);
            var validationResults = new List<ValidationResult>();

            if (!Validator.TryValidateObject(updatedPerson, validationContext, validationResults, true))
            {
                var errors = validationResults
                    .Select(result => new { field = result.MemberNames.FirstOrDefault(), error = result.ErrorMessage });
                return Results.BadRequest(errors);
            }

            person.Name = updatedPerson.Name;
            person.LastName = updatedPerson.LastName;
            person.BirthDate = updatedPerson.BirthDate;
            person.Address = updatedPerson.Address;

            await db.SaveChangesAsync();

            return Results.Ok(person);
        });

        app.MapPost("/api/persons", async (PersonsContext db, Person person) =>
        {
            var validationContext = new ValidationContext(person);
            var validationResults = new List<ValidationResult>();

            if (!Validator.TryValidateObject(person, validationContext, validationResults, true))
            {
                var errors = validationResults
                    .Select(result => new { field = result.MemberNames.FirstOrDefault(), error = result.ErrorMessage });
                return Results.BadRequest(errors);
            }
            
            db.Persons.Add(person);
            await db.SaveChangesAsync();
            return Results.Created($"/api/persons/{person.Id}", person);
        });
    }
}
