using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _2019AM606.models
{
    public class Productos
    {

        [Key]
        public int id { get; set; }
        public string Producto { get; set; }
        public decimal precio { get; set; }
    }
}
