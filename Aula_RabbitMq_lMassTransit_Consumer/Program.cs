using Aula_RabbitMq_lMassTransit_Consumer.Service;
using MassTransit;
using static Aula_RabbitMq_lMassTransit_Consumer.Service.ClienteRegistrado;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddMassTransit(c =>
{
    c.AddConsumer<ClienteRegistrado>();

    c.UsingRabbitMq((context, config) =>
    {
        config.ReceiveEndpoint("User_Created", e => // Use o nome da sua fila aqui
        {
            e.ConfigureConsumer<ClienteRegistrado>(context); // Configure o consumidor
            e.UseConsumeFilter<CpfFilter>(context);
        });
    });
});

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
