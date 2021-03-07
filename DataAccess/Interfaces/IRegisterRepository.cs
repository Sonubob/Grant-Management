using DataAccess.Repository;
using GrantManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IRegisterRepository
    {
        public RegisterRepository GetInstance();

        public string ValidateUser(string userName, string password);

        public UserInfo AddUser(UserInfo user);

        public string AddApplicantDetails(ApplicantDetail details);

     
    }
}
