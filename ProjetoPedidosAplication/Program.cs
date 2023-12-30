using MediatR;
using ProjetoPedidosBusiness.Handlers.OrderHandler;
using ProjetoPedidosBusiness.Handlers.ProductHandler;
using ProjetoPedidosBusiness.Handlers.UserHandler;
using ProjetoPedidosBusiness.Requests.OrderRequests;
using ProjetoPedidosBusiness.Requests.ProductRequests;
using ProjetoPedidosBusiness.Requests.UserRequests;
using ProjetoPedidosInfra.Data;
using ProjetoPedidosInfra.Interfaces;
using ProjetoPedidosInfra.Repositories;
using ProjetoPedidosService.Interfaces;
using ProjetoPedidosService.Services;

var builder = WebApplication.CreateBuilder(args);

// MongoDb configuration

DbProjectContext.ConnectionString = builder.Configuration.GetSection("MongoConnection:ConnectionString").Value;
DbProjectContext.DatabaseName = builder.Configuration.GetSection("MongoConnection:DatabaseName").Value;
DbProjectContext.IsSSL = Convert.ToBoolean(builder.Configuration.GetSection("MongoConnection:IsSSL").Value);

// Add services to the container.

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(GetAllUsersHandler).Assembly, typeof(GetAllUsersRequest).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(ProductHandler).Assembly, typeof(CreateProductRequest).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateOrderHandler).Assembly, typeof(CreateOrderRequest).Assembly));
builder.Services.AddScoped<DbProjectContext>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<CreateUserHandler, CreateUserHandler>();
builder.Services.AddTransient<ProductHandler, ProductHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
