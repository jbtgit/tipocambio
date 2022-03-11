#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TipoCambioAPI.Models;

namespace tipocambioapi.Data
{
    public class tipocambioapiContext : DbContext
    {
        public tipocambioapiContext (DbContextOptions<tipocambioapiContext> options)
            : base(options)
        {
        }

        public DbSet<TipoCambioAPI.Models.TipoCambio> TipoCambio { get; set; }
    }
}
