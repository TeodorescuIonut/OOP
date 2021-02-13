using System;
using System.Collections.Generic;
using System.Text;

namespace JSONclasses
{
    interface IPattern
    {
        IMatch Match(string text);
    }
}
