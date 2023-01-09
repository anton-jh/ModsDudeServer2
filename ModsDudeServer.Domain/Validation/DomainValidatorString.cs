using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Domain.Validation;
public class DomainValidatorString : DomainValidator<string>
{
    public DomainValidatorString(string value, [CallerArgumentExpression("value")] string parameterName = null!) : base(value, parameterName)
    {
    }


    public DomainValidatorString NotEmptyOrWhitespace()
    {
        if (string.IsNullOrWhiteSpace(Value))
        {
            ThrowHelper("cannot be empty or whitespace");
        }

        return this;
    }

    public DomainValidatorString AtLeastThisLong(int length)
    {
        if (length < 0)
        {
            throw new ArgumentException("A string can't have a negative length now can it?");
        }

        if (Value.Length < length)
        {
            ThrowHelper($"must be at least {length} characters long");
        }

        return this;
    }
}
