using Domain.DTO;
using Domain.Interfaces.IRepositories;
using Domain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.MySQLServices
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repository;

        public ContactService(IContactRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _repository.GetById(id);
            return await _repository.Delete(entity);
        }

        public IQueryable<ContactDTO> GetAll()
        {
            return _repository.GetAll().Select(contact => new ContactDTO
            {
                id = contact.Id,
                userId = contact.UserId,
                name = contact.Name,
                phoneNumber = contact.PhoneNumber,
                email = contact.Email
            });
        }

        public async Task<ContactDTO> GetById(int id)
        {
            ContactDTO contact = new ContactDTO();
            return contact.ToDTO(await _repository.GetById(id));
        }

        public async Task<int> Save(ContactDTO entity)
        {
            if(entity.id >= 1)
            {
                return await _repository.Update(entity.ToEntity());
            }

            return await _repository.Save(entity.ToEntity());
        }
    }
}
