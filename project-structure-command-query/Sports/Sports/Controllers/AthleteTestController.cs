using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sports.Command;
using Sports.Query;
using Sports.Query.Test;

namespace Sports.Controllers
{
  [Route("api/[controller]")]
  public class AthleteTestController : Controller
  {
    private readonly IMediator _mediator = null;
    private readonly ILogger<AthleteTestController> _logger = null;
    public AthleteTestController(ILogger<AthleteTestController> logger, IMediator mediator)
    {
      _mediator = mediator;
      _logger = logger;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<bool>> Create(CreateTestCommand command)
    {
      var isSucceed = false;
      try
      {
        CreateTestCommandValidator validator = new CreateTestCommandValidator();
        var result = validator.Validate(command);
        if (!result.IsValid)
        {
          string errors = result.Errors.Select(x => x.ErrorMessage).Aggregate((x, y) => x + ", " + y);
          _logger.LogError(errors);
          return BadRequest(errors);
        }

        isSucceed = await _mediator.Send<bool>(command);

        return Ok(isSucceed);
      }
      catch (Exception ex)
      {
        _logger.LogError(ex, ex.Message);
        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
      }
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<List<TestViewModel>>> GetAllTests()
    {
      try
      {
        return Ok(await _mediator.Send<IEnumerable<TestViewModel>>(new FetchAllTestsQuery()));
      }
      catch (System.Exception ex)
      {
        _logger.LogError(ex, ex.Message);
        return StatusCode(StatusCodes.Status500InternalServerError, new { err = "some error occired while getting test records" });
      }

    }
  }
}
