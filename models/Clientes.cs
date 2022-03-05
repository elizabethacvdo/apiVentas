using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace _2019AM606.models
{
    public class Clientes
    {
        [Key]
        public int id { get; set; }
        public int idDepartamento { get; set; }
        public string nombre { get; set; }

       // [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime FechaNac { get; set; }
    }

   /// internal class CustomDateTimeConverter : IsoDateTimeConverter
 //   {
   //     public CustomDateTimeConverter()
     //   {
       //     base.DateTimeFormat = "yyyy-MM-dd";
        //}
    //}
}
