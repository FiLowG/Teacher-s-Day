using System.Collections;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class Blood_Screen : MonoBehaviour
{
    public Image HealBar; // Thanh máu của player
    public GameObject Effects; // Hiệu ứng khi máu giảm

    private float previousHealth; // Lưu lượng máu ở khung hình trước
    private float currentHealth; // Lưu lượng máu hiện tại

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

        // So sánh nếu máu hiện tại thấp hơn máu trước đó
        if (currentHealth < previousHealth)
        {
            // Kích hoạt hiệu ứng
            StartCoroutine(ShowDamageEffect());
        }

        // Cập nhật máu trước đó cho lần so sánh tiếp theo
        previousHealth = currentHealth;
    }

    // Coroutine để kích hoạt và tắt hiệu ứng sau 1s
    private IEnumerator ShowDamageEffect()
    {
        // Bật hiệu ứng
        Effects.SetActive(true);

        // Chờ 1 giây
        yield return new WaitForSeconds(1.0f);

        // Tắt hiệu ứng
        Effects.SetActive(false);
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Boss_Attack"))
        {
            HealBar.fillAmount -= 0.15f;
        }
    }
}
