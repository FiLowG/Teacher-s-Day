using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;
using System;
using UnityEngine.SceneManagement;

public class AuthManager : MonoBehaviour
{
    public InputField registerUsernameInput;
    public InputField registerPasswordInput;
    public InputField confirmPasswordInput;

    public InputField loginUsernameInput;
    public InputField loginPasswordInput;

    private string filePath;

    void Start()
    {
        filePath = Path.Combine(Application.persistentDataPath, "userData.txt");
    }

    public void Register()
    {
        string username = registerUsernameInput.text;
        string password = registerPasswordInput.text;

        string encryptedUsername = Encrypt(username);
        string encryptedPassword = Encrypt(password);

        SaveToFile(encryptedUsername, encryptedPassword);
    }

    private void SaveToFile(string username, string password)
    {
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine(username + "," + password);
        }
    }

    public void Login()
    {
        string username = loginUsernameInput.text;
        string password = loginPasswordInput.text;

        string encryptedUsername = Encrypt(username);
        string encryptedPassword = Encrypt(password);

        if (LoadFromFile(encryptedUsername, encryptedPassword))
        {
            SceneManager.LoadScene("LOBBY");
        }
    }

    private bool LoadFromFile(string username, string password)
    {
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var data = line.Split(',');
                if (data.Length == 2)
                {
                    if (data[0] == username && data[1] == password)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    private string Encrypt(string input)
    {
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input);
        string binaryString = string.Join("", bytes.Select(b => Convert.ToString(b, 2).PadLeft(8, '0')));
        return binaryString;
    }
}
