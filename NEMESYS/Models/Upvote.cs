using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//The aim of this model is to store who liked which reports. So if a user
//liked a particular report, a record with the id of the report in  
//question and the id of  the user in question will be stored in the DB.

namespace NEMESYS.Models {
    public class Upvote { //Corresponding table name will be plural of this class

        [Required]
        [ForeignKey("ReportId")]
        public int ReportId { get; set; }
        public Report Report { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User User { get; set; }

        public Upvote(int ReportId, int UserId) {
            this.ReportId = ReportId;
            this.UserId = UserId;
        }

    }//end of model class
}//end of namespace
