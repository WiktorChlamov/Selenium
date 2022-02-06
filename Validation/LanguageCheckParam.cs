using System;
using System.Collections.Generic;
using System.Text;

namespace Selenium.Validation
{
    internal class LanguageCheckParam:Validation
    {
        public override object Handle(object request)
        {
            if ((request as string[])[0] == "")
            {
                return $"Неправильное имя";
            }
            else
            {
                return base.Handle(request);
            }
        }
    }
}
