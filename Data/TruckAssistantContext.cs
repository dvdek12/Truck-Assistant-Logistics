using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TruckAssistant.Models;

namespace TruckAssistant.Data
{
    public class TruckAssistantContext : DbContext
    {
        public TruckAssistantContext (DbContextOptions<TruckAssistantContext> options)
            : base(options)
        {
        }
        public DbSet<TruckAssistant.Models.Trip> Trip { get; set; } = default!;
        public DbSet<TruckAssistant.Models.Truck> Truck { get; set; } = default!;
    }
}
