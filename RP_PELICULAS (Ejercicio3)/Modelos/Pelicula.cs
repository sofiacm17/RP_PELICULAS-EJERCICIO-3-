using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RP_PELICULAS__Ejercicio3_.Modelos
{
    public class Pelicula
    {
        public int ID { get; set; }

        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Display(Name = "Género")]
        public string Genero { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal Precio { get; set; }

        [DataType(DataType.Date)] //va a mostrar solo la fecha en la página web creada
        [Display(Name = "Fecha de lanzamiento")] //con este atributo cambiamos el nombre del campo que va a visualizar el usuario
        public DateTime FechaLanzamiento { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }  
            
    }
    
}
