using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cartelera.Models.ViewModel
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; }

        [Required]
        [MaxLength(150)]
        public string Descripcion { get; set; }

        [Required]
        public string FuerdeStock { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public double Precio { get; set; }
    }
}
