using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public class Robot : ICheckable
    {
        public string Model { get; set; }
        public string Id { get; set; }

        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }

        public void CheckId(string lastDigits)
        {
            if (Id.Contains(lastDigits) && Id[Id.Length - 1] == lastDigits[lastDigits.Length - 1])
            {
                Console.WriteLine(Id);
            }
        }
    }
}
