using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PasswordInput : MonoBehaviour
{
    public Text passwordText;
    private string password = "";
    public GameObject overPass;
    public GameObject open;
    public GameObject wrong;

    void Start()
    {
    }

    public void OnNumberButtonPressed(int number)
    {
        if (password.Length < 8)
        {
            password += number.ToString();
            UpdatePasswordText();
        }
    }

    public void OnDeleteButtonPressed()
    {
        if (password.Length > 0)
        {
            password = password.Substring(0, password.Length - 1);
            UpdatePasswordText();
        }
    }

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
    }

    private void UpdatePasswordText()
    {
        passwordText.text = password;
    }

    IEnumerator wrongpass()
    {
        passwordText.text = ".";
        wrong.SetActive(true);
        yield return new WaitForSeconds(1f);
        wrong.SetActive(false);
        password = "";
        passwordText.text = "";
    }
}
