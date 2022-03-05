using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _2019AM606.models
{
    public class Pedidos
    {

        [Key]
        public int id { get; set; }
        public int idCliente { get; set; }
        public DateTime FechaPedido { get; set; }
    }
}
