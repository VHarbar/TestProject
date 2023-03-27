using DataAccessLayer.Models;
using DataAcessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public interface ILoginService
    {
        public AuthenticateResponse Authenticate(string login, string password);
        public User GetUserById(int id);
    }
}
