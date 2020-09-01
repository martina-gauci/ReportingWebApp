using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NEMESYS.ViewModels {
    public class AllReportsAndLoggedInUserViewModel {

        public IEnumerable<NEMESYS.Models.Report> reportList {get; set;}
        public NEMESYS.Models.User userObj { get; set;}

    }
}
