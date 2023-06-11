using Domain.Entities;
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


        #region Methods
        public User ToEntity()
        {
            return new User
            {
                Id = id,
                Login = login,
                Password = password
            };
        }

        public UserDTO ToDTO(User user)
        {
            return new UserDTO
            {
                id = user.Id,
                login = user.Login,
                password = user.Password
            };
        }
        #endregion

    }
}
