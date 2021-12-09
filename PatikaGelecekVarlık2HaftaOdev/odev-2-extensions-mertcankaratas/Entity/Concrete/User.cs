using Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Core.Entity;

namespace Entity.Concrete
{
  
    public class User : IUser,IEntity
    {
        public int Id { get ; set; }
        public string UserName{ get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserType { get; set; }
    }

    
    
}
