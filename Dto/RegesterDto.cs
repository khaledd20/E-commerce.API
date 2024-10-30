using System.ComponentModel.DataAnnotations;

namespace AngEcommerceProject.Dto
{
    public class RegesterDto
    {
        [Required]
        public string name { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string phoneNumber { get; set; }
        [Required]
        public string street { get; set; }
        [Required]
        public string postalCode { get; set; }
        [Required]
        public string city { get; set; }
        [Required]
        public string confirmPassword { get; set; }
        [Required]
        public string password { get; set; }


    }
}
