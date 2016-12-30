using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWorld.Models
{
    public class WorldContextSeedData
    {
        private WorldContext _context;
        public WorldContextSeedData(WorldContext context)
        {
            _context = context;
        }

        public async Task EnsureSeedData()
        {
            if (_context.Trips.Any())
            {
                var usTrip = new Trip()
                {
                    DateCreated = DateTime.Now,
                    Name = "US Trip",
                    UserName = "", //TODO Add Username
                    Stops = new List<Stop>()
                    {

                    }
                };

                _context.Trips.Add(usTrip);

                _context.Stops.AddRange(usTrip.Stops);

                var worldTrip = new Trip()
                {
                    DateCreated = DateTime.UtcNow,
                    Name = "WorldTrip",
                    UserName = "", //add
                    Stops = new List<Stop>()
                    {

                    }
                };

                _context.Trips.Add(worldTrip);

                _context.Stops.AddRange(worldTrip.Stops);

                //seeding the database 3:53

            }
        }
    }
}
