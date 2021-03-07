using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Business.Models
{
    public class RegisterUser
    {
       
       public string EmailID { get; set; }
       
        public string Password { get; set; }
      
        public string FirstName { get; set; }
       
        public string LastName { get; set; }
    }
}
