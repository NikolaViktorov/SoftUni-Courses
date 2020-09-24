using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string className, params string[] fields)
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"Class under investigation: {className}");
            
            Type classType = Type.GetType($"Stealer.{className}");
            object classInstance = Activator.CreateInstance(classType, new object[] { });
            FieldInfo[] fieldsInfo = classType.GetFields(
                     BindingFlags.Static |
                     BindingFlags.Instance |
                     BindingFlags.Public |
                     BindingFlags.NonPublic);

            foreach (FieldInfo field in fieldsInfo.Where(f => fields.Contains(f.Name)))
            {
                result.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return result.ToString().TrimEnd();
        }
        public string AnalyzeAcessModifiers(string className)
        {
            StringBuilder result = new StringBuilder();

            Type classType = Type.GetType($"Stealer.{className}");
            object instance = Activator.CreateInstance(classType, new object[] { });

            FieldInfo[] fieldInfos = classType.GetFields(
                    BindingFlags.Static |
                    BindingFlags.Instance |
                    BindingFlags.Public);
            MethodInfo[] publicMethodsInfo = classType.GetMethods(
                    BindingFlags.Instance | 
                    BindingFlags.Public);
            MethodInfo[] nonPublicMethodsInfo = classType.GetMethods(
                    BindingFlags.Instance |
                    BindingFlags.NonPublic);

            foreach (FieldInfo field in fieldInfos)
            {
                result.AppendLine($"{field.Name} must be private!");
            }
            foreach (MethodInfo method in nonPublicMethodsInfo.Where(m => m.Name.StartsWith("get")))
            {
                result.AppendLine($"{method.Name} have to be public");
            }
            foreach (MethodInfo method in publicMethodsInfo.Where(m => m.Name.StartsWith("set")))
            {
                result.AppendLine($"{method.Name} have to be private");
            }
            

            return result.ToString().TrimEnd();
        }
        public string RevealPrivateMethods(string className)
        {
            StringBuilder result = new StringBuilder();

            Type classType = Type.GetType($"Stealer.{className}");
            object instance = Activator.CreateInstance(classType, new object[] { });

            result.AppendLine($"All Private Methods of Class: {className}");
            result.AppendLine($"Base Class: {classType.BaseType.Name}");

            MethodInfo[] nonPublicMethodsInfo = classType.GetMethods(
                    BindingFlags.Instance |
                    BindingFlags.NonPublic);

            foreach (MethodInfo method in nonPublicMethodsInfo)
            {
                result.AppendLine(method.Name);
            }

            return result.ToString().TrimEnd();
        }
    }
}
