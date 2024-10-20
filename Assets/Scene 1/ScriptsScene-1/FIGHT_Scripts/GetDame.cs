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

    public GameObject DameEffects;

    void Start()
    {
        objectValue = FindObjectOfType<GameStatsManager>();

        if (objectValue != null)
        {
            damageAmount_Player = objectValue.GetPlayerAttack();
            damageAmount_Enemy = objectValue.GetBossAttack();
        }
        else
        {
            Debug.LogError("Không tìm thấy GameStatsManager trong scene!");
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
            else if (this.gameObject.tag.Contains("Boss"))
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
