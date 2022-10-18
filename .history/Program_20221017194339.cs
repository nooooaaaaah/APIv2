using Microsoft.EntityFrameworkCore;
using APIv2.models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddSqlServer<NyapolaDBContext>("Data Source=BusCISSQL1901.busdom.colostate.edu\\cisweb; Database=NyapolaDB; User ID=ibmblu; Password=first; TrustServerCertificate=True");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
