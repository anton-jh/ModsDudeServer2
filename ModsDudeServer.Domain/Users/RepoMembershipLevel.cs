using ModsDudeServer.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValueOf;

namespace ModsDudeServer.Domain.Users;
public class RepoMembershipLevel : ValueOf<int, RepoMembershipLevel>
{
    private const int _member = 100;
    private const int _admin = 200;
    private const int _owner = 300;

    public static readonly RepoMembershipLevel Member = From(_member);
    public static readonly RepoMembershipLevel Admin = From(_admin);
    public static readonly RepoMembershipLevel Owner = From(_owner);


    protected override void Validate()
    {
        bool valid = Value switch
        {
            _member => true,
            _admin => true,
            _owner => true,
            _ => false
        };

        if (!valid)
        {
            throw new DomainValidationException($"Invalid value for {nameof(RepoMembershipLevel)} '{Value}'.");
        }
    }
}
