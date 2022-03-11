using Application.Extensions;
using Serilog;
using WebApi.Extensions;
using Persistence.Extensions;
using Shared.Extensions;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
     //Read from your appsettings.json.
     .AddJsonFile("appsettings.json")
     //Read from your secrets.
    .AddUserSecrets<Program>(optional: true)
    .AddEnvironmentVariables()
    .Build();

builder.Services.AddSerilogLayer(configuration);

try
{
    // Add services to the container.
    builder.Services.AddAplicationLayer();
    builder.Services.AddPersistenceInfraestructure(configuration);
    builder.Services.AddShardInfraestructure(configuration);

    builder.Services.AddControllers();

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddApiVersion();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.UseErrorHandlerMiddleware();
    app.MapControllers();
    app.Run();
}
catch (Exception exception)
{
    Log.Fatal(exception, "Host terminated unexpectedly");
    return 1;
}
finally
{
    Log.CloseAndFlush();
}

return 0;