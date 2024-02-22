using backend.Interfaces;
using backend.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers(config =>
 {
   config.CacheProfiles.Add("30SecondsCaching", new CacheProfile
   {
     Duration = 30
   });
 })
      // configure controller to use Newtonsoft as a default serializer
      .AddNewtonsoftJson(options =>
         options.SerializerSettings.ReferenceLoopHandling = Newtonsoft
             .Json.ReferenceLoopHandling.Ignore)
                 .AddNewtonsoftJson(options => options.SerializerSettings.ContractResolver
                     = new DefaultContractResolver());

builder.Services.AddCors(options =>
{
  options.AddPolicy(name: configuration["CorsName"], build =>
  {
    build.WithOrigins(configuration["AllowedHosts"])
        .AllowAnyHeader()
        .AllowAnyMethod();

  });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ILoadFile, LoadFileService>();
builder.Services.AddScoped<ISticker, StickerService>();
builder.Services.AddSingleton<ObjectStorageService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(configuration["CorsName"]);

// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
