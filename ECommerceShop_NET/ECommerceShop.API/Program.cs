using ECommerceShop.Application;
using ECommerceShop.Infrastructure;
using ECommerceShop.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

{
    builder.Services.AddControllers();
    builder.Services.ConfigureApplicationServices();
    builder.Services.ConfigureInfrastructureServices(builder.Configuration);
    builder.Services.AddCors();
    builder.Services.AddSwaggerGen();
}

var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    using (var scope = app.Services.CreateScope())
//    {
//        var salesContext = scope.ServiceProvider.GetRequiredService<ECommerceShopDbContext>();
//        salesContext.Database.EnsureCreated();
//    }
//}

app.UseSwagger();
app.UseSwaggerUI();

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
