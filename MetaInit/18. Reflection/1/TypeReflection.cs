using MetaInit.common;

namespace Reflection
{
    public class TypeReflection
    {
        private static readonly Type? _userType = Type.GetType("Reflection.TypeReflection+ReflectionUser", false,true);
        public static void GetTypeof()
        {
            var myType = typeof(ReflectionUser);
            
            Console.WriteLine(myType.ToString());
        }

        public static void InstanceGetType()
        {
            ReflectionUser user = new("Tom",25);
            var myType = user.GetType();
            Console.WriteLine(myType);
        }

        public static void StaticGetType() => Console.WriteLine(_userType);
        
        public static void GetMembers()
        {
            foreach (var memberInfo in _userType?.GetMembers())
            {
                Console.WriteLine($"{memberInfo.DeclaringType} {memberInfo.MemberType} {memberInfo.Name}");
            }
        }

        public static void GetMethods()
        {
            Console.WriteLine("Методы:");
            foreach (var method in _userType?.GetMethods())
            {
                var modificator = "";
                if (method.IsStatic)
                {
                    modificator += "static ";
                }

                if (method.IsVirtual)
                {
                    modificator += "virtual ";
                }
                Console.Write($"{modificator} {method.ReturnType.Name} {method.Name} (");
                //получаем все параметры

                var parameters = method.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    Console.Write($"{parameters[i].ParameterType.Name} {parameters[i].Name}");
                    if (i+1 < parameters.Length) Console.Write(", ");
                }
                Console.WriteLine(")");
            }
        }
        public static void GetConstructors()
        {
            Console.WriteLine("Конструкторы:");
            foreach(var ctor in _userType.GetConstructors())
            {
                Console.Write(_userType.Name + " (");
                // получаем параметры конструктора
                var parameters = ctor.GetParameters();
                for (int i = 0; i < parameters.Length; i++)
                {
                    Console.Write(parameters[i].ParameterType.Name + " " + parameters[i].Name);
                    if (i + 1 < parameters.Length) Console.Write(", ");
                }
                Console.WriteLine(")");
            }
        }

        public static void GetFields()
        {
            Console.WriteLine("Поля:");
            foreach (var field in _userType.GetFields())
            {
                Console.WriteLine($"{field.FieldType} {field.Name}");
            }
 
            Console.WriteLine("Свойства:");
            foreach (var prop in _userType.GetProperties())
            {
                Console.WriteLine($"{prop.PropertyType} {prop.Name}");
            }
        }

        public static void GetInterfaces()
        {
            Console.WriteLine("Реализованные интерфейсы:");
            foreach (Type i in _userType.GetInterfaces())
            {
                Console.WriteLine(i.Name);
            }
        }
        class ReflectionUser : User
        {
            public ReflectionUser(string n, int a)
            {
                Name = n;
                Age = a;
            }

            public void Display() => Console.WriteLine($"Имя {Name} Возраст: {Age}");

            public int Payment(int hours, int perhour) => hours * perhour;
        }
    }
}