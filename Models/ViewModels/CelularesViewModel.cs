using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Web.UI.WebControls;
using System.ComponentModel.DataAnnotations.Schema;

namespace LaboratorioJG.Models.ViewModels
{
    public class CelularesViewModel
    {
        [Required]
        [Display(Name = "Ingrese el modelo")]
        [StringLength(60, MinimumLength = 3)]
        public string Modelo { get; set; }

        [Required]
        [Display(Name = "Ingrese la marca")]
        [StringLength(60, MinimumLength = 3)]
        public string Marca { get; set; }

        [Required]
        [Display(Name = "Ingrese el Precio")]
        public decimal Precio { get; set; }

        [Required]
        [Display(Name = "Seleccione la Operadora")]
        public int IdOperadora { get; set; }
        public string Operadora { get; set; }
    }

    public class EditarCelularesViewModels
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Ingrese el modelo")]
        [StringLength(60, MinimumLength = 3)]
        public string Modelo { get; set; }

        [Required]
        [Display(Name = "Ingrese la marca")]
        [StringLength(60, MinimumLength = 3)]
        public string Marca { get; set; }

        [Required]
        [Display(Name = "Ingrese el Precio")]
        public decimal Precio { get; set; }

        [Required]
        [Display(Name = "Seleccione la Operadora")]
        public int IdOperadora { get; set; }
        public string Operadora { get; set; }
    }
}
