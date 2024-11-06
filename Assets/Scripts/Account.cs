using System.Collections;
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

    // Các biến object để thông báo lỗi
    public GameObject object1; // Thông báo: Tài khoản hoặc mật khẩu bị bỏ trống
    public GameObject object2; // Thông báo: Tài khoản đã tồn tại
    public GameObject object3; // Thông báo: Tài khoản không tồn tại
    public GameObject object4; // Thông báo: Tài khoản hoặc mật khẩu dưới 5 ký tự
    public GameObject LoginScreen;
    public GameObject SignupScreen;

    void Start()
    {
        filePath = Path.Combine(Application.persistentDataPath, "userData.txt");
        // Ẩn tất cả các thông báo lỗi ban đầu
        HideErrorObjects();
    }

    public void Register()
    {
        HideErrorObjects();

        string username = registerUsernameInput.text;
        string password = registerPasswordInput.text;

        // Kiểm tra nếu tên tài khoản hoặc mật khẩu bị bỏ trống
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            ActivateErrorObject(object1); // Hiển thị lỗi: Tài khoản hoặc mật khẩu bị bỏ trống
            return;
        }
        if (IsUsernameTaken(username))
        {
            ActivateErrorObject(object2); // Hiển thị lỗi: Tài khoản đã tồn tại
            return;
        }
        // Kiểm tra nếu tên tài khoản hoặc mật khẩu dưới 5 ký tự
        if (username.Length < 5 || password.Length < 5)
        {
            ActivateErrorObject(object4); // Hiển thị lỗi: Tài khoản hoặc mật khẩu dưới 5 ký tự
            return;
        }

        // Kiểm tra nếu tên tài khoản đã tồn tại
       

        // Nếu tất cả điều kiện đều thỏa mãn, lưu tài khoản và chuyển màn hình
        string encryptedUsername = Encrypt(username);
        string encryptedPassword = Encrypt(password);
        SaveToFile(encryptedUsername, encryptedPassword);

        LoginScreen.SetActive(true);
        SignupScreen.SetActive(false);
       
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
        HideErrorObjects();

        string username = loginUsernameInput.text;
        string password = loginPasswordInput.text;

        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            ActivateErrorObject(object1); // Bỏ trống tài khoản hoặc mật khẩu
            return;
        }

        string encryptedUsername = Encrypt(username);
        string encryptedPassword = Encrypt(password);

        if (!LoadFromFile(encryptedUsername, encryptedPassword))
        {
            ActivateErrorObject(object3); // Tài khoản không tồn tại
            return;
        }

        SceneManager.LoadScene("LOBBY");
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

    private bool IsUsernameTaken(string username)
    {
        if (File.Exists(filePath))
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var data = line.Split(',');
                if (data.Length == 2 && data[0] == Encrypt(username))
                {
                    return true;
                }
            }
        }
        return false;
    }

    private void HideErrorObjects()
    {
        object1.SetActive(false);
        object2.SetActive(false);
        object3.SetActive(false);
        object4.SetActive(false);
    }

    private void ActivateErrorObject(GameObject obj)
    {
        obj.SetActive(true);
        StartCoroutine(HideAfterDelay(obj, 2f)); // Gọi coroutine để ẩn sau 2 giây
    }

    private IEnumerator HideAfterDelay(GameObject obj, float delay)
    {
        yield return new WaitForSeconds(delay);
        obj.SetActive(false);
    }

    private string Encrypt(string input)
    {
        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(input);
        string binaryString = string.Join("", bytes.Select(b => Convert.ToString(b, 2).PadLeft(8, '0')));
        return binaryString;
    }
}
