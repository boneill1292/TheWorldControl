using System.Collections.Generic;
using System.Threading.Tasks;

namespace TheWorld.Models
{
  public interface IWorldRepository
  {
    IEnumerable<Trip> GetAllTrips();
    IEnumerable<Trip> GetTripsByUsername(string username);

    Trip GetTripByName(string tripName);

    void AddTrip(Trip trip);

    Task<bool> SaveChangesAsync();

    void AddStop(string tripName, Stop newStop, string username);


    Trip GetUserTripByName(string tripName, string identityName);
  }
}