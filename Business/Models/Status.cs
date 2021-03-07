using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Models
{
    public enum Status
    {
        Success = 1,
        Failure = 2,
        UserValid = 3,
        Unauthorized = 4,
        UserNotFound = 5,
        UserExists = 6
    }
}
