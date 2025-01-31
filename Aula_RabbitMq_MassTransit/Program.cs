using Aula_RabbitMq_MassTransit.Service;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IBusService, MassTransitBusService>();

builder.Services.AddSingleton<IBusService>(provider =>
    new MassTransitBusService(provider.GetRequiredService<IBus>(), provider.GetRequiredService<IConfiguration>()));

builder.Services.AddMassTransit(c =>
{
    c.UsingRabbitMq((context, config) =>
    {
        config.ConfigureEndpoints(context);
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
