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
    public class IndexModel : PageModel
    {
        private readonly RP_PELICULAS__Ejercicio3_.Data.RP_PELICULAS__Ejercicio3_Context _context;

        public IndexModel(RP_PELICULAS__Ejercicio3_.Data.RP_PELICULAS__Ejercicio3_Context context)
        {
            _context = context;
        }

        public IList<Pelicula> Pelicula { get;set; }
        [BindProperty(SupportsGet = true)]
        public string searchstring { get; set; } //variable que se va a utilizar para guardar lo que el usuario ponga en el buscador
        public SelectList genero { get; set; } //lista con géneros

        [BindProperty(SupportsGet = true)]
        public string generoPelicula { get; set; } //va a ser el valor que elija el usuario al seleccionar un género de la lista.
     

        public async Task OnGetAsync()
        {
       
            var peliculas = from n in _context.Pelicula
                            select n;
            
            if (!string.IsNullOrEmpty(searchstring))
            {
                peliculas = peliculas.Where(S => S.Titulo.Contains(searchstring));
            }
            IQueryable<string> generoQuery = from m in _context.Pelicula
                                             orderby m.Genero
                                             select m.Genero;

            if (!string.IsNullOrEmpty(generoPelicula))
            {
                peliculas = peliculas.Where(s => s.Genero == generoPelicula);
            }

            genero = new SelectList(await generoQuery.Distinct().ToListAsync());
            Pelicula = await peliculas.ToListAsync();
        }
    }
}
