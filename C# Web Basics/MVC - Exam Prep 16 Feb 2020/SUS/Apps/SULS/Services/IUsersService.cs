using System;
using System.Collections.Generic;
using System.Text;

namespace Suls.Services
{
    public interface IUsersService
    {
        string CreateUser(string username, string email, string password);

        string GetUserId(string username, string password);

        bool IsUsernameAvailable(string username);

        bool IsEmailAvailable(string email);
    }
}
