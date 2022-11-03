using Microsoft.EntityFrameworkCore;
using APIv2.models;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SpielmanDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SpielmanDBContext") ?? throw new InvalidOperationException("Connection string 'SpielmanDBContext' not found.")));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSqlServer<SpielmanDBContext>("Data Source=BusCISSQL1901.busdom.colostate.edu\\cisweb; Database=SpielmanDB; User ID=angle; Password=jscript; TrustServerCertificate=True");
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            options.RoutePrefix = string.Empty;
        }
    );
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
