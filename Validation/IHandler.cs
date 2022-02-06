using System;
using System.Collections.Generic;
using System.Text;

namespace Selenium.Validation
{
    internal interface IHandler
    {
        IHandler SetNext(IHandler handler);
        object Handle(object request);
    }
}
