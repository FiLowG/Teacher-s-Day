using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;
using System;

public class AuthManager : MonoBehaviour
{
    // Input fields cho đăng ký
    public InputField registerUsernameInput; // Tên người dùng cho đăng ký
    public InputField registerPasswordInput; // Mật khẩu cho đăng ký
    public InputField confirmPasswordInput;   // Nhập lại mật khẩu (chỉ để làm cảnh)

    // Input fields cho đăng nhập
    public InputField loginUsernameInput; // Tên người dùng cho đăng nhập
    public InputField loginPasswordInput; // Mật khẩu cho đăng nhập

    private string filePath; // Đường dẫn đến file lưu trữ

    void Start()
    {
        // Thiết lập đường dẫn file tại persistentDataPath
        filePath = Path.Combine(Application.persistentDataPath, "userData.txt");
    }

    // Hàm đăng ký người dùng
    public void Register()
    {
        string username = registerUsernameInput.text;
        string password = registerPasswordInput.text;

        // Mã hóa nhị phân
        string encryptedUsername = Encrypt(username);
        string encryptedPassword = Encrypt(password);

        // Lưu thông tin vào file
        SaveToFile(encryptedUsername, encryptedPassword);
        Debug.Log("Registered User: " + encryptedUsername);

        // Hiển thị thông tin đã lưu
        Debug.Log("File Path: " + filePath);
        Debug.Log("Username: " + encryptedUsername);
        Debug.Log("Password: " + encryptedPassword);
    }

    // Hàm lưu thông tin vào file
    private void SaveToFile(string username, string password)
    {
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            writer.WriteLine(username + "," + password); // Lưu username và password
        }
        Debug.Log("User data saved to: " + filePath);
    }

    // Hàm đăng nhập
    public void Login()
    {
        string username = loginUsernameInput.text;
        string password = loginPasswordInput.text;

        // Mã hóa nhị phân
        string encryptedUsername = Encrypt(username);
        string encryptedPassword = Encrypt(password);

        // Kiểm tra đăng nhập
        if (LoadFromFile(encryptedUsername, encryptedPassword))
        {
            Debug.Log("Login successful with Username: " + encryptedUsername);
        }
        else
        {
            Debug.Log("Invalid credentials.");
        }
    }

    // Hàm đọc thông tin từ file
    private bool LoadFromFile(string username, string password)
    {
        if (File.Exists(filePath)) // Kiểm tra file tồn tại
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (var line in lines) // Đọc từng dòng trong file
            {
                var data = line.Split(',');
                if (data.Length == 2)
                {
                    if (data[0] == username && data[1] == password) // Kiểm tra thông tin
                    {
                        return true;
                    }
                }
            }
        }
        return false; // Không tìm thấy thông tin
    }

    // Hàm mã hóa nhị phân
    private string Encrypt(string input)
    {
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input);
        string binaryString = string.Join("", bytes.Select(b => Convert.ToString(b, 2).PadLeft(8, '0')));
        return binaryString; // Trả về chuỗi nhị phân
    }
}
