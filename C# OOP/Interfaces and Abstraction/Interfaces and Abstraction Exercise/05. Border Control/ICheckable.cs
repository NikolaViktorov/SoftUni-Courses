using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
    public interface ICheckable
    {
        string Id { get; set; }
        void CheckId(string lastDigits);
    }
}
