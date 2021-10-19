using System;
using System.Text;

namespace UsmanUmerTest.Cryptographer
{
    public class Cryptographer
    {
        public (string key, string salt) Encrypt(string input)
        {
            var outputCharArray = new char[input.Length];
            var salt = new char[input.Length];

            // Adding 7 to the digit and dividing 10
            for (var i = 0; i < input.Length; i++)
            {
                var digit = (int)char.GetNumericValue(input[i]);
                digit += 7;
                var quotient = digit / 10;
                digit = digit % 10;
                salt[i] = char.Parse(quotient.ToString());
                outputCharArray[i] = char.Parse(digit.ToString());
            }

            // Swapping 1st digit with 4th
            (outputCharArray[0], outputCharArray[3]) = (outputCharArray[3], outputCharArray[0]);

            // Swapping 2nd digit with 5th
            (outputCharArray[1], outputCharArray[4]) = (outputCharArray[4], outputCharArray[1]);

            // Swapping 3rd digit with 6th
            (outputCharArray[2], outputCharArray[5]) = (outputCharArray[5], outputCharArray[2]);


            return (new string(outputCharArray), new string(salt));
        }

        public string Decrypt(string key, string salt)
        {
            var keyToProcess = key.ToCharArray();
            var outputCharArray = new char[key.Length];

            // Swapping 1st digit with 4th
            (keyToProcess[0], keyToProcess[3]) = (keyToProcess[3], keyToProcess[0]);

            // Swapping 2nd digit with 5th
            (keyToProcess[1], keyToProcess[4]) = (keyToProcess[4], keyToProcess[1]);

            // Swapping 3rd digit with 6th
            (keyToProcess[2], keyToProcess[5]) = (keyToProcess[5], keyToProcess[2]);

            // subtracting 7 to the digit and converting it to the actual digit using salt
            for (var i = 0; i < keyToProcess.Length; i++)
            {
                var digit = (int)char.GetNumericValue(keyToProcess[i]);
                digit = (10 * (int)char.GetNumericValue(salt[i])) + digit;
                digit -= 7;
                outputCharArray[i] = char.Parse(Math.Abs(digit).ToString());
            }

            return new string(outputCharArray);
        }
    }
}
