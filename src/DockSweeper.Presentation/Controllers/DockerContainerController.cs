// // Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// // Licensed under the GNU General Public License v3.0.
// // See the LICENSE file in the project root for more information.

using Docker.DotNet.Models;
using DockSweeper.Application.Abstractions.Docker;
using Microsoft.AspNetCore.Mvc;

namespace DockSweeper.Presentation.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class DockerContainerController
    : ControllerBase
{
    private readonly IDockerClientFactory _dockerClientFactory;
    private readonly ILogger<DockerContainerController> _logger;

    public DockerContainerController(
        ILogger<DockerContainerController> logger,
        IDockerClientFactory dockerClientFactory)
    {
        _logger = logger
                  ?? throw new ArgumentNullException(nameof(logger));
        _dockerClientFactory = dockerClientFactory
                               ?? throw new ArgumentNullException(nameof(dockerClientFactory));
    }

    [HttpGet(Name = "GetDockerContainers")]
    public async Task<ActionResult<IEnumerable<ContainerListResponse>>> Get([FromQuery] int limit = 10,
        [FromQuery] bool all = true)
    {
        try
        {
            var dockerClient = _dockerClientFactory.GetDockerClient();

            _logger.LogInformation("Client connected with configuration : {@configuration}",
                dockerClient.Configuration.EndpointBaseUri);

            var containers = await dockerClient.Containers.ListContainersAsync(
                new ContainersListParameters
                {
                    Limit = limit,
                    All = all
                });

            return Ok(containers);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to get docker containers");
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }
}