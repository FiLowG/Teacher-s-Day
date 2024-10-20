using UnityEngine;
using UnityEngine.UI;

public class PassVali_CanTeen : MonoBehaviour
{
    public Text text1, text2, text3, text4;  // Khai báo 4 biến Text để hiển thị số
    private int[] password = { 2, 0, 0, 6 }; // Mật mã gồm 4 số
    private int[] currentInput = { 0, 0, 0, 0 }; // Mảng lưu trữ trạng thái hiện tại của người dùng
    public GameObject Vali_OpenYet;
    public GameObject Vali_Opened;
    // Hàm được gọi khi nhấn nút button1 để tăng giá trị của text1
    public void IncreaseText1()
    {
        currentInput[0] = (currentInput[0] + 1) % 10;  // Tăng giá trị và quay về 0 nếu vượt quá 9
        text1.text = currentInput[0].ToString();  // Hiển thị giá trị mới lên text1
        CheckPassword();  // Kiểm tra xem mật mã đã đúng chưa
    }

    // Hàm được gọi khi nhấn nút button2 để tăng giá trị của text2
    public void IncreaseText2()
    {
        currentInput[1] = (currentInput[1] + 1) % 10;  // Tăng giá trị và quay về 0 nếu vượt quá 9
        text2.text = currentInput[1].ToString();  // Hiển thị giá trị mới lên text2
        CheckPassword();  // Kiểm tra xem mật mã đã đúng chưa
    }

    // Hàm được gọi khi nhấn nút button3 để tăng giá trị của text3
    public void IncreaseText3()
    {
        currentInput[2] = (currentInput[2] + 1) % 10;  // Tăng giá trị và quay về 0 nếu vượt quá 9
        text3.text = currentInput[2].ToString();  // Hiển thị giá trị mới lên text3
        CheckPassword();  // Kiểm tra xem mật mã đã đúng chưa
    }

    // Hàm được gọi khi nhấn nút button4 để tăng giá trị của text4
    public void IncreaseText4()
    {
        currentInput[3] = (currentInput[3] + 1) % 10;  // Tăng giá trị và quay về 0 nếu vượt quá 9
        text4.text = currentInput[3].ToString();  // Hiển thị giá trị mới lên text4
        CheckPassword();  // Kiểm tra xem mật mã đã đúng chưa
    }

    // Hàm kiểm tra nếu giá trị nhập vào trùng với mật mã
    private void CheckPassword()
    {
        // Nếu tất cả giá trị nhập vào đều khớp với mật mã
        if (currentInput[0] == password[0] &&
            currentInput[1] == password[1] &&
            currentInput[2] == password[2] &&
            currentInput[3] == password[3])
        {
            Vali_Opened.SetActive(true);
            Vali_OpenYet.SetActive(false);
        }
    }
}
