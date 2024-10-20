using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shield_MinusDame : MonoBehaviour
{
    public Image HealBar; // Thanh máu của player

    private float previousHealth; // Lưu lượng máu ở khung hình trước
    private float currentHealth; // Lưu lượng máu hiện tại
    private GameStatsManager objectValue;
    void Start()
    {
        // Giả định thanh máu bắt đầu đầy đủ
        currentHealth = HealBar.fillAmount * 100f;
        previousHealth = currentHealth;
    }

    void Update()
    {
        // Cập nhật lượng máu hiện tại
        currentHealth = HealBar.fillAmount * 100f;

        // Tính toán lượng máu bị trừ
        float healthDifference = previousHealth - currentHealth;

        // Nếu có sự thay đổi về máu (tức là bị trừ)
        if (healthDifference > 0)
        {
            // Hồi lại 10% lượng máu đã mất
            float healAmount = healthDifference * objectValue.GetPlayerShield()/10;

            // Làm tròn giá trị healAmount
            healAmount = Mathf.Floor(healAmount);

            currentHealth += healAmount;

            // Đảm bảo không vượt quá 100%
            if (currentHealth > 100f)
            {
                currentHealth = 100f;
            }

            // Cập nhật lại thanh máu
            HealBar.fillAmount = currentHealth / 100f;

            Debug.Log($"Health decreased by: {healthDifference}, healed back: {healAmount}");
        }

        // Cập nhật máu trước đó cho lần so sánh tiếp theo
        previousHealth = currentHealth;
    }
}
