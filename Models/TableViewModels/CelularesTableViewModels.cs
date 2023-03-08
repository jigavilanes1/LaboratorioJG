using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LaboratorioJG.Models.TableViewModels
{
    public class CelularesTableViewModels
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public decimal Precio { get; set; }
        public string Operadora { get; set; }
    }
}