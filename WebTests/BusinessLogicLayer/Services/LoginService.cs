using BusinessLogicLayer.Repository;
using DataAccessLayer.Models;
using DataAcessLayer.Entity;
using Microsoft.Extensions.Configuration;
namespace BusinessLogicLayer.Services
{
    public class LoginService : ILoginService
    {
        private readonly IGenericRepository _repository;
        private readonly IConfiguration _configuration;
        public LoginService(IGenericRepository repository, IConfiguration configuration)
        {
            _repository = repository;
            _configuration = configuration;
        }
        public AuthenticateResponse Authenticate(string login, string password)
        {
            var user = _repository.GetAll<User>().FirstOrDefault(x => x.Surname == login && x.Password == password);
            if (user == null)
            {
                return null;
            }
            var token = _configuration.GenerateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }
        public User GetUserById(int id)
        {
            return _repository.GetAll<User>().FirstOrDefault(x => x.Id == id);
        }
    }
}
