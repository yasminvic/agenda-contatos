using Domain.DTO;
using Domain.Interfaces.IRepositories;
using Domain.Interfaces.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.MySQLServices
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> Delete(int id)
        {
            var entity = await _repository.GetById(id);
            return await _repository.Delete(entity);
        }

        public List<UserDTO> GetAll()
        {
            return _repository.GetAll().Select(user => new UserDTO
            {
                id = user.Id,
                login= user.Login,
                password = user.Password,
            }).ToList();
        }

        public async Task<UserDTO> GetById(int id)
        {
            UserDTO user = new UserDTO();
            return user.ToDTO(await _repository.GetById(id));
        }

        public async Task<int> Save(UserDTO entity)
        {
            if(entity.id >= 1)
            {
                return await _repository.Update(entity.ToEntity());
            }

            return await _repository.Save(entity.ToEntity());
        }
    }
}
