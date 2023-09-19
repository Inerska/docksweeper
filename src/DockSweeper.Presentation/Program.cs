// // Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// // Licensed under the GNU General Public License v3.0.
// // See the LICENSE file in the project root for more information.

using DockSweeper.Application.Abstractions;
using DockSweeper.Application.Abstractions.Docker;
using DockSweeper.Infrastructure.Services;
using DockSweeper.Infrastructure.Services.Docker;
using DockSweeper.UseCases.Containers.Queries;
using FastEndpoints;
using FastEndpoints.Swagger;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthorization();
builder.Services.AddFastEndpoints();
builder.Services.SwaggerDocument(o =>
{
    o.ShortSchemaNames = true;
});
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetContainersQuery>());

builder.Services
    .AddSingleton<IOperatingSystemService, OperatingSystemService>()
    .AddSingleton<IDockerClientFactory, DockerClientFactory>()
    ;

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseAuthorization();
app.UseFastEndpoints();
app.UseSwaggerGen();

app.Run();