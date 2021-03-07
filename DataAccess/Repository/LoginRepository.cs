using DataAccess.Interfaces;
using GrantManagement.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class LoginRepository : ILoginRegisterRepository
    {
        public LoginRepository GetInstance()
        {
            return new LoginRepository();
        }


        public UserInfo GetUserInfo(string emailID)
        {
            using (var context = new GrantDBContext())
            {
                var result = context.UserInfos.Select(x => x).Where(c => c.UserName == emailID).FirstOrDefault();
                return result;
            }
        }

        public string ValidateUser(string userName, string password)
        {
            using (var context = new GrantDBContext())
            {

                var result = context.UserInfos.Any(c => c.UserName == userName && c.Password == password);
                if (result)
                {
                    return "User Valid";
                }
                return "User Invalid";
            }

        }


      
    }
}
