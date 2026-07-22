using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketplaceSystem
{

    public static class InputHelper
    {
        public static string GetValidInputLength(string word, int? minLength = null, int? maxLength = null)
        {
            while (true)
            {
                if (CheckLength(word, minLength, maxLength))
                {
                    return word;
                }
                else
                {
                    if (minLength == null && maxLength == null)
                    {
                        throw new ArgumentException("specidy at least one of limitation ! (min or max)");
                    }

                    if (minLength != null)
                    {
                        Console.WriteLine($"your input should contain at least {minLength} characters");
                    }

                    if (maxLength != null)
                    {
                        Console.WriteLine($"your input can not be longer than {maxLength} characters");
                    }
                    Console.WriteLine("please enter again");
                    word = GetStringValue();
                }
            }
        }
        //Start check length function
        public static bool CheckLength(string word, int? minLength = null, int? maxLength = null)
        {
            int wordLength = word.Length;

            if (minLength == null && maxLength == null)
            {
                throw new ArgumentException("specidy at least one of limitation ! (min or max)");
            }

            if (minLength != null && wordLength < minLength)
            {
                return false;
            }

            if (maxLength != null && wordLength > maxLength)
            {
                return false;
            }

            return true;
        }
        //End check length function

        //Start get string value function
        public static string GetStringValue()
        {
            string word = Console.ReadLine();
            return word;
        }
        //End get string value function
    }
}
