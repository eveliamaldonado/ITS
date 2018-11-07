using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ITS.Models;

namespace ITS.Models
{
    public class ITSContext : DbContext
    {
        public ITSContext (DbContextOptions<ITSContext> options)
            : base(options)
        {
        }

        public DbSet<ITS.Models.Datos_personales> Datos_personales { get; set; }

        public DbSet<ITS.Models.Tipo_usuario> Tipo_usuario { get; set; }
    }
}
