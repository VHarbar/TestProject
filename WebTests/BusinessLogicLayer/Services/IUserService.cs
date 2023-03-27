using DataAccessLayer.DTO;
using DataAcessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public interface IUserService
    {
        public Task<int> AddUser(CrudUserDto userDto);
        public Task UpdateUser(CrudUserDto userDto);
        public Task DeleteUser(int userId);
        public Task<IEnumerable<User>> GetAllUsers();
        public Task<UserDto> GetUserWithTests(int id);
        public Task<User> GetUserById(int id);
        public Task<User> GetUserBySurname(string surname);
    }
}
