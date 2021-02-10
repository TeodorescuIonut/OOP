using System;
using System.Collections.Generic;
using System.Text;

namespace JSONclasses
{
    interface IPattern
    {
        bool Match(string text);
    }

}
