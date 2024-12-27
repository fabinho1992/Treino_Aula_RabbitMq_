using Aula_RabbitMq_lMassTransit_Consumer.Service;
using Aula_RabbitMq_MassTransit.Service;
using E_Commerce_Shoes.Infraestrutura;
using E_Commerce_Shoes.Infraestrutura.Repositories;
using E_Commerce_Shoes.Services;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//DbContext
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ContextDb>(opt =>
                opt.UseSqlServer(connectionString));

//injeção de dependencia
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ICompraRepository, CompraRepository>();

//MassTransit
builder.Services.AddSingleton<IBusService, MassTransitBusService>();

builder.Services.AddSingleton<IBusService>(provider =>
    new MassTransitBusService(provider.GetRequiredService<IBus>(), provider.GetRequiredService<IConfiguration>()));

builder.Services.AddMassTransit(c =>
{
    c.AddConsumer<ClienteRegistrado>();

    c.UsingRabbitMq((context, config) =>
    {
        config.ReceiveEndpoint("User_Created", e => // Use o nome da sua fila aqui
        {
            config.ConfigureEndpoints(context);

            e.ConfigureConsumer<ClienteRegistrado>(context); // Configure o consumidor
        });
    });
});

builder.Services.AddMassTransitHostedService();

//CQRS Injection
var myHandlers = AppDomain.CurrentDomain.Load("E_Commerce_Shoes");
builder.Services.AddMediatR(config =>
    config.RegisterServicesFromAssembly(myHandlers));

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
