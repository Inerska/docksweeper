using DockSweeper.Application.Abstractions;
using DockSweeper.Application.Abstractions.Docker;
using DockSweeper.Infrastructure.Services;
using DockSweeper.Infrastructure.Services.Docker;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});


builder.Services
    .AddSingleton<IOperatingSystemService, OperatingSystemService>()
    .AddSingleton<IDockerClientFactory, DockerClientFactory>();
    ;

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("Open");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();