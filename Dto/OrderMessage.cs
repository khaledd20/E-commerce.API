using System.Collections.Generic;

namespace AngEcommerceProject.Dto
{
    public class OrderMessage
    {
        public bool IsOk { get; set; }
        public List<string> productsFailed { get; set; }
    }
}
