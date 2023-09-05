using System.ComponentModel.DataAnnotations;

namespace CnD.CommunalPayments3.Doman.Helpers;

public static class EnumHelper
{
    public static string GetShortName(this Enum enumeration)
    {
        return (enumeration
                .GetType()
                .GetMember(enumeration.ToString())?
                .FirstOrDefault()?
                .GetCustomAttributes(typeof(DisplayAttribute), false)?
                .FirstOrDefault() as DisplayAttribute)?
            .Name ?? enumeration.ToString();
    }

    public static T GetValueFromDescr<T>(string name) where T : Enum
    {
        foreach (var item in typeof(T).GetFields())
        {
            if (Attribute.GetCustomAttribute(item, typeof(DisplayAttribute)) is DisplayAttribute attribute)
            {
                if (string.Equals(attribute.Name!, name, StringComparison.InvariantCultureIgnoreCase))
                    return (T)item.GetValue(null);
            }
            else
            {
                if (string.Equals(item.Name, name, StringComparison.InvariantCultureIgnoreCase))
                {
                    return (T)item.GetValue(null);
                }
            }
        }

        throw new ArgumentException("NotFound", nameof(name));
    }
}
