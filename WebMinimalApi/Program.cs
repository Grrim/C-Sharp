using Microsoft.EntityFrameworkCore;
using WebMinimalApi;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PersonsContext>(options =>
    options.UseInMemoryDatabase("PersonDB"));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

PersonEndpoints.MapEndpoints(app);

app.Run();
