using Microsoft.AspNetCore.Mvc;
using MediatR;
using ActivitiesCQRS.Mediator.Commands;
using ActivitiesCQRS.Mediator.Queries;


namespace ActivitiesCQRS.Controllers;

[ApiController]
[Route("[controller]")]
public class ActivityController : ControllerBase
{
    private readonly IMediator mediator;

    public ActivityController(IMediator mediator)
    {
        this.mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var query = new GetActivityByIdQuery() { Id = id };
        return Ok(await mediator.Send(query));
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllActivityQuery() { };
        return Ok(await mediator.Send(query));
    }


    [HttpPost("Add")]
    public async Task<IActionResult> Add(CreateActivityCommand command)
    {
        return Ok(await mediator.Send(command));
    }

    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteActivityCommand() { Id = id };
        return Ok(await mediator.Send(command));
    }

    //[HttpPut("Update/{id}")]
    //public async Task<IActionResult> Update(Guid id)
    //{
    //    var command = new UpdateActivityCommand() { Id = id, };
    //    return Ok(await mediator.Send(command));
    //}

    [HttpPut("Update")]
    public async Task<IActionResult> Update(UpdateActivityCommand command)
    {
        return Ok(await mediator.Send(command));
    }




}