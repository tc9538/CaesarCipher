using System;

namespace CaesarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a message: ");
            string msg = (Console.ReadLine()).ToLower();
            Console.WriteLine("Enter a key: ");
            int key = Int32.Parse(Console.ReadLine());

            //Encrypt the input
            char[] secretMessage = msg.ToCharArray();
            char[] encryptedMessage = Encrypt(secretMessage, key);
            string encryptedOuput = String.Join("", encryptedMessage);

            //Decrypt the input
            char[] decryptedMessage = Decrypt(encryptedMessage,key);
            string decryptedOutput = String.Join("", decryptedMessage);

            //Print out all the results
            Console.WriteLine("The encrypted message is: " + encryptedOuput);
            Console.WriteLine("The decrypted message is: " + decryptedOutput);

        }

        
        public static char[] Encrypt(char[] inputMessage,int key)
        {
            char[] alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] encryptedMessage = new char[inputMessage.Length];
            char tempChar;
            int encryptedPosition;

            for (int i = 0; i < inputMessage.Length; i++)
            {
                if (Char.IsLetter(inputMessage[i]))
                {
                    tempChar = inputMessage[i];
                    encryptedPosition = (Array.IndexOf(alphabet, tempChar) + key) % 26;
                    encryptedMessage[i] = alphabet[encryptedPosition];
                }
                
            }

            return encryptedMessage;
        }

        public static char[] Decrypt(char[] inputMessage, int key)
        {
            char[] alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            char[] decryptedMessage = new char[inputMessage.Length];
            char tempChar;
            int decryptedPosition;

            for (int i = 0; i < inputMessage.Length; i++)
            {
                if (Char.IsLetter(inputMessage[i]))
                {
                    tempChar = inputMessage[i];
                    if(Array.IndexOf(alphabet, tempChar)-key<0)
                    {
                        decryptedPosition = (Array.IndexOf(alphabet, tempChar) - key) + 26;
                    }
                    else
                    {
                        decryptedPosition = (Array.IndexOf(alphabet, tempChar) - key) % 26;
                    }
                    decryptedMessage[i] = alphabet[decryptedPosition];
                }
            }

            return decryptedMessage;
        }
    }
}