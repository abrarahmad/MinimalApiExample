using Contract.Common;
using Domain.Services.ExternalService;
using Domain.Services.Movie;
using Microsoft.EntityFrameworkCore;
using MinimalApi.APIs;
using Repository.Customer;
using Repository.Data;
using Repository.Movie;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StorageContext>(opt =>
{
    opt.UseInMemoryDatabase(databaseName: "StorageDb", action =>
    {
        action.EnableNullChecks();
    });
});

builder.Services.AddHttpClient<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();

builder.Services.Configure<Token>(
    builder.Configuration.GetSection(nameof(Token)));


var app = builder.Build();
var scope = app.Services.CreateAsyncScope();
await scope.ServiceProvider
           .GetRequiredService<StorageContext>()
           .GenerateCustomerAsync().ConfigureAwait(false);
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.RegisterMovieApi();
app.RegisterMockApi();
app.Run();