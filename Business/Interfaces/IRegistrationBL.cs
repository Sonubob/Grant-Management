using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Models;

namespace Business.Interfaces
{
    public interface IRegistrationBL
    {
        public int RegisterUser(RegisterUser user);
    }
}
