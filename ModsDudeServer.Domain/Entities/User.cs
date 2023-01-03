using ModsDudeServer.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Domain.Entities;
public class User
{
    public User(Username username, PasswordHash passwordHash)
    {
        Username = username;
        PasswordHash = passwordHash;
    }


    public Username Username { get; }
    public PasswordHash PasswordHash { get; }
}
