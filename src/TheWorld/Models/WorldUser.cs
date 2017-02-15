using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace TheWorld.Models
{
  public class WorldUser : IdentityUser
  {
    public DateTime FirstTrip { get; set; }

    //Other email and password and traditional user fields are inherited from IdentityUser
  }
}
