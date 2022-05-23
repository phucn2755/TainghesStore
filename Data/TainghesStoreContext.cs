using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TainghesStore.Models;

namespace TainghesStore.Data
{
    public class TainghesStoreContext : DbContext
    {
        public TainghesStoreContext (DbContextOptions<TainghesStoreContext> options)
            : base(options)
        {
        }

        public DbSet<TainghesStore.Models.Tainghe> Tainghe { get; set; }
    }
}
