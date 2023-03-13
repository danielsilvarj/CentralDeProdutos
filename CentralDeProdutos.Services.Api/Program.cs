using CentralDeProdutos.Services.Api.Setups;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

AutoMapperSetup.Configure(builder);
CorsSetup.Configure(builder);
DependencyInjectionSetup.Configure(builder);
SwaggerSetup.Configure(builder);


var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI();

CorsSetup.Use(app);

app.UseAuthorization();

app.MapControllers();

app.Run();
