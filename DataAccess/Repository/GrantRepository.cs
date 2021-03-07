using DataAccess.Interfaces;
using GrantManagement.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class GrantRepository : IGrantRepository
    {
        public GrantRepository GetInstance()
        {
            return new GrantRepository();
        }

      

        public List<GrantProgram> GetGrantDetails()
        {
            using (var context = new GrantDBContext())
            {
                var result = context.GrantPrograms.Select(x => x).ToList();
                return result;
            }
        }

        public int AddGrantDetails(GrantProgram grantPrograms)
        {
            using (var context = new GrantDBContext())
            {
                context.GrantPrograms.Add(grantPrograms);
              var result =  context.SaveChanges();
                return result;
               
            }
        }

        public string UpdateGrantDetails(List<GrantProgram> grantPrograms)
        {
            using (var context = new GrantDBContext())
            {
                foreach(var data in grantPrograms)
                {
                    context.GrantPrograms.Update(data);
                    context.SaveChanges();
                }
              
                return "done";
            }
        }

        public string UpdateGrantDetail(GrantProgram grantPrograms)
        {
            using (var context = new GrantDBContext())
            {
                context.GrantPrograms.Update(grantPrograms);
                context.SaveChanges();
            }
            return "done";
        }

        public int RemoveGrantDetails(GrantProgram grantPrograms)
        {
            using (var context = new GrantDBContext())
            {
                context.GrantPrograms.Remove(grantPrograms);
                var result = context.SaveChanges();
                return result;

            }
        }

      

    }
}
