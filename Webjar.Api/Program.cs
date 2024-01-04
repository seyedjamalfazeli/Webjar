using Microsoft.OpenApi.Models;
using Webjar.Application;
using Webjar.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.ConfigureApplicationServices();
builder.Services.ConfigurePersistenceServices(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o =>
	o.SwaggerDoc("v1", new OpenApiInfo()
	{
		Version = "v1",
		Title = "Webjar Task Api",
	}));

builder.Services.AddCors(o =>
{
	o.AddPolicy("CorsPolicy", b =>
	b.AllowAnyOrigin()
	.AllowAnyMethod()
	.AllowAnyHeader()
	);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.UseCors("CorsPolicy");

app.Run();
