using System.Reflection;

namespace Reflection
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var pathDll = @"D:\projects\ChargeIt\ChargeIt\bin\Debug\net6.0\Microsoft.Data.SqlClient.dll";

            try
            {
                var assembly = Assembly.LoadFile(pathDll);
                Type[] types = assembly.GetTypes();

                foreach (Type type in types)
                {
                    Console.WriteLine($"Type: {type.FullName}");
                    ShowTypeInformation(type);
                    MembersInfomation(type);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        private static void MembersInfomation(Type type)
        {
            MemberInfo[] members = type.GetMembers();
            foreach (MemberInfo member in members)
            {
                switch (member.MemberType)
                {
                    case MemberTypes.Property:
                        Console.WriteLine($"Property: {member.Name} {member.MemberType}");
                        break;
                    case MemberTypes.Method:
                        Console.WriteLine($"Method: {member.Name} {member.MemberType} {member.DeclaringType}");
                        break;
                    case MemberTypes.Event:
                        Console.WriteLine($"Event: {member.Name} {member.MemberType} {member.DeclaringType}");
                        break;
                    case MemberTypes.Field:
                        Console.WriteLine($"Field: {member.Name} {member.MemberType} {member.DeclaringType}");
                        break;
                    default:
                        break;
                }
            }
        }

        private static void ShowTypeInformation(Type type)
        {
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Object when type.IsClass:
                    ShowClassInformation(type);
                    break;
                case TypeCode.Object when type.IsInterface:
                    ShowInterfaceInformation(type);
                    break;
                case TypeCode.Object when type.IsEnum:
                    ShowEnumInformation(type);
                    break;
            }
        }
        private static void ShowClassInformation(Type type)
        {
            Console.WriteLine($"Class Name: {type.Name}");
            ConstructorInfo[] constructors = type.GetConstructors();
            foreach (ConstructorInfo constructor in constructors)
            {
                Console.WriteLine($"Constructor: {constructor.Name}");
                ShowParameters(constructor.GetParameters());
            }
        }

        private static void ShowInterfaceInformation(Type type)
        {
            Console.WriteLine($"Interface Name: {type.Name}");
            MethodInfo[] methods = type.GetMethods();
            foreach (MethodInfo method in methods)
            {
                Console.WriteLine($"Method: {method.ReturnType} {method.Name}");
                ShowParameters(method.GetParameters());
            }
        }

        private static void ShowEnumInformation(Type type)
        {
            Console.WriteLine($"Enum Name: {type.Name}");
            var enumValues = Enum.GetValues(type);
            foreach (var value in enumValues)
            {
                Console.WriteLine($"{value}: {(int)value}");
            }
        }

        private static void ShowParameters(ParameterInfo[] parameters)
        {
            foreach (ParameterInfo parameter in parameters)
            {
                Console.WriteLine($"Param: {parameter.ParameterType} {parameter.Name}");
            }
        }

    }
}
