using MetaInit.common;

namespace Reflection;

public class Attributes
{
    public static void Validate()
    {
        AttributesUser tom = new("Tom", 232);
        AttributesUser bob = new("Sam", 13);

        var tomIsValid = ValidateUser(tom);
        var bobIsValid = ValidateUser(bob);
        
        Console.WriteLine($"result tom: {tomIsValid}");
        Console.WriteLine($"result bob: {bobIsValid}");
    }

    private static bool ValidateUser(AttributesUser user)
    {
        if (user == null) throw new ArgumentNullException(nameof(user));
        var t = typeof(AttributesUser);
        var attrs = t.GetCustomAttributes(false);
        foreach (AgeValidationAttribute attr in attrs)
        {
            return user.Age >= attr.Age;
        }
        return true;
    }

    class AgeValidationAttribute : Attribute
    {
        public int Age { get; set; }

        public AgeValidationAttribute()
        {
        }

        public AgeValidationAttribute(int age)
        {
            Age = age;
        }
    }

    [AgeValidation(18)]
    class AttributesUser : User
    {
        public AttributesUser(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}