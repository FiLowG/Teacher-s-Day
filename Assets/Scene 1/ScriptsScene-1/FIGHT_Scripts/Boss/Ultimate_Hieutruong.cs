using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ultimate_HieuTruong : MonoBehaviour
{
    public Image HealBar;
    public Image healBar_Player;
    public GameObject final; // Thêm biến final
    public Text countdownText; // Biến Text để hiển thị đếm ngược
    public float countdownTime = 90f; // Thời gian đếm ngược ban đầu (90s)
    private bool isFinalActivated = false; // Kiểm tra đã kích hoạt final chưa

    void Start()
    {
        countdownTime = 90f;
        StartCoroutine(HealUltimate());
        StartCoroutine(DameUltimate());
    }

    void Update()
    {
        
        if (countdownTime > 0)
        {
            countdownTime -= Time.deltaTime;
            countdownText.text = Mathf.Ceil(countdownTime).ToString("F0"); // Cập nhật text đếm ngược
        }
        else if (!isFinalActivated) // Kích hoạt final một lần khi hết thời gian
        {
            countdownText.text = "0";
            final.SetActive(true);
            isFinalActivated = true;
        }
    }

    IEnumerator HealUltimate()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            HealBar.fillAmount += 0.02f;
        }
    }

    IEnumerator DameUltimate()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            healBar_Player.fillAmount -= 0.02f;
        }
    }
}
