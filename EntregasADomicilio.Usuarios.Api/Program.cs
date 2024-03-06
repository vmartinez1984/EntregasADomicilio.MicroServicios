using EntregasADomicilio.Usuarios.BusinessLayer.Helpers;
using JwtTokenService.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddUnitOfWork();
builder.Services.AddJwtAuthentication(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        //string frontEndUrl;

        //colocar la url en una variable uqe se lea desde appsetiings
        builder.WithOrigins("*")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .WithExposedHeaders("*");
    });
});

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Cliente", policy =>
    {
        policy.RequireClaim("Role", "Cliente");
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();


app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
