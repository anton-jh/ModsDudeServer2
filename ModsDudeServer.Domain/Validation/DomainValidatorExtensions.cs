using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModsDudeServer.Domain.Validation;
public static class DomainValidatorExtensions
{
    public static DomainValidatorNumber MustBe(this int value) => new(value);

    public static DomainValidatorNumber MustBe(this double value) => new(value);

    public static DomainValidatorString MustBe(this string value) => new(value);

    public static DomainValidatorEnumerable<T> MustBe<T>(this IEnumerable<T> value) => new(value);
}
