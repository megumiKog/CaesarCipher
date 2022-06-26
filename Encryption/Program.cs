using System;

namespace Encryption
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("what is your message to encrypt?");
            string message = Console.ReadLine().ToLower(); //Adding To.Lower() in order to avoid errors caused by different letter case.


            string encodedString = Encrypt(message, 3);
            Console.WriteLine($"Your encodes message is: {encodedString}");

            Console.WriteLine("Do you want to decode your message? Enter the number( 1.YES / 2.NO )");
            string answer = Console.ReadLine();

            if (answer == "1")
            {
                string decodedString = Decrypt(encodedString, 3);
                Console.WriteLine($"Your decoded message is: {decodedString}");
            }
            else if (answer == "2")
            {
                Console.WriteLine($"Thank you and welcome back again.");
            }
            else
            {
                Console.WriteLine($"Did you mean NO? Thank you and welcome back again.");
            }

        }

        static string Encrypt(string message, int key)
        {
            char[] alphabet = new char[]
            { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

            char[] secretMessage = message.ToCharArray(); //Use ToCharArray() to convert string to array of char
            char[] encryptedMessage = new char[secretMessage.Length]; // Initializing an array of char for encryption 

            for (int i = 0; i < secretMessage.Length; i++) // accessing each elements of char
            {
                char ch = secretMessage[i]; // just assign the element to char variable ch
                bool character = Char.IsLetter(ch); // create a boolean variable of whether the element is a character or not, in order to use it in the if-statement below

                if (!character) // If character is false (meaning it is not a character, but a special letter)
                {
                    encryptedMessage[i] = ch;     // Store it without encrypting        
                }
                else // If character is true (meaning it is a character)
                { // encrypt it using the alphabet array and store it in encryptedMessage 
                    int letterPosition = Array.IndexOf(alphabet, ch);
                    int newLetterPosition = (letterPosition + key) % 26;
                    char letterEncoded = alphabet[newLetterPosition];
                    encryptedMessage[i] = letterEncoded;
                }
            }
            // String.Join("", charOfArray) is converting char array to string
            string encodedString = String.Join("", encryptedMessage);
            return encodedString;
        }

        static string Decrypt(string encodedString, int key)
        {
            char[] alphabet = new char[]
            { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

            char[] encodedChar = encodedString.ToCharArray(); //Use ToCharArray() to convert string to array of char
            char[] decryptedChar = new char[encodedChar.Length]; // Initializing an array of char for the decrypted message

            for (int i = 0; i < encodedChar.Length; i++) // accessing each elements of char
            {
                char ch = encodedChar[i]; // just assign the element to char variable ch
                bool character = Char.IsLetter(ch); // create a boolean variable of whether the element is a character or not, in order to use it in the if-statement below

                if (!character) // If character is false (meaning it is not a character, but a special letter)
                {
                    decryptedChar[i] = ch;     // Store it without encrypting        
                }
                else // If character is true (meaning it is a character)
                { // encrypt it using the alphabet array and store it in encryptedMessage 
                    int letterPosition = Array.IndexOf(alphabet, ch);
                    int newLetterPosition = (letterPosition - key) % 26;
                    char letterDecoded = alphabet[newLetterPosition];
                    decryptedChar[i] = letterDecoded;
                }
            }
            // String.Join("", charOfArray) is converting char array to string
            string decodedString = String.Join("", decryptedChar);
            return decodedString;

        }
    }
}