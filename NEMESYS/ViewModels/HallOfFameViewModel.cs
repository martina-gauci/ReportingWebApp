using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace NEMESYS.ViewModels {
    public class HallOfFameViewModel {

        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        [DisplayName("Reports Submitted")]
        public int Count { get; set; }

        public HallOfFameViewModel(string FullName, string Email, string Phone, int Count) {
            this.FullName = FullName;
            this.Email = Email;
            this.Phone = Phone;
            this.Count = Count;
        }
    }
}
