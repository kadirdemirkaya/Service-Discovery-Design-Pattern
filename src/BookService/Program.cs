using BookService.Data;
using BookService.Seeds;
using Microsoft.EntityFrameworkCore;
using Steeltoe.Common.Discovery;
using Steeltoe.Discovery.Client;
using Steeltoe.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BookDbContext>(o => o.UseInMemoryDatabase("BookDbContext"));

var sp = builder.Services.BuildServiceProvider();
await BookSeedContext.SeedAsync(sp.GetRequiredService<BookDbContext>());

builder.Services.AddDiscoveryClient(builder.Configuration);

builder.Services.AddSingleton<DiscoveryHttpClientHandler>();

builder.Services.AddHealthChecks();
//docker run --name Eureka --publish 8761:8761 steeltoeoss/eureka-server,

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseHealthChecks("/healthcheck");

app.Run();
