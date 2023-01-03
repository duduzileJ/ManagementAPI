using Microsoft.EntityFrameworkCore;
using ManagementAPI.Data;
using Microsoft.AspNet.OData.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ManagementDb>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ManagementDb")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOData();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
//app.UseODataQueryOptions();

app.UseAuthorization();

app.MapControllers();

app.Run();
