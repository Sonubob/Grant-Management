using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Models
{
    public class ApplicantDropdownList
    {
        public List<DropdownType> CountryDropdown { get; set; }
        public List<DropdownType> StateDropdown { get; set; }

        public List<DropdownType> GrantDropdown { get; set; }
    }
}
