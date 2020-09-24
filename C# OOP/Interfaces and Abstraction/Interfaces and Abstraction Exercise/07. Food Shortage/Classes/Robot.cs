using System;
using System.Collections.Generic;
using System.Text;

namespace _06._Birthday_Celebrations
{
    public class Robot
    {
        public string Model { get; set; }
        public string Id { get; set; }

        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }
    }
}
