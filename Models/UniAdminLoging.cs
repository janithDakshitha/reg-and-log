using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class UniAdminLoging
    {
        //[Key]
        //[System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please Enter you Username !")]
        //[Display(Name ="enter Username :")]
        //public int U_Id { get; set; }
        [Key]
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please Enter you Email !")]
        [Display(Name = "enter Email :")]
        public string Email { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Please Enter you Password !")]
        [Display(Name = "enter Password :")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
