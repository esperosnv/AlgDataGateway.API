using CalculationHostedService;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<IProducer, Producer>();
builder.Services.AddHostedService<Listener>();

//builder.Services.AddScoped<ICalculation, Calculation>();



var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
