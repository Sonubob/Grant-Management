using Business.Interfaces;
using DataAccess.Interfaces;
using GrantManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.BusinessLayer
{
    public class GrantBL: IGrantBL
    {

        private readonly IGrantFactory _factoryObjt;
        private IGrantRepository _repoObjt;

        public GrantBL(IGrantFactory factoryObjt, IGrantRepository objt)
        {
            _factoryObjt = factoryObjt;
            _repoObjt = objt;
        }
        public List<GrantProgram> GetGrantPrograms()
        {
            //_repoObjt = _factoryObjt.GetInstanceofDBObject();
            var result = _repoObjt.GetGrantDetails();
            result.ForEach(x => x.StartDate = DateTime.Parse(x.StartDate?.ToShortDateString()));
            if (result.Count > 0)
            {
                return result;
            }
            else
            {
                return new List<GrantProgram>();
            }
        }

        public List<GrantProgram> AddUpdateGrantDetails(List<GrantProgram> data)
        {
            //_repoObjt = _factoryObjt.GetInstanceofDBObject();
            var result = "";
            var val = 0;
            var list = GetGrantPrograms();
            if (list.Count > 0)
            {

                foreach (var entry in data)
                {
                    if (!(list.Exists(x => x.GrantId == entry.GrantId)))
                    {
                        var x = list.Max(x => x.GrantId);
                        //  entry.GrantId = x+1;
                        var indx = _repoObjt.AddGrantDetails(entry);
                        entry.GrantId = indx;
                    }
                    else
                    {
                        _repoObjt.UpdateGrantDetail(entry);
                    }

                }
                foreach (var entry in list)
                {
                    if (!(data.Exists(x => x.GrantId == entry.GrantId)))
                    {
                        _repoObjt.RemoveGrantDetails(entry);
                    }
                }
                // list = GetGrantPrograms();
                //  result = __repoObjt.UpdateGrantDetails(data);


                return GetGrantPrograms();

            }
            else
            {
                foreach (var entry in data)
                {
                    val = _repoObjt.AddGrantDetails(entry);
                }
                if (val > 0)
                {
                    return GetGrantPrograms();
                }
            }

            return new List<GrantProgram>();
        }
    }
}
