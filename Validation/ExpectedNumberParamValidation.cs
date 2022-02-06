using System;
using System.Collections.Generic;
using System.Text;

namespace Selenium.Validation
{
    internal class ExpectedNumberParamValidation:Validation
    {
        public override object Handle(object request)
        {
            int number;
            if (!int.TryParse((request as string[])[0], out number))
            {
                return "Первый параметр должен быть целочисленным";
            }

            else if(number < 0)
            {
                return "Первый параметр не должен быть меньше нуля";
            }

            else
            {
                return base.Handle(request);
            }
        }
    }
}
