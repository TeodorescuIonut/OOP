using System;
using System.Collections.Generic;
using System.Text;

namespace JSONclasses
{
    public interface IMatch
    {
           bool Success();

           string RemainingText();
    }
}
