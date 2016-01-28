using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Garage2.Models
{
    public class VehiclesDb : DbContext
    {
        public DbSet<vehicle> vehicles { get; set; }
    
        public DbSet<Member> Members { get; set; }
        public DbSet<VehicleType > VehicleTypes { get; set; }
    }
}