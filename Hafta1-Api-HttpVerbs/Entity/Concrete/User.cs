using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Entities.Concrete
{
    public class User:IEntity
    {   //Bir userda olması gereken bilgiler ve data annotation'lar
      
        [Required]
        public int UserId { get; set; }
        [Required]
        [MinLength(3)]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        public string password { get; set; }

    }
}
