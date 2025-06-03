using TCSA.WebAPIs.FlightData.Data;
using TCSA.WebAPIs.FlightData.Models;

namespace TCSA.WebAPIs.FlightData.Services;

public interface IFlightService
{
    public List<Flight> GetFlights();
    public Flight? GetFlightById(int id);
    public Flight CreateFlight(Flight flight);
    public Flight UpdateFlight(Flight updatedFlight);
    public string? DeleteFlight(int id);
}

public class FlightService : IFlightService
{
    private readonly FlightsDbContext Context;

    public FlightService(FlightsDbContext context)
    {
        Context = context;
    }

    public Flight CreateFlight(Flight flight)
    {
        var savedFlight = Context.Flights.Add(flight);
        Context.SaveChanges();
        return savedFlight.Entity;
    }

    public string? DeleteFlight(int id)
    {
        Flight savedFlight = Context.Flights.Find(id);
        Context.SaveChanges();

        if (savedFlight == null)
        {
            return null;
        }

        Context.Flights.Remove(savedFlight);

        return $"Successfully deleted flight with id: {id}";
    }

    public List<Flight> GetFlights()
    {
        return Context.Flights.ToList();
    }

    public Flight? GetFlightById(int id)
    {
        Flight savedFlight = Context.Flights.Find(id);
        return savedFlight == null ? null : savedFlight;
    }

    public Flight UpdateFlight(Flight flight)
    {
        Flight savedFlight = Context.Flights.Find(flight.Id);

        if (savedFlight == null)
        {
            return null;
        }

        Context.Entry(savedFlight).CurrentValues.SetValues(flight);
        Context.SaveChanges();

        return savedFlight;
    }
}
