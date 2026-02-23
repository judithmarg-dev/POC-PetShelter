using PetShelterWorld.Application.Adoptants.Queries.GetAdoptants;
using PetShelterWorld.Application.Attendants.Queries.GetAttendants;
using PetShelterWorld.Application.Interfaces;
using PetShelterWorld.Application.PetCards.Commands.CreatePetCard;
using PetShelterWorld.Application.PetCards.Queries.GetPetCardDetails;
using PetShelterWorld.Application.PetCards.Queries.GetPetCardsList;
using PetShelterWorld.Application.Pets.Queries.GetPets;
using PetShelterWorld.Infrastructure.Shelter;
using PetShelterWorld.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddControllers();

builder.Services.AddScoped<IShelterService, ShelterService>();
builder.Services.AddScoped<IDatabaseService, DatabaseService>();
builder.Services.AddScoped<IGetAdoptantListQuery, GetAdoptantListQuery>();
builder.Services.AddScoped<IGetAttendantListQuery, GetAttendantListQuery>();
builder.Services.AddScoped<IGetPetCardDetailQuery, GetPetCardDetailQuery>();
builder.Services.AddScoped<IGetPetCardsListQuery, GetPetCardsListQuery>();
builder.Services.AddScoped<IGetPetListQuery, GetPetListQuery>();
builder.Services.AddScoped<ICreatePetCardCommand, CreatePetCardCommand>();

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
