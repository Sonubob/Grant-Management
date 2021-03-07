using DataAccess.Repository;
using GrantManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface ILoginRegisterRepository
    {
        public LoginRepository GetInstance();

        public string ValidateUser(string userName, string password);

        public UserInfo GetUserInfo(string emailID);

     
        
    }
}
