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
    }
}
