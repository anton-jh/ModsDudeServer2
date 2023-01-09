using ModsDudeServer.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Domain.Validation;
public abstract class DomainValidator<T>
{
    public DomainValidator(T value, [CallerArgumentExpression("value")] string parameterName = null!)
    {
        ParameterName = parameterName;
        Value = value;
    }

    public T Value { get; }
    public string ParameterName { get; }


    protected void ThrowHelper(string reason)
    {
        throw new DomainValidationException($"Parameter '{ParameterName}' {reason}.");
    }
}
