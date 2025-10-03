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
    case "encrypt":
        if (numbersOfArgs == 1)
        {
            Console.WriteLine("Missing other parameters.");
            Environment.Exit(-1);
        }
        if (Int32.TryParse(args[1], out key))
        {
            //Exit if key is negative
            if (key < 0)
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
            Console.WriteLine($"Expected a key but found: {args[1]}");
            Environment.Exit(-1);
        }
        break;

    case "decrypt":
        break;
    case "crack":
        break;
    case "help":
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
    // Describe usage. This tool will use a subcommand style for cli design instead of GNU style.

}


//string encrypted = Encrypt(msg, key);
//Console.WriteLine(encrypted);
//Console.WriteLine(Encrypt(encrypted, 26 - key));
return 0;