﻿using Business.Models;
using GrantManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface ILoginRegistrationBL
    {
        public Task<ApplicantDetails> Login(UserDetails user);
      


    }
}
