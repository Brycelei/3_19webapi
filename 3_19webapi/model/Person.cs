using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace _3_19webapi.model
{
    public class Person
    {
       // [Key]
        public int Id { get; set; }
       // [MaxLength(20)]
        public string Name { get; set; }
        //[MaxLength(3)]
        public int Age { get; set; }
    }
}
