using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NEMESYS.Models{
    //This is a model class for an investigation
    //This Investigation class represents/will be converted to the Investigations table inside the db. 
    //Entity Framework Core will handle this process.
    public class Investigation{ //Corresponding table name will be plural of this class
        [Key]
        public int InvestigationId { get; set; }
        [Required]
        [ForeignKey("ReportId")]
        public int ReportId { get; set; }
        public Report Report { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Investigation Submission Date")]
        public DateTime DateOfSubmission { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Date of Action")]
        public DateTime DateOfAction { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(max)")]
        public string Description { get; set; }

        public Investigation(){
            this.DateOfSubmission = DateTime.UtcNow.Date;
        }

    }//end of model class
}//end of namespace
