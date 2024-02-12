using Microsoft.EntityFrameworkCore;
using SMCinema.Domain.Contracts;
using SMCinema.Infrastructure.Database.Contexts;
using SMCinema.Infrastructure.Database.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Add DbContext or SMCinemaDbContext in services
builder.Services.AddDbContext<SMCinemaDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("MigrationDb")));

// Add Repositories in services
builder.Services.AddScoped<IMovieRepository, MovieRepository>()
        .AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
