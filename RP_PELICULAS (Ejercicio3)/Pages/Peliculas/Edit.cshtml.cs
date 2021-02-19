using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RP_PELICULAS__Ejercicio3_.Data;
using RP_PELICULAS__Ejercicio3_.Modelos;

namespace RP_PELICULAS__Ejercicio3_.Pages.Peliculas
{
    public class EditModel : PageModel
    {
        private readonly RP_PELICULAS__Ejercicio3_.Data.RP_PELICULAS__Ejercicio3_Context _context;

        public EditModel(RP_PELICULAS__Ejercicio3_.Data.RP_PELICULAS__Ejercicio3_Context context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Pelicula).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeliculaExists(Pelicula.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PeliculaExists(int id)
        {
            return _context.Pelicula.Any(e => e.ID == id);
        }
    }
}
