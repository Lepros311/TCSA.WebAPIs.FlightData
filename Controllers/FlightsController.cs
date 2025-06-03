using Microsoft.AspNetCore.Mvc;
using TCSA.WebAPIs.FlightData.Services;
using TCSA.WebAPIs.FlightData.Models;

namespace TCSA.WebAPIs.FlightData.Controllers;

[Route("api/[controller]")]
// example: http://localhost:5609/api/flight

public class FlightController(IFlightService flightService) : ControllerBase
{
    private readonly IFlightService _flightService = flightService;

    [HttpGet]
    public ActionResult<List<Flight>> GetAllFlights()
    {
        return Ok(_flightService.GetFlights());
    }

    [HttpGet("{id}")]
    public ActionResult<Flight> GetFlightById(int id)
    {
        var result = _flightService.GetFlightById(id);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPost]
    public ActionResult<Flight> CreateFlight(Flight flight)
    {
        return Ok(_flightService.CreateFlight(flight));
    }

    [HttpPut]
    public ActionResult<Flight> UpdateFlight(Flight flight)
    {
        var result = _flightService.GetFlightById(flight.Id);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public ActionResult<Flight> DeleteFlight(int id)
    {
        var result = _flightService.DeleteFlight(id);

        if (result == null)
        {
            return NotFound();
        }

        return Ok(result);
    }
}
