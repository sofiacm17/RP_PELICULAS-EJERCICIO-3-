using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RP_PELICULAS__Ejercicio3_.Modelos;

namespace RP_PELICULAS__Ejercicio3_.Data
{
    public class RP_PELICULAS__Ejercicio3_Context : DbContext
    {
        public RP_PELICULAS__Ejercicio3_Context (DbContextOptions<RP_PELICULAS__Ejercicio3_Context> options)
            : base(options)
        {
        }

        public DbSet<RP_PELICULAS__Ejercicio3_.Modelos.Pelicula> Pelicula { get; set; }
    }
}
