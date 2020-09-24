namespace Advanced_Querying
{
    using Advanced_Querying.Data;
    using Advanced_Querying.Data.ViewModels;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Newtonsoft.Json;
    using System.Linq;
    using AutoMapper;

    class Program
    {
        static void Main(string[] args)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Employees, EmployeeDTO>();
            });
            
            using (var db = new SoftUniContext())
            {
                var employee = db
                   .Employees
                   .First();

                string result = JsonConvert.SerializeObject(employee, Formatting.Indented);
                System.Console.WriteLine(result);
            }

        }
    }
}
