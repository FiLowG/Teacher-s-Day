using UnityEngine;
using UnityEngine.UI;

public class PassVali_CanTeen : MonoBehaviour
{
    public Text text1, text2, text3, text4;
    private int[] password = { 2, 0, 0, 6 };
    private int[] currentInput = { 0, 0, 0, 0 };
    public GameObject Vali_OpenYet;
    public GameObject Vali_Opened;

    public void IncreaseText1()
    {
        currentInput[0] = (currentInput[0] + 1) % 10;
        text1.text = currentInput[0].ToString();
        CheckPassword();
    }

    public void IncreaseText2()
    {
        currentInput[1] = (currentInput[1] + 1) % 10;
        text2.text = currentInput[1].ToString();
        CheckPassword();
    }

    public void IncreaseText3()
    {
        currentInput[2] = (currentInput[2] + 1) % 10;
        text3.text = currentInput[2].ToString();
        CheckPassword();
    }

    public void IncreaseText4()
    {
        currentInput[3] = (currentInput[3] + 1) % 10;
        text4.text = currentInput[3].ToString();
        CheckPassword();
    }

    private void CheckPassword()
    {
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
