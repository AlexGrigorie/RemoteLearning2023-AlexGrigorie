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
                    if (type.IsClass)
                    {
                        Console.WriteLine($"Class Name: {type.Name}");
                        ConstructorInfo[] constructors = type.GetConstructors();
                        foreach (ConstructorInfo constructor in constructors)
                        {
                            Console.WriteLine($"Constructor: {constructor.Name}");
                            ParameterInfo[] parameters = constructor.GetParameters();
                            foreach (ParameterInfo parameter in parameters)
                            {
                                Console.WriteLine($"Param: {parameter.ParameterType} {parameter.Name} {parameter}");
                            }
                        }
                    }
                    else if (type.IsInterface)
                    {
                        Console.WriteLine($"Interface Name: {type.Name}");
                        MethodInfo[] methods = type.GetMethods();
                        foreach (MethodInfo method in methods)
                        {
                            Console.WriteLine($"Method: {method.ReturnType} {method.Name}");
                            ParameterInfo[] parameters = method.GetParameters();
                            foreach (ParameterInfo parameter in parameters)
                            {
                                Console.WriteLine($"Param: {parameter.ParameterType} {parameter.Name}");
                            }
                        }
                    }
                    else if (type.IsEnum)
                    {
                        Console.WriteLine($"Enum Name: {type.Name}");
                        var enumValues = Enum.GetValues(type);
                        foreach (var value in enumValues)
                        {
                            Console.WriteLine($"{value}: {(int)value}");
                        }
                    }

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
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
