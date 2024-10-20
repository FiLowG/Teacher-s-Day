using System.Collections;
using UnityEngine;

public class SecurityGuard : MonoBehaviour
{
    public float fadeSpeed = 1;
    private SpriteRenderer spriteRenderer;
    private Color spriteColor;
    private bool Mclear = false;
    private bool MBlur = false;
    public GameObject NoBreath;
    public GameObject SeePlayerYet;
    public GameObject SeePlayer;
    public GameObject SawPlayer;
    public GameObject Lose_Scene;
    private bool OnSee = false;
    void Start()
    {
        OnSee = false;
        if (this.gameObject == SeePlayerYet)
        {
        spriteRenderer = SeePlayerYet.GetComponent<SpriteRenderer>();
        spriteColor = spriteRenderer.color;
        spriteColor.a = 0;  // Bắt đầu với alpha là 0 (trong suốt)
        spriteRenderer.color = spriteColor;
        StartCoroutine(OnSeeTrue());
        StartCoroutine(WaitAndMakeClear());
        StartCoroutine(MakeGone());
        }
    }

    void Update()
    {
        if (this.gameObject == SeePlayerYet && OnSee && NoBreath.activeSelf)
        {
           
                SeePlayer.SetActive(true);
                SeePlayerYet.SetActive(false);
        }
        if (this.gameObject == SeePlayer)
        {
            StartCoroutine(SawPlayerImage());
        }
        if (this.gameObject == SawPlayer)
        {
            SeePlayerYet.SetActive(false);
            SeePlayer.SetActive(false);
        }

        if (this.gameObject.name != "SecurityGuard-SeePlayer" && this.gameObject.name != "SawPlayer")
        {
            if (spriteColor.a < 1 && Mclear)  // Alpha trong phạm vi 0 - 1
            {
                spriteColor.a += fadeSpeed * Time.deltaTime;
                spriteRenderer.color = spriteColor;
               
            }

            if (spriteColor.a > 0 && MBlur)
            {
                spriteColor.a -= fadeSpeed * Time.deltaTime;
                spriteRenderer.color = spriteColor;
                if (spriteColor.a <= 0)
                {
                    this.gameObject.SetActive(false);  // Tắt GameObject khi alpha về 0
                }
            }
        }
       
       
            
    }
    IEnumerator OnSeeTrue()
    {
        yield return new WaitForSeconds(5);
        OnSee = true;
    }

    IEnumerator OnLight()
    {
        SawPlayer.GetComponent<Animator>().enabled = false;
        yield return new WaitForSeconds(1);
        Lose_Scene.SetActive(true);
    }
    IEnumerator SawPlayerImage()
    {
        yield return new WaitForSeconds(1.5f);
        SawPlayer.SetActive(true);
        SeePlayer.SetActive(false);
       
       
        
    }
    IEnumerator WaitAndMakeClear()
    {
        yield return new WaitForSeconds(4);  // Đợi 4 giây trước khi tăng alpha
        MakeClear();
    }

    public void MakeClear()
    {
        Mclear = true;
        MBlur = false;  // Đảm bảo chỉ có một trạng thái hoạt động
    }

    IEnumerator MakeGone()
    {
        yield return new WaitForSeconds(8);  // Đợi 5 giây trước khi bắt đầu làm mờ
        Mclear = false;  // Ngừng tăng alpha
        MBlur = true;    // Bắt đầu giảm alpha
    }
}
