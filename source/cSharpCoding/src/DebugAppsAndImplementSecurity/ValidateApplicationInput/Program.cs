using System;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace ValidateApplicationInput
{
    class Program
    {
        static void Main(string[] args)
        {
            Validator();
            EncryptSomeText();
            ExportPublicKey();
            InitializeSecureString();
        }

        // The Parse and TryParse methods can be used when you have a string that you want to convert to a specific data type.
        private static void Validator()
        {
            string value = "true";
            // The bool.Parse method uses the static readonly fields TrueString and FalseString to see whether your string is true or false. 
            // If your string contains an invalid value, Parse throws a FormatException. 
            // If you pass a null value for the string, you will get an ArgumentNullException. 
            // Parse should be used if you are certain the parsing will succeed.
            bool b = bool.Parse(value);
            Console.WriteLine(b); // displays True

            // You use TryParse if you are not sure that the parsing will succeed. 
            // You don’t want an exception to be thrown and you want to handle invalid conversion gracefully.

            string value2 = "1";
            int result;
            // TryParse returns a Boolean value that indicates whether the value could be parsed. 
            // The out parameter contains the resulting value when the operation is successful. 
            // If the parsing succeeds, the variable holds the converted value; otherwise, it contains the initial value
            bool success = int.TryParse(value2, out result);
            if (success)
            {
                Console.WriteLine("value is a valid integer, result contains the value");
            }
            else
            {
                Console.WriteLine("value is not a valid integer");
            }

            // When using the bool.Parse or bool.TryParse methods, you don’t have any extra parsing options. 
            // When parsing numbers, you can supply extra options for the style of the number and the specific culture that you want to use
            // Using configuration options when parsing a number
            CultureInfo english = new CultureInfo("En");
            CultureInfo dutch = new CultureInfo("Nl");
            string value3 = "€19,95";
            decimal d = decimal.Parse(value3, NumberStyles.Currency, dutch);
            Console.WriteLine(d.ToString(english)); // Displays 19.95


            // The .NET Framework also offers the Convert class to convert between base types. 
            int i = Convert.ToInt32(null);
            Console.WriteLine(i); // Displays 0
            // A difference between Convert and the Parse methods is that Parse takes a string only as
            // input, while Convert can also take other base types as input.
            double dNumber = 23.15;
            // Be careful with OverfloowException!!!
            int iNumber = Convert.ToInt32(dNumber);
            Console.WriteLine(iNumber); // Displays 23

            // Using regular expressions
            // Example of using a RegEx expression to remove all excessive use of white space. 
            // Every single space is allowed but multiple spaces are replaced with a single space.
            // Validate a ZIP Code with a regular expression
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex(@"[ ]{ 2,}", options);
            string input = "1 2 3 4 5";
            string result5 = regex.Replace(input, " ");
            Console.WriteLine(result5); // Displays 1 2 3 4 5

            // parse a text field where the user enters an amount of money.
            decimal.TryParse("4.6", NumberStyles.Currency, CultureInfo.CurrentUICulture, out var result6);
            Console.WriteLine(result6);
        }

        public static void EncryptSomeText()
        {
            string original = "My secret data!";
            using (SymmetricAlgorithm symmetricAlgorithm = new AesManaged())
            {
                byte[] encrypted = Encrypt(symmetricAlgorithm, original);
                string roundtrip = Decrypt(symmetricAlgorithm, encrypted);
                // Displays: My secret data!
                Console.WriteLine("Original: {0}", original);
                Console.WriteLine("Round Trip: {0}", roundtrip);
            }
        }

        private static byte[] Encrypt(SymmetricAlgorithm aesAlg, string plainText)
        {
            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }
                    return msEncrypt.ToArray();
                }
            }
        }

        private static string Decrypt(SymmetricAlgorithm aesAlg, byte[] cipherText)
        {
            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
            using (MemoryStream msDecrypt = new MemoryStream(cipherText))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
        }

        // The public key is the part you want to publish so others can use it to encrypt data. 
        // You can send it to someone directly or publish it on a website that belongs to you.
        private static void ExportPublicKey()
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            string publicKeyXML = rsa.ToXmlString(false);
            string privateKeyXML = rsa.ToXmlString(true);
            Console.WriteLine("Export Public key");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine(publicKeyXML);
            Console.WriteLine("Export Private key");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine(privateKeyXML);
            EncryptDecryptAsymmetric(publicKeyXML, privateKeyXML);
        }

        private static void EncryptDecryptAsymmetric(string publicKey, string privateKey)
        {
            // Using a public and private key to encrypt and decrypt data:
            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            byte[] dataToEncrypt = ByteConverter.GetBytes("My Secret Data!");
            byte[] encryptedData;
            StoringThePrivateKey(dataToEncrypt);
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                RSA.FromXmlString(publicKey);
                encryptedData = RSA.Encrypt(dataToEncrypt, false);
            }
            byte[] decryptedData;
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                RSA.FromXmlString(privateKey);
                decryptedData = RSA.Decrypt(encryptedData, false);
            }
            string decryptedString = ByteConverter.GetString(decryptedData);
            Console.WriteLine(decryptedString); // Displays: My Secret Data!
        }

        // The .NET Framework offers a secure location for storing asymmetric keys in a key container. 
        // A key container can be specific to a user or to the whole machine
        private static void StoringThePrivateKey(byte[] dataToEncrypt)
        {
            // Using a key container for storing an asymmetric key
            string containerName = "SecretContainer";
            CspParameters csp = new CspParameters() { KeyContainerName = containerName };
            byte[] encryptedData;
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(csp))
            {
                encryptedData = RSA.Encrypt(dataToEncrypt, false);
            }
            // Loading the key from the key container is the exact same process.
        }

        // As you can see, the SecureString is used with a using statement, so the Dispose method is
        // called when you are done with the string so that it doesn’t stay in memory any longer then
        // strictly necessary.
        private static void InitializeSecureString()
        {
            // Initializing a SecureString
            using (SecureString secureString = new SecureString())
            {
                Console.WriteLine("-------------------------------");
                Console.Write("Please enter password: ");
                while (true)
                {
                    ConsoleKeyInfo cki = Console.ReadKey(true);
                    if (cki.Key == ConsoleKey.Enter) break;
                    secureString.AppendChar(cki.KeyChar);
                    Console.Write("*");
                }
                secureString.MakeReadOnly();
                ConvertToUnsecureString(secureString);
            }
        }

        // At some point, you probably want to convert the SecureString back to a normal string so
        // you can use it. The .NET Framework offers some special functionality for this. It’s important
        // to make sure that the regular string is cleared from memory as soon as possible. This is why
        // there is a try/finally statement around the code. The finally statement makes sure that the
        // string is removed from memory even if there is an exception thrown in the code.
        // Getting the value of a SecureString:
        private static void ConvertToUnsecureString(SecureString securePassword)
        {
            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                // The Marshal class is located in the System.Runtime.InteropServices namespace. It offers five
                // methods that can be used when you are decrypting a SecureString. Those methods accept a
                // SecureString and return an IntPtr. Each method has a corresponding method that you need to
                // call to zero out the internal buffer
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Your password:");
                Console.WriteLine(Marshal.PtrToStringUni(unmanagedString));
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
    }
}
