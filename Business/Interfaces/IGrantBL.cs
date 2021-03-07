using GrantManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Interfaces
{
   public interface IGrantBL
    {

        public List<GrantProgram> GetGrantPrograms();
        List<GrantProgram> AddUpdateGrantDetails(List<GrantProgram> data);
    }
}
