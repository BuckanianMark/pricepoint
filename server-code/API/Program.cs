using API.Extensions;
using API.Helpers;
using API.Middleware;
using Core.Entities;
using Core.Entities.Identity;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Identity;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    var securitySchema = new OpenApiSecurityScheme
    {
          Description = "JWT Auth Bearer Scheme",
          Name = "Authorization",
          In = ParameterLocation.Header,
          Type = SecuritySchemeType.Http,
          Scheme = "Bearer",
          Reference = new OpenApiReference
          {
              Type = ReferenceType.SecurityScheme,
              Id = "Bearer"
          }
    };
    c.AddSecurityDefinition("Bearer", securitySchema);
    var securityRequirement =  new OpenApiSecurityRequirement
    {
    {
        securitySchema, new [] {"Bearer"}
    }
    };
    c.AddSecurityRequirement(securityRequirement);
});
//Adding database configurations
builder.Services.AddDbContext<StoreContext>(options => {
        options.UseSqlServer(builder.Configuration.GetConnectionString("PricepointMainDb"));
});
builder.Services.AddDbContext<AppIdentityDbContext>(x => {
    x.UseSqlServer(builder.Configuration.GetConnectionString("PricepointIdentityDb"));
});
builder.Services.AddIdentityServices(builder.Configuration);


builder.Services.AddSingleton<IConnectionMultiplexer>(c => {
    var configuration = ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("Redis"),true);
    return ConnectionMultiplexer.Connect(configuration);
});
builder.Services.AddScoped<ITokenService , TokenService>();
builder.Services.AddAutoMapper(typeof(MappingProfiles));
builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IBasketRepository,BasketRepository>();


var app = builder.Build();

var FileProviderPath = app.Environment.WebRootPath + "/Products";
if(!Directory.Exists(FileProviderPath))
{
    Directory.CreateDirectory(FileProviderPath);
}
app.UseFileServer(new FileServerOptions
{
    FileProvider = new PhysicalFileProvider(FileProviderPath),
    RequestPath= "/Products",
    EnableDirectoryBrowsing = true
});

using (var scope = app.Services.CreateScope()){
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    try
    {
       var context = services.GetRequiredService<StoreContext>();
       await context.Database.MigrateAsync(); 
    }
    catch (Exception ex)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex, "An error occured during migratio");
    }
}

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }
app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<ExceptionMiddleware>();

app.UseStatusCodePagesWithReExecute("/errors/{0}");

app.UseHttpsRedirection();

app.UseCors(options => 
{
    options.AllowAnyHeader();
    options.AllowAnyMethod();
    options.AllowAnyOrigin();
});


app.UseRouting();

app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
