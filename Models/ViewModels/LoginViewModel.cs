using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace LaboratorioJG.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Ingrese el usuario")]
        public string Usuario { get; set; }

        [Required]
        [Display(Name = "Ingrese la contraseña")]
        public string Clave { get; set; }
    }
}