// // Copyright (c) Alexis Chân Gridel. All Rights Reserved.
// // Licensed under the GNU General Public License v3.0.
// // See the LICENSE file in the project root for more information.

using System.ComponentModel.DataAnnotations;
using DockSweeper.Application.Containers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DockSweeper.Presentation.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class DockerContainerController
    : ControllerBase
{
    private readonly ILogger<DockerContainerController> _logger;
    private readonly IMediator _mediator;

    public DockerContainerController(
        ILogger<DockerContainerController> logger,
        IMediator mediator)
    {
        _logger = logger
                  ?? throw new ArgumentNullException(nameof(logger));
        _mediator = mediator
                    ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpGet(Name = "GetDockerContainers")]
    public async Task<IActionResult> Get(
        [FromQuery] [Range(1, 100)] int limit = 10,
        [FromQuery] bool all = false)
    {
        try
        {
            var containers = await _mediator.Send(
                new GetContainersQuery(limit, all),
                HttpContext.RequestAborted);

            _logger.LogInformation("Got {Count} docker containers", containers.Count());

            return containers.Match<IActionResult>(
                Ok,
                NotFound);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed to get docker containers");
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }
}