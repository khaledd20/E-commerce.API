using System.Collections.Generic;

namespace AngEcommerceProject.Dto
{
    public class UserRollesDto
    {
        public string id { get; set; }
        public string name { get; set; }
        public string street { get; set; }
        public string postalCode { get; set; }
        public string city { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public List<string> Roles { get; set; }



    }
}
