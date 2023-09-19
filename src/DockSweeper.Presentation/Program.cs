// // Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// // Licensed under the GNU General Public License v3.0.
// // See the LICENSE file in the project root for more information.

using DockSweeper.Application.Abstractions;
using DockSweeper.Application.Abstractions.Docker;
using DockSweeper.Infrastructure.Services;
using DockSweeper.Infrastructure.Services.Docker;
using DockSweeper.UseCases.Containers.Queries;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetContainersQuery>());

builder.Services
    .AddSingleton<IOperatingSystemService, OperatingSystemService>()
    .AddSingleton<IDockerClientFactory, DockerClientFactory>()
    ;

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("Open");
}

app.UseAuthorization();

app.MapControllers();

app.Run();