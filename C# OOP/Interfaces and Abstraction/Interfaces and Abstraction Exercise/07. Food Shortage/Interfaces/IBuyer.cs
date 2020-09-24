using System;
using System.Collections.Generic;
using System.Text;

namespace _06._Birthday_Celebrations
{
    public interface IBuyer
    {
        int Food { get; set; }
        void BuyFood();
    }
}
