using DataAccess.Repository;
using GrantManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IGrantRepository
    {
        public GrantRepository GetInstance();

     
        public List<GrantProgram> GetGrantDetails();

        public int AddGrantDetails(GrantProgram grantPrograms);
        public string UpdateGrantDetails(List<GrantProgram> grantPrograms);
      

        public int RemoveGrantDetails(GrantProgram grantPrograms);
 

        public string UpdateGrantDetail(GrantProgram grantPrograms);

       
    }
}
