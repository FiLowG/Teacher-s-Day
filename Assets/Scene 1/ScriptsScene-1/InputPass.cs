using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.ShaderData;

public class PasswordInput : MonoBehaviour
{
    public Text passwordText;  // Text UI để hiển thị password
    private string password = "";  // Chuỗi lưu password tạm thời
    public GameObject overPass;
    public GameObject open;
    public GameObject wrong;

    void Start()
    {
    }
    public void OnNumberButtonPressed(int number)
    {
     
        if (password.Length < 8)  // Giới hạn độ dài password tối đa (6 ký tự chẳng hạn)
        {
            password += number.ToString();  // Thêm số vào chuỗi password
            UpdatePasswordText();
        }
    }

    // Phương thức gọi khi nhấn nút Delete
    public void OnDeleteButtonPressed()
    {
        if (password.Length > 0)
        {
            password = password.Substring(0, password.Length - 1);  // Xóa ký tự cuối cùng
            UpdatePasswordText();
        }
    }

    // Phương thức gọi khi nhấn nút OK
    public void OnOKButtonPressed()
    {
       if (passwordText.text == "13072010")
        {
            open.SetActive(true);
            overPass.SetActive(false);
        }
       else
        {
            StartCoroutine(wrongpass());
            
        }
        // Thực hiện các xử lý khác sau khi nhập password như kiểm tra tính hợp lệ.
    }

    // Cập nhật Text UI sau mỗi lần thay đổi password
    private void UpdatePasswordText()
    {
        passwordText.text = password;
    }
    IEnumerator wrongpass()
    {
        passwordText.text = ".";
        wrong.SetActive(true);
        yield return new WaitForSeconds(1f);  // Chờ 1 giây
        wrong.SetActive(false);   // Hiện đối tượng
        password = "";
        passwordText.text = "";
    }
}
