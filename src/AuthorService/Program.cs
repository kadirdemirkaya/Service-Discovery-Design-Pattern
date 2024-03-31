using AuthorService.Data;
using AuthorService.Seeds;
using Microsoft.EntityFrameworkCore;
using Steeltoe.Common.Discovery;
using Steeltoe.Discovery.Client;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AuthorDbContext>(o => o.UseInMemoryDatabase("AuthorDbContext"));

var sp = builder.Services.BuildServiceProvider();
await AuthorSeedContext.SeedAsync(sp.GetRequiredService<AuthorDbContext>());

builder.Services.AddDiscoveryClient(builder.Configuration);

builder.Services.AddSingleton<DiscoveryHttpClientHandler>();

builder.Services.AddHealthChecks();

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
