using UnityEngine;

public class BlurToClear : MonoBehaviour
{
    public float fadeSpeed = 1;
    public int targetAlpha = 50; // Mức alpha nhập từ 0 đến 255
    private SpriteRenderer spriteRenderer;
    private Color spriteColor;

    void Start()
    {
        
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Lấy màu ban đầu của sprite và đặt alpha về 0 (mờ hoàn toàn)
        spriteColor = spriteRenderer.color;
        spriteColor.a = 0;
    }

    void Update()
    {
        // Chuyển giá trị alpha từ 0-255 sang 0-1
        float targetAlphaNormalized = targetAlpha / 255f;

        // Nếu alpha chưa đạt mức mong muốn, thì tăng alpha
        if (spriteColor.a < targetAlphaNormalized)
        {
            spriteColor.a += fadeSpeed * Time.deltaTime;

            // Đảm bảo rằng alpha không vượt quá giá trị đã chuyển đổi
            spriteColor.a = Mathf.Clamp(spriteColor.a, 0, targetAlphaNormalized);

            // Cập nhật màu mới cho SpriteRenderer
            spriteRenderer.color = spriteColor;
        }
        
    }
}
