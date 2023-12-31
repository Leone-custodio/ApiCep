using ApiCep.Interface;
using ApiCep.Rest;
using ApiCep.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ICepService, CepService>();
builder.Services.AddSingleton<IBancoService, BancoService>();
builder.Services.AddSingleton<IApiService, ApiRest>();

builder.Services.AddAutoMapper(typeof(CepService));
builder.Services.AddAutoMapper(typeof(BancoService));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
