using System;

namespace _04_Password_Validator
{
    class Program
    {
        static void Main(string[] args)
        {
            string sPassword;
            bool bInvalid = false;

            sPassword = Console.ReadLine();

            if (!CheckPasswordLength(sPassword))
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
                bInvalid = true;
            }

            if (!CheckPasswordCharacters(sPassword))
            {
                Console.WriteLine("Password must consist only of letters and digits");
                bInvalid = true;
            }

            if (!CheckPasswordMin2Digits(sPassword))
            {
                Console.WriteLine("Password must have at least 2 digits");
                bInvalid = true;
            }

            if (bInvalid == false)
            {
                Console.WriteLine("Password is valid");
            }

        }

        private static bool CheckPasswordLength(string sPassword)
        {
            return (sPassword.Length >= 6) && (sPassword.Length <= 10);
        }

        private static bool CheckPasswordCharacters(string sPassword)
        {

            foreach(char c in sPassword)
            {
                if(! ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || (c >= '0' && c <= '9')))
                {
                    return false;
                }
            }

            return true;

        }

        private static bool CheckPasswordMin2Digits(string sPassword)
        {
            int nDigits = 0;

            foreach (char c in sPassword)
            {
                if (c >= '0' && c <= '9')
                {
                    nDigits++;
                }
            }

            return nDigits >= 2;

        }
    }
}
