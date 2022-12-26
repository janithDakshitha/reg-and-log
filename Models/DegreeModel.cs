using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class DegreeModel
    {
        [Key]
        public int Degree_ID { get; set; }
        public string Degre_Name { get; set; }
        public string Degree_Type { get; set; }
        public string? Degree_Description { get; set; }
        public string? Degree_Duration { get; set; }
        public int? Admission_Requirements_ID { get; set; }
        public string? Career_Opurtunity { get; set; }
        public string? Affiliated_Uni { get; set; }
        public int? Degree_Content_ID { get; set; }
        public string? Course_Fee { get; set; }
        public string? Academic_prog { get; set; }

        [ForeignKey("UniProfiles")]
        public int Uni_ID { get; set; }
        public UniProfileModel UniProfiles { get; set; }

    }
}
