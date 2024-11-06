using UnityEngine;
using UnityEngine.UI;

public class PassVali_CanTeen : MonoBehaviour
{
    public Text[] texts;
    public int passwordInput;
    private int[] password;
    private int[] currentInput;
    public GameObject Vali_OpenYet;
    public GameObject need_Off;
    public GameObject need_Off2;
    public GameObject Vali_Opened;
    public GameObject need_On;

    private void Start()
    {
        SetPasswordFromInput();
        currentInput = new int[texts.Length];
        UpdateTextDisplay();
    }

    private void SetPasswordFromInput()
    {
        // Chuyển đổi passwordInput thành mảng số nguyên
        string passwordStr = passwordInput.ToString("D" + texts.Length); // Chuyển đổi với số chữ số cố định
        password = new int[passwordStr.Length];

        for (int i = 0; i < passwordStr.Length; i++)
        {
            password[i] = int.Parse(passwordStr[i].ToString());
        }
    }

    public void IncreaseText(int index)
    {
        if (index < 0 || index >= texts.Length) return; // Kiểm tra index hợp lệ

        currentInput[index] = (currentInput[index] + 1) % 10;
        texts[index].text = currentInput[index].ToString();
        CheckPassword();
    }

    private void UpdateTextDisplay()
    {
        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].text = currentInput[i].ToString();
        }
    }

    private void CheckPassword()
    {
        for (int i = 0; i < password.Length; i++)
        {
            if (currentInput[i] != password[i])
                return;
        }

        Vali_Opened.SetActive(true);
        if (need_On != null)
        {
            need_On.SetActive(true);
        }
        Vali_OpenYet.SetActive(false);
        if (need_Off != null)
        {
            need_Off.SetActive(false);
        }
        if (need_Off2 != null)
        {
            need_Off2.SetActive(false);
        }
    }
}
