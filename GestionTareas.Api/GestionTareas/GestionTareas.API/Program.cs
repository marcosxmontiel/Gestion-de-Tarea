using GestionTareas.Data.Entity;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("MiDB");
builder.Services.AddDbContext<ControlTareasContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddControllers(options =>
{
    options.RequireHttpsPermanent = true;
    options.RespectBrowserAcceptHeader = true;
    //options.OutputFormatters.RemoveType<StringOutputFormatter>();
    //options.OutputFormatters.RemoveType<HttpNoContentOutputFormatter>();
}).AddXmlSerializerFormatters();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowWebApp", 
        builder => builder.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod());
});

var app = builder.Build();

app.UseCors("AllowWebApp");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();