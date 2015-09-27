using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlphanumericCodes
{
    class Program
    {
        static void Main(string[] args)
        {
            //Generates alphanumeric codes. Doesn't check for duplicates, I usually do that afterwards with excel.

            const string StringWithAllowedCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var ArrayOfAllowedCharacters = StringWithAllowedCharacters.ToCharArray();

            // Size of the code... 6 characters.
            const int CodeSize = 6;
            // Number of codes to generate 
            const int AmountOfCodes = 20;
            // This will be filled with characters to create the code.
            var CodeBuffer = new Char[CodeSize];

            var index = 0;
            var randomNumber = new Random();

            Console.WriteLine("Using the range '{0}', to generate {1} codes of {2} digits each", StringWithAllowedCharacters, AmountOfCodes, CodeSize);

            for (var i = 1; i <= AmountOfCodes; i++)
            {
                for (var CharIndex = 0; CharIndex <= CodeSize - 1; CharIndex++)
                {
                    index = randomNumber.Next(0, ArrayOfAllowedCharacters.Length - 1);
                    CodeBuffer[CharIndex] = ArrayOfAllowedCharacters[index];
                }
                Console.WriteLine(new string(CodeBuffer));
            }
            Console.ReadLine();
        }
    }
}
