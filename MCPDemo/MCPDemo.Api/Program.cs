using MCPDemo.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<IContext, CovidDataDbContext>(options =>
{
    var host = builder.Configuration["SqlServer:Host"];
    var databaseName = builder.Configuration["SqlServer:DatabaseName"];
    var clientId = builder.Configuration["ClientId"];
    var clientSecret = builder.Configuration["ClientPassword"];

    var connectionString = @$"
        Server=tcp:{host},1433;Initial Catalog={databaseName};User ID={clientId};Password='{clientSecret}';
        Persist Security Info=False; MultipleActiveResultSets=False;Connection Timeout=30;TrustServerCertificate=False;
        Authentication='Active Directory Service Principal'";
    
    options.UseSqlServer(connectionString);
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.UseRouting();
app.UseHttpsRedirection();

app.MapGet("/api/healthz", () => Results.Ok(Environment.GetEnvironmentVariable("CONTAINER_VERSION")));
app.MapControllers();

app.Run();