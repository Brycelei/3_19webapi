using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace _3_19webapi.model
{
    public class User
    {
        // [Key]
        public int Id { get; set; }
        // [MaxLength(20)]
        public string Username { get; set; }
        //[MaxLength(3)]
        public int Password { get; set; }

    }
}
