using System.Drawing;

string msg = "HELLO,";
int key = 20;

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
string encrypted = Encrypt(msg, key);
Console.WriteLine(encrypted);
Console.WriteLine(Encrypt(encrypted, 26 - key));