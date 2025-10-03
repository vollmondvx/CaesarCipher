int key = 0;
string encryptedMsg = "";


int numbersOfArgs = args.Length;
if (numbersOfArgs == 0)
{
    Console.WriteLine("No arguments provided.");
    Environment.Exit(-1);
}

switch (args[0])
{
    case "-ek":
        if (numbersOfArgs == 1)
        {
            Console.WriteLine("Missing other parameters.");
            Environment.Exit(-1);
        }
        if (Int32.TryParse(args[1], out key))
        {
            //Error handling for message parameter
            try
            {
                if (String.IsNullOrEmpty(args[2]) || String.IsNullOrWhiteSpace(args[2]))
                {
                    Console.WriteLine("You forgot to provide the text to encrypt.");
                    Environment.Exit(-1);
                }
                //Call encrypt method with key specified by user
                encryptedMsg = Encrypt(args[2], key);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Third argument missing.");
                Environment.Exit(-1);
            }


        }
        else
        {
            Console.WriteLine("The key has to be a integer between 1 and 25");
            Environment.Exit(-1);
        }
        break;
    default:
        Console.WriteLine("Missing and/or Invalid arguments.");
        Help();
        break;
}


Console.WriteLine(encryptedMsg);


static string Encrypt(string msg, int key)
{
    char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    int size = letters.Length;
    string encrypted = "";

    foreach (char letter in msg)
    {
        int index = Array.IndexOf(letters, letter);
        if (index == -1)
        {
            encrypted += letter;
            continue;
        }

        int newIndex = (index + key) % size;
        encrypted += letters[newIndex];
    }
    return encrypted;
}

static void Help()
{
    Console.WriteLine("Usage: CaesarCipher [OPTION]... [TEXT]...");
    Console.WriteLine("Encrypt, Decrypt with a key or Bruteforcing Caesar Cipher...");
    Console.WriteLine("-e\tEncrypt");
    Console.WriteLine();
    Console.WriteLine("\t-k\tSpecify a key, if this option is missed, the cipher will use a random generated key");
    Console.WriteLine();
    Console.WriteLine("-d\tDecrypt");
    Console.WriteLine();
    Console.WriteLine("\t-k\tSpecify a key, if this option is missed, the cipher will use the bruteforcing option");
    Console.WriteLine();
    Console.WriteLine("-ek\tShorting for encryption with a key");
    Console.WriteLine("-dk\tShorting for decryption with a key");
    Console.WriteLine();
    Console.WriteLine("-b\tBruteforce, the result will be generate in a file");

}


//string encrypted = Encrypt(msg, key);
//Console.WriteLine(encrypted);
//Console.WriteLine(Encrypt(encrypted, 26 - key));
return 0;