using UnityEngine;

public class OpenBlack : MonoBehaviour
{
    public float fadeSpeed = 1;  
    private SpriteRenderer spriteRenderer;
    private Color spriteColor;
    public GameObject blackBKG;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

      
        spriteColor = spriteRenderer.color;
        
  }

    void Update()
    {
        
        if (spriteColor.a > 0)
        {
            
            spriteColor.a -= fadeSpeed * Time.deltaTime;

        
            spriteRenderer.color = spriteColor;
        }
        if (spriteColor.a < 0.1)
        {
            blackBKG.SetActive(false);
        }
    }
}
