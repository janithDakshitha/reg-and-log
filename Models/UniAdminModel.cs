using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class UniAdminModel
    {
        [Key]
        public int Userid { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage ="Please Enter User Name")]
        public string Username { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please Enter Email")]
        public string Uemail { get; set; }


        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please Enter Password")]
        [DataType(DataType.Password)]
        public string Pwd { get; set; }


        [Display(Name = "Confirm Password")]
        [Required(ErrorMessage = "Please Enter confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Pwd")]
        public string ConfirmPwd { get; set; }
        

    }
}
