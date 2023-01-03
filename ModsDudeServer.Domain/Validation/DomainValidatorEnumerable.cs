using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Domain.Validation;
public class DomainValidatorEnumerable<T> : DomainValidator<IEnumerable<T>>
{
    public DomainValidatorEnumerable(IEnumerable<T> value, [CallerArgumentExpression("value")] string parameterName = null!) : base(value, parameterName)
    {
    }


    public DomainValidatorEnumerable<T> NotEmpty()
    {
        if (Value.Any() == false)
        {
            ThrowHelper("cannot be empty");
        }

        return this;
    }
}
