using ECommerceShop.Application;
using ECommerceShop.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

{
    builder.Services.AddControllers();
    builder.Services.ConfigureApplicationServices();
    builder.Services.ConfigureInfrastructureServices(builder.Configuration);
    builder.Services.AddCors();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
{
    app.UseCors(options => options
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
        .SetIsOriginAllowed(b => true));

    app.UseAuthentication();
    app.UseAuthorization();

    app.InfrastructureConfiguration();

    app.UseExceptionHandler("/error");
    app.UseStaticFiles();
    //app.UseHttpsRedirection();

    app.MapControllers();

    app.Run();
}
