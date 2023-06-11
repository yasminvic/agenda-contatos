using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class ContactDTO
    {
        public int id { get; set; }
        public int userId { get; set; }
        public string name { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }

        public virtual UserDTO? User { get; set; }


        #region Methods

        public Contact ToEntity()
        {
            return new Contact
            {
                Id = id,
                UserId = userId,
                Name = name,
                PhoneNumber = phoneNumber,
                Email = email
            };
        }

        public ContactDTO ToDTO(Contact contact)
        {
            return new ContactDTO
            {
                id = contact.Id,
                userId = contact.UserId,
                name = contact.Name,
                phoneNumber = contact.PhoneNumber,
                email = contact.Email
            };
        }
        #endregion
    }
}
