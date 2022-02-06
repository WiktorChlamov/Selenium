using Selenium.Validation;
using System;
using System.Text.RegularExpressions;

namespace Selenium
{
    internal class Program
    {
        //ввод отдела из нескольких слов строго через "_", так же вводятся несколько языков.


        static void Main(string[] args)
        {
            if (!InputValidating(args, out Exception ex))
            {
                Console.WriteLine(ex.Message);
            }
            else
            {
                int expectedResult = int.Parse(args[0]);
                string department = args[1];
                string languages = args[2];


                string departmentTextOptimazed = TextAdaptation(department);
                string[] langsTextOptimazed = LanguageArraySetting(languages);


                Testing testing = new Testing();
                testing.Run(expectedResult, departmentTextOptimazed, langsTextOptimazed);
            }
            Console.ReadLine();
        }

        private static string TextAdaptation(string text)
        {
            string pattern = @"_+";
            string target = " ";
            Regex regex = new Regex(pattern);
            return regex.Replace(text, target);
        }

        private static string[] LanguageArraySetting(string text)
        {
           return text.Split('_');
        }

        private static bool InputValidating(string[] args, out Exception ex)
        {
            ValidationChain chain = new ValidationChain();
            var result = chain.StartValidation(args);

            if (result != null)
            {
                ex = new Exception(result.ToString());
                return false;
            }
            else
            {
                ex = null;
                return true;
            }
        }
    }
}
