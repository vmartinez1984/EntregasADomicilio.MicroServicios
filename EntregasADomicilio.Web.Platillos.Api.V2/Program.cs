using EntregasADomicilio.StoreFiles;
using EntregasADomicilio.Web.Platillos.Api.V2.Interfaces;
using EntregasADomicilio.Web.Platillos.Api.V2.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IRepositorio, Repositorio>();
builder.Services.AddScoped<IPlatillo, PlatilloRepositorio>();
builder.Services.AddScoped<ICategoria, CategoriaRepositorio>();
builder.Services.AddScoped<ITienda, TiendaRepositorio>();

builder.Services.AddScoped<AlmacenDeArchivosFirebase>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
