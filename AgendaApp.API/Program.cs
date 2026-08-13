using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Criando a política de Cors
builder.Services.AddCors(c => c.AddPolicy("DefaultPolicy", builder =>
{
    builder.WithOrigins("http://localhost:4200")
           .AllowAnyHeader()
           .AllowAnyMethod();
}));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//Swagger
app.UseSwagger();
app.UseSwaggerUI();

//Scalar
app.MapScalarApiReference(s => s.WithTheme(ScalarTheme.BluePlanet));

//Executando a política de Cors
app.UseCors("DefaultPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
