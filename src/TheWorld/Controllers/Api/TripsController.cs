using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheWorld.Models;
using TheWorld.ViewModels;

namespace TheWorld.Controllers.Api
{
  [Route("api/trips")]
  public class TripsController : Controller
  {
    private IWorldRepository _repository;
    private ILogger<TripsController> _logger;
    public TripsController(IWorldRepository repository, ILogger<TripsController> logger)
    {
      _repository = repository;
      _logger = logger;
    }

    [HttpGet("")]
    public IActionResult Get()
    {
      try
      {
        var results = _repository.GetTripsByUsername(this.User.Identity.Name);
        return Ok(Mapper.Map<IEnumerable<TripViewModel>>(results));
      }
      catch (Exception ex)
      {

        _logger.LogError("Failed to get All Trips", ex.Message);

        return BadRequest("Error Occured " + ex.Message);
      }
    }

    [HttpPost("")]
    public async Task<IActionResult> Post([FromBody]TripViewModel theTrip)
    {
      if (ModelState.IsValid)
      {
        //Save to the database.
        var newTrip = Mapper.Map<Trip>(theTrip);

        newTrip.UserName = User.Identity.Name;

        if (await _repository.SaveChangesAsync())
        {
          return Created($"api/trips/{theTrip.Name}", Mapper.Map<TripViewModel>(newTrip));
        }
        else
        {
          return BadRequest("Failed to save changes to the database");
        }

      }

      return BadRequest("Bad Data");
    }
  }
}
