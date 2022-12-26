using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class UniProfileModel
    {
        [Key]
        public int Uni_ID { get; set; }
        [Required]
        public string Uni_FullName { get; set; }
        [Required]
        public string Uni_ShortName { get; set; }
        [Required]
        public string Uni_Details { get; set; }
        [Required]
        public int Uni_FacultyID { get; set; }
        public string ImageExtension { get; set; }
        public string ProfilPic_URL { get; set; }
        [NotMapped]
        public IFormFile UploadedProfilePic { get; set; }

    }
}
