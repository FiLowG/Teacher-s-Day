using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetDame : MonoBehaviour
{
    public Image BossHeal;
    public Image PlayerHeal;
    private GameStatsManager objectValue;
    public float damageAmount_Player; // Sát thương tính theo phần trăm máu
    public float damageAmount_Enemy; // Sát thương tính theo phần trăm máu

    public GameObject DameEffects;
  
    void Start()
    {
        damageAmount_Player = objectValue.GetPlayerAttack();
        damageAmount_Enemy = objectValue.GetBossAttack();
    }

    void Update()
    {

    }

    // Xử lý va chạm vật lý 2D
    public void OnTriggerEnter2D(Collider2D collision)
    {
        // Kiểm tra xem đối tượng va chạm có tag "Attack" hay không
        if (collision.gameObject.tag.Contains("Attack"))
        {
            if (this.gameObject.CompareTag("Player"))
            {
                PlayerHeal.fillAmount -= damageAmount_Enemy; // Trừ máu của Player
            }
            else if (this.gameObject.tag.Contains("Boss"))
            {
                BossHeal.fillAmount -= damageAmount_Player; // Trừ máu của BOSS
            }
        }
        if (collision.gameObject.CompareTag("Ultimate"))
        {
           if (this.gameObject.tag.Contains("Boss"))
            {
                DameEffects.SetActive(true);
                
            }
        }
        if (collision.gameObject.CompareTag("Ultimate Dame"))
        {
            if (this.gameObject.tag.Contains("Boss"))
            {
                BossHeal.fillAmount -= objectValue.GetPlayerUltimate();

            }
        }

    }
}
