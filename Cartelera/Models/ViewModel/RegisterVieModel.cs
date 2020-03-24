using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cartelera.Models.ViewModel
{
    public class RegisterVieModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAdress]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Usuario")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
