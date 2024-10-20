using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBreath : MonoBehaviour
{
    public GameObject breathing;  // Đối tượng đại diện cho trạng thái thở (có thể là hiệu ứng hay âm thanh)

    // Hàm để gọi khi nhấn giữ nút
    public void OnButtonPress()
    {
        if (breathing != null)
        {
            breathing.SetActive(false);  // Tắt thở khi nhấn giữ
        }
    }

    // Hàm để gọi khi thả nút ra
    public void OnButtonRelease()
    {
        if (breathing != null)
        {
            breathing.SetActive(true);  // Bật thở lại khi thả nút
        }
    }
}
