using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RP_PELICULAS__Ejercicio3_.Data;
using RP_PELICULAS__Ejercicio3_.Modelos;

namespace RP_PELICULAS__Ejercicio3_.Pages.Peliculas
{
    public class DetailsModel : PageModel
    {
        private readonly RP_PELICULAS__Ejercicio3_.Data.RP_PELICULAS__Ejercicio3_Context _context;

        public DetailsModel(RP_PELICULAS__Ejercicio3_.Data.RP_PELICULAS__Ejercicio3_Context context)
        {
            _context = context;
        }

        public Pelicula Pelicula { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pelicula = await _context.Pelicula.FirstOrDefaultAsync(m => m.ID == id);

            if (Pelicula == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
