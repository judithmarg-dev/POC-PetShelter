using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PetShelterWorld.Application.Adoptants.Queries.GetAdoptants;
using PetShelterWorld.Application.Attendants.Queries.GetAttendants;
using PetShelterWorld.Application.Interfaces;
using PetShelterWorld.Application.PetCards.Commands.CreatePetCard;
using PetShelterWorld.Application.PetCards.Commands.CreatePetCard.Factory;
using PetShelterWorld.Application.PetCards.Queries.GetPetCardDetails;
using PetShelterWorld.Application.PetCards.Queries.GetPetCardsList;
using PetShelterWorld.Application.Pets.Queries.GetPets;
using PetShelterWorld.Infrastructure.Shelter;
using PetShelterWorld.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddControllers();


builder.Services.AddDbContext<DatabaseService>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PetShelterWorld")));

builder.Services.AddScoped<IDatabaseService>(sp => sp.GetRequiredService<DatabaseService>());


builder.Services.AddScoped<IShelterService, ShelterService>();
builder.Services.AddScoped<IGetAdoptantListQuery, GetAdoptantListQuery>();
builder.Services.AddScoped<IGetAttendantListQuery, GetAttendantListQuery>();
builder.Services.AddScoped<IGetPetCardDetailQuery, GetPetCardDetailQuery>();
builder.Services.AddScoped<IGetPetCardsListQuery, GetPetCardsListQuery>();
builder.Services.AddScoped<IGetPetListQuery, GetPetListQuery>();
builder.Services.AddScoped<ICreatePetCardCommand, CreatePetCardCommand>();
builder.Services.AddScoped<IAdoptionFactory, AdoptionFactory>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var useCors = "_myCors";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: useCors, policy =>
    {
        policy.WithOrigins("http://localhost:52664")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();
app.UseCors(useCors);

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DatabaseService>();
    var cs = db.Database.GetDbConnection().ConnectionString;
    app.Logger.LogInformation("EF is connecting to: {ConnectionString}", cs);

#if DEBUG
    db.Database.EnsureDeleted();
#endif
    db.Database.EnsureCreated();

}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
