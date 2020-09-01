using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NEMESYS.Models{
    //This is a model class for a report
    //This Report class represents/will be converted to the Reports table inside the db. 
    //Entity Framework Core will handle this process.
    public class Report{ //Corresponding table name will be plural of this class

        // The following fields are to be set automatically
        [Key]
        public int ReportId { get; set; }
        [Required]
        [ForeignKey("ReporterId")]
        public int ReporterId { get; set; }  
        public User Reporter { get; set; }
        [ForeignKey("InvestigatorID")]
        public int? InvestigatorID { get; set; }
        public User Investigator { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Submission Date")]
        public DateTime DateOfSubmission { get; set; }
        [Required]
        public status Status { get; set; }
        [Required]
        [DisplayName("Up Votes")]
        public int UpVoteCount { get; set; }

        // The following fields are to be inputed by the reporter
       
        [Required]
        public priority Priority { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(150)")]
        [DisplayName("Hazard Type")]
        public string TypeOfHazard { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Date And Time Spotted")]
        public DateTime DateAndTimeOfSpotting { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(150)")]
        public string Location { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(150)")]
        public string Longitude { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(150)")]
        public string Latitude { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        public string PhotoUrl { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }  


        public Report(){
            this.InvestigatorID = null;
            this.DateOfSubmission = DateTime.UtcNow.Date;
            this.Status = status.Open;
            this.UpVoteCount = 0;
        }

    }//end of model class


    public enum priority{
        Low,
        Medium,
        High
    }


    public enum status{
        Open,
        [Display(Name = "Being Investigated")]
        BeingInvestigated,
        Closed,
        [Display(Name = "No Action Required")]
        NoActionRequired
    }

}//end of namespace
