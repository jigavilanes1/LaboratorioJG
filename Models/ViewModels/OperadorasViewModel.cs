using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace LaboratorioJG.Models.ViewModels
{
    public class OperadorasViewModel
    {
        [Required]
        [Display(Name = "Ingrese el nombre")]
        [StringLength(60, MinimumLength = 3)]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Ingrese el anio")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "int(18, 2)")]
        public int Anio { get; set; }

    }

    public class EditarOperadorasViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Ingrese el nombre")]
        [StringLength(60, MinimumLength = 3)]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Ingrese el anio")]
        [DataType(DataType.Currency)]
        [Column(TypeName = "int(18, 2)")]
        public int Anio { get; set; }
    }
}