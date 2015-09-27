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
            //Generates alphanumeric codes. Doesn't check for duplicates, I usually do that afterwards with excel :)

            const string StringWithAllowedCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            char[] ArrayOfAllowedCharacters = StringWithAllowedCharacters.ToCharArray();

            const int CodeSize = 6;         // size of the code... 6 characters
            const int AmountOfCodes = 20;  //Number of codes to generate
            char[] CodeBuffer = new Char[CodeSize]; //this will be filled with characters to create the code                                         

            var index = 0;
            var random = new Random();

            Console.WriteLine("Using the range '{0}', to generate {1} codes of {2} digits each", StringWithAllowedCharacters, AmountOfCodes, CodeSize);

            for (int i = 1; i <= AmountOfCodes; i++)
            {
                for (int CharIndex = 0; CharIndex <= CodeSize - 1; CharIndex++) //for each of the 6 digits
                {
                    index = random.Next(0, StringWithAllowedCharacters.Length - 1);
                    CodeBuffer[CharIndex] = ArrayOfAllowedCharacters[index]; //chose a random character from the source
                }
                Console.WriteLine(new string(CodeBuffer));
            }
            Console.ReadLine();
        }
    }
}
