using AutoMapper;
using BusinessLogicLayer.Repository;
using DataAccessLayer.DTO;
using DataAcessLayer.Entity;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogicLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IGenericRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<int> AddUser(CrudUserDto userDto)
        {
            var newUser = await _repository.AddAsync(new User
            {
                Name = userDto.Name,
                Surname = userDto.SurName,
                Password = userDto.Password,
            });

            return newUser.Id;
        }
        public async Task UpdateUser(CrudUserDto userDto)
        {
            var user = await _repository.GetAll<User>()
                .FirstOrDefaultAsync(u => u.Id == userDto.Id);

            user.Name = userDto.Name;
            user.Surname = userDto.SurName;
            user.Password = userDto.Password;

            await _repository.UpdateAsync(user);
        }
        public async Task DeleteUser(int id)
        {
            await _repository.DeleteAsync<User>(id);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _repository.GetAll<User>().ToListAsync();
        }
        public async Task<User> GetUserById(int id)
        {
            var user = await _repository.GetAll<User>().FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }
        public async Task<UserDto> GetUserWithTests(int userId)
        {
            var user = await _repository
                .GetAll<User>()
                .Include(u => u.Tests)
                    .ThenInclude(t => t.Questions)
                        .ThenInclude(q => q.Answers)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
            {
                return null;
            }

            var userDto = _mapper.Map<UserDto>(user);

            return userDto;
        }

        public async Task<User> GetUserBySurname(string surname)
        {
            var userId = await _repository.GetAll<User>().FirstOrDefaultAsync(x => x.Surname == surname);
            return userId;
        }
    }
}
