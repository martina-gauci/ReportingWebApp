using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NEMESYS.Models{
    //This is a model class for a user
    //This User class represents/will be converted to the Users table inside the db. 
    //Entity Framework Core will handle this process.
    public class User { //Corresponding table name will be plural of this class
        [Key]
        public int UserId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        [DisplayName("Full Name")]
        public string FullName { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string Email { get; set; }
        //This data annotation below ensures that the phone number is a valid Maltese phone number
        [RegularExpression(@"^(21|27|79|77|79)\d{6}$", ErrorMessage = "Invalid Phone Number!")]
        [Column(TypeName = "nvarchar(20)")]
        public string Phone { get; set; }
        [Required]
        [DisplayName("Role")]
        public roles Role { get; set; }
        [Required]
        [DisplayName("Reports Submitted")]
        public int NoOfReportsSubmitted { get; set; }


        public User(){
            this.Role = roles.Reporter;
            this.NoOfReportsSubmitted = 0;
            this.Phone = null;
        }

        public User(string iName, string iEmail) {
            this.FullName = iName;
            this.Email = iEmail;
            this.Phone = null;
            //By default a new user is a reporter
            this.Role = roles.Reporter;
            this.NoOfReportsSubmitted = 0;
        }

    }//end of model class

    public enum roles {
        Reporter,
        Investigator,
        Admin
    }

}//end of namespace
