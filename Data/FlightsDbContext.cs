using Microsoft.EntityFrameworkCore;
using TCSA.WebAPIs.FlightData.Models;

namespace TCSA.WebAPIs.FlightData.Data;

public class FlightsDbContext: DbContext
{
    public FlightsDbContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Flight> Flights { get; set; }
}
