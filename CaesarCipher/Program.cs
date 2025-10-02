string msg = "HELLO";
int key = 20;



Console.WriteLine(Encrypt(msg, key));

static string Encrypt(string msg, int key)
{
    char[] letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
    int size = letters.Length;
    Console.WriteLine(size);
    string encrypted = "";

    foreach (char letter in msg)
    {
        int index = Array.IndexOf(letters, letter);

        int newIndex = (index + key) > 26 ? index + key - size : index + key;
        encrypted += letters[newIndex];
    }
    return encrypted;
}