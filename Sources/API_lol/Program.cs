using Microsoft.AspNetCore.Mvc.Versioning;
using Model;
using StubLib;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IDataManager, StubData>(); 
//builder.Services.AddScoped<IDataManager, EFManager>();

//AddScoped : l'instance de l'objet est supprimée et rechargée en memoire --> les objets ne sont donc pas supprimés, modifiés,etc

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// API Version
// builder.Services.AddApiVersioning(opt =>
// {
//     opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
//     opt.AssumeDefaultVersionWhenUnspecified = true;
//     opt.ReportApiVersions = true;
//     opt.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader());
// });

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
