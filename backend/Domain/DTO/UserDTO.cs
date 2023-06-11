using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class UserDTO
    {
        public int id { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public virtual ICollection<ContactDTO>? contacts { get; set; }
    }
}
