using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RP_PELICULAS__Ejercicio3_.Data;
using RP_PELICULAS__Ejercicio3_.Modelos;

namespace RP_PELICULAS__Ejercicio3_.Pages.Peliculas
{
    public class CreateModel : PageModel
    {
        private readonly RP_PELICULAS__Ejercicio3_.Data.RP_PELICULAS__Ejercicio3_Context _context;

        public CreateModel(RP_PELICULAS__Ejercicio3_.Data.RP_PELICULAS__Ejercicio3_Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Pelicula Pelicula { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Pelicula.Add(Pelicula);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
