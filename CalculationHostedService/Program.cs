using CalculationHostedService;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddTransient<IProducer, Producer>();
builder.Services.AddHostedService<Listener>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
