using Backend.BusinessLogic.FacadeSystem.ProductFacade;
using Backend.BusinessLogic.FacadeSystem.UserFacade.Login;
using Backend.BusinessLogic.FacadeSystem.UserFacade.Register;
using Backend.BusinessLogic.Factory;
using Backend.CommonDomain.Product;
using Backend.Database;
using Backend.Repositories;
using Backend.Services;

internal class Program
{
  private static void Main(string[] args)
  {
    var builder = WebApplication.CreateBuilder(args);
    builder.Services.AddCors(options =>
    {
      options.AddPolicy("AllowAll", policy =>
          {
          policy
                  .AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
    });



    builder.Services.AddControllers();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddSingleton<DataBase>();//Database database = new Database();
    builder.Services.AddSingleton<FacadeLogin>();// FacadeLogin facadeLogin = new FacadeLogin(database);
    builder.Services.AddSingleton<RegisterUserFacade>();// RegisterUserFacade registerUserFacade = new FacadeLogin(database);
    builder.Services.AddSingleton<HashingService>();// HashingService hashingService = new HashingService();
    builder.Services.AddSingleton<UserRepository>();
    builder.Services.AddSingleton<UserFactory>();
    builder.Services.AddSingleton<ProductFactory>();
    builder.Services.AddSingleton<ProductRepository>();
    builder.Services.AddSingleton<CreateProductFacade>();

        var app = builder.Build();
    app.UseCors("AllowAll");

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

  }
}