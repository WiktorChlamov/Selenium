using System;
using System.Collections.Generic;
using System.Text;

namespace Selenium.Validation
{
    internal class ValidationChain
    {
        private ParamsLengthValidation _lengthValidation = new ParamsLengthValidation();
        private LanguageCheckParam _nameCheck = new LanguageCheckParam();
        private ExpectedNumberParamValidation _delayParamValidation = new ExpectedNumberParamValidation();

        private void SetChain(out IHandler start)
        {
           _lengthValidation.SetNext(_nameCheck).SetNext(_delayParamValidation);
            start = _lengthValidation;
        }

        public object StartValidation(object ob)
        {
            SetChain(out IHandler start);
            return start.Handle(ob);
        }
    }
}
