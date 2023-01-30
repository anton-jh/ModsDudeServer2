using ModsDudeServer.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Application.Authentication;
public class LoginQuery
{
    public LoginQuery(string username, string password)
    {
        Username = UserName.From(username);
        Password = Password.From(password);
    }


    public UserName Username { get; }
    public Password Password { get; }
}
