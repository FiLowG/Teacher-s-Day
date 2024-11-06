using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetDame : MonoBehaviour
{
    public Image BossHeal;
    public Image PlayerHeal;
    private GameStatsManager objectValue;
    private float damageAmount_Player;
    private float damageAmount_Enemy;
    public float Damage_Option_Enemy = 0;
    public float Damage_Option_Player = 0;
    public GameObject DameEffects;

    void Start()
    {
        objectValue = FindObjectOfType<GameStatsManager>();

        if (objectValue != null && Damage_Option_Enemy == 0)
        {
           
            damageAmount_Enemy = objectValue.GetBossAttack();
        }
        else
        {
            damageAmount_Enemy = Damage_Option_Enemy;
        }
        if ((objectValue != null && Damage_Option_Player == 0))
        {
            damageAmount_Player = objectValue.GetPlayerAttack();
        }
        else
        {
            damageAmount_Player = Damage_Option_Player;
        }
    }

    void Update()
    {
      
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Contains("Attack"))
        {
            if (this.gameObject.CompareTag("Player"))
            {
                PlayerHeal.fillAmount -= damageAmount_Enemy;
            }
            else if (this.gameObject.tag.Contains("Boss") && !collision.gameObject.tag.Contains("Boss_Attack"))
            {
                BossHeal.fillAmount -= damageAmount_Player;
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
