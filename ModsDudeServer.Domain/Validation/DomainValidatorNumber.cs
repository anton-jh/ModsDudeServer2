using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Domain.Validation;
public class DomainValidatorNumber : DomainValidator<double>
{
    public DomainValidatorNumber(double value, [CallerArgumentExpression("value")] string parameterName = null!) : base(value, parameterName)
    {
    }


    public DomainValidatorNumber GreaterThan(double limit)
    {
        if (Value > limit == false)
        {
            ThrowHelper($"must be greater than {limit}");
        }

        return this;
    }

    public DomainValidatorNumber GreaterThanOrEqualTo(double limit)
    {
        if (Value >= limit == false)
        {
            ThrowHelper($"must be greater than or equal to {limit}");
        }

        return this;
    }

    public DomainValidatorNumber LessThan(double limit)
    {
        if (Value < limit == false)
        {
            ThrowHelper($"must be less than {limit}");
        }

        return this;
    }

    public DomainValidatorNumber LessThanOrEqualTo(double limit)
    {
        if (Value <= limit == false)
        {
            ThrowHelper($"must be less than or equal to {limit}");
        }

        return this;
    }

    public DomainValidatorNumber Between(double min, double max, bool minInclusive = true, bool maxInclusive = true)
    {
        bool minOk = minInclusive ? Value >= min : Value > min;
        bool maxOk = maxInclusive ? Value <= max : Value < max;

        if (minOk && maxOk == false)
        {
            string minMsg = minInclusive ? "incl" : "excl";
            string maxMsg = maxInclusive ? "incl" : "excl";

            ThrowHelper($"must be between {min} ({minMsg}) and {max} ({maxMsg})");
        }

        return this;
    }

    public DomainValidatorNumber NonZero()
    {
        if (Value == 0)
        {
            ThrowHelper("cannot be zero");
        }

        return this;
    }
}
