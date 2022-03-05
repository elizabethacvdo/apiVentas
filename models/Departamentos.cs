using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace _2019AM606.models
{
    public class Departamentos
    {

        [Key]
        public int id { get; set; }
        public string departamento { get; set; }

    }
}
