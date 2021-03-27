using System;
using System.Collections.Generic;
using System.Text;

namespace JSONclasses
{
   public interface IPattern
    {
       IMatch Match(string text);
    }
}
