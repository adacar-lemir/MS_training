var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => { });

var app = builder.Build();

app.UseCors("some unique string");

app.MapGet("/", () => "Hello World!");

app.Run();
