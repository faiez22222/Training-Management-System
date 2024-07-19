using System;
using System.Reflection;

namespace ReflectionDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the full path of the EmployeeManagement.dll assembly:");
            string assemblyPath = @"C:\Users\Administrator\source\repos\ReflectionDemo\EmployeeManagement\bin\Debug\EmployeeManagement.dll";

            try
            {
                var assembly = Assembly.LoadFrom(assemblyPath);
                var myType = assembly.GetType("EmployeeManagement.Employee");

                if (myType == null)
                {
                    Console.WriteLine("Type 'EmployeeManagement.Employee' not found in the assembly.");
                    return;
                }

                object myObject = Activator.CreateInstance(myType , new object[] { 1 ,"mohd faiez" , "Software Developer" ,60000M});
                Type type = myObject.GetType();

                Console.WriteLine($"Type: {type.FullName}");
                foreach(FieldInfo feilds in type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance ) )
                {
                    Console.WriteLine(feilds);
                }

                Console.WriteLine("properties");
                foreach(PropertyInfo propertyInfo in type.GetProperties())
                {
                    object x = propertyInfo.GetValue(myObject, null);
                    Console.WriteLine(x);
                }
                Console.WriteLine("member");
                foreach(MemberInfo memberInfo in type.GetMembers())
                {
                    Console.WriteLine(memberInfo.Name);
                }
                string methodName = Console.ReadLine();
                MethodInfo methodInfo = type.GetMethod(methodName);
                ParameterInfo[] parameterInfo = methodInfo.GetParameters();
                object[] obj = new object[parameterInfo.Length]; 
                int i = 0;  
                foreach(ParameterInfo parameter in parameterInfo)
                {
                    Console.WriteLine($"Enter value in {parameter.ParameterType}");
                    string value = Console.ReadLine() ;
                    obj[i] = Convert.ChangeType(value , parameter.ParameterType);
                }
                object result = methodInfo.Invoke(myObject , obj);
                Console.WriteLine(result);  

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
