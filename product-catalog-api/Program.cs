using Microsoft.EntityFrameworkCore;
// using AutoMapper;
using product_catalog_api.Data.Repository;
using product_catalog_api.Data.Interface;
using Microsoft.Extensions.FileProviders;
using product_catalog_api.Data;
using product_catalog_api.Helpers;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


builder.Services.AddDbContext<MyDbContext>(options => 
        options.UseSqlServer(builder.Configuration.GetConnectionString("PricepointMainDb")));
builder.Services.AddAutoMapper(typeof(MappingProfiles));
builder.Services.AddTransient<IFileService,FileService>();
builder.Services.AddTransient<IProduct,ProductRepository>();



builder.Services.AddControllers();
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
app.UseCors(options => 
{
    options.AllowAnyHeader();
    options.AllowAnyMethod();
    options.AllowAnyOrigin();
});
app.UseRouting();
app.UseStaticFiles( new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(builder.Environment.ContentRootPath,"Uploads")),
        RequestPath = "/Uploads"
});

app.MapControllers();



app.Run();

