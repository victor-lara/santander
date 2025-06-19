using Santander.Api.Interfaces;
using Santander.Api.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddHttpClient<IHackerNewsService, HackerNewsService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    // This is a simple API, but can include Swagger UI to see documentation on dev env.
}

app.UseHttpsRedirection();
app.MapControllers();
app.MapOpenApi();
app.Run();
