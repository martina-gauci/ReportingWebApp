using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NEMESYS.ViewModels {
    public class ReportAndAllInvestigatorsAndUserUpvoteDetailsViewModel {

        public bool HasUpvoted { get; set; }
        public List<NEMESYS.Models.User> InvestigatorsList { get; set; }
        public NEMESYS.Models.Report Report { get; set; }

    }
}
