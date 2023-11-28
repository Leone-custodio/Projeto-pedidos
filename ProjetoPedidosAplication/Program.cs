using ProjetoPedidosBusiness.Commands.Handlers;
using ProjetoPedidosInfra.Data;
using ProjetoPedidosInfra.Interfaces;
using ProjetoPedidosInfra.Repositories;
using ProjetoPedidosService.Interfaces;
using ProjetoPedidosService.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
DbProjectContext.ConnectionString = builder.Configuration.GetSection("MongoConnection:ConnectionString").Value;
DbProjectContext.DatabaseName = builder.Configuration.GetSection("MongoConnection:DatabaseName").Value;
DbProjectContext.IsSSL = Convert.ToBoolean(builder.Configuration.GetSection("MongoConnection:IsSSL").Value);

builder.Services.AddScoped<DbProjectContext>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<UserHandler, UserHandler>();

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
