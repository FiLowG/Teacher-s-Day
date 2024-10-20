using UnityEngine;

public class BlurToClear : MonoBehaviour
{
    public float fadeSpeed = 1;
    public int targetAlpha = 50;
    private SpriteRenderer spriteRenderer;
    private Color spriteColor;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteColor = spriteRenderer.color;
        spriteColor.a = 0;
    }

    void Update()
    {
        float targetAlphaNormalized = targetAlpha / 255f;

        if (spriteColor.a < targetAlphaNormalized)
        {
            spriteColor.a += fadeSpeed * Time.deltaTime;
            spriteColor.a = Mathf.Clamp(spriteColor.a, 0, targetAlphaNormalized);
            spriteRenderer.color = spriteColor;
        }
    }
}
