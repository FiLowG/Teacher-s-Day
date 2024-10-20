using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_Fight1 : MonoBehaviour
{
    public Image ManaBar;
    public Image HealBar; // Khai báo Image cho Heal
    public GameObject UltimateEffects;
    public GameObject AttackEffects;
    public GameObject HealEffects;
    public GameObject ShieldEffects;
    public GameObject BossCanFight;
    public GameObject BossCanUltimate;
    public GameObject BossCanAttack;
    public GameObject BossCanHeal;
    public GameObject BossCanShield;
    private float lastSkillTime = 0f;

    private float currentMana;

    void Update()
    {
        
        if (Time.time - lastSkillTime >= 5f) // Đảm bảo 5 giây giữa mỗi kỹ năng
        {
            if (BossCanFight.activeSelf && ManaBar.fillAmount >= 0.3 && HealBar.fillAmount <= 0.6 && !ShieldEffects.activeSelf && BossCanShield.activeSelf)
            {
                UseShield();
                lastSkillTime = Time.time;
                Debug.Log("shield");
                BossCanShield.SetActive(false);
                StartCoroutine(WaitSkill(5, BossCanShield));
            }
            if (BossCanFight.activeSelf && ManaBar.fillAmount >= 0.6 && HealBar.fillAmount != 1 && BossCanHeal.activeSelf && !HealEffects.activeSelf)
            {
                UseHeal();
                lastSkillTime = Time.time; // Cập nhật thời gian
                Debug.Log("Heal");
                BossCanHeal.SetActive(false);
                StartCoroutine(WaitSkill(5, BossCanHeal));

            }
            if (BossCanFight.activeSelf && ManaBar.fillAmount >= 0.4 && BossCanAttack.activeSelf && !AttackEffects.activeSelf)
            {
                UseAttack();
                lastSkillTime = Time.time;
                Debug.Log("Attack");
                BossCanAttack.SetActive(false);
                StartCoroutine(WaitSkill(5, BossCanAttack));
            }
            if (BossCanFight.activeSelf && ManaBar.fillAmount >= 0.5 && BossCanUltimate.activeSelf)
            {
                UseUltimate();
                lastSkillTime = Time.time;
                Debug.Log("Ultimate");
                BossCanUltimate.SetActive(false);
                StartCoroutine(WaitSkill(30, BossCanUltimate));
            }

        }
    }



    public void UseUltimate()
    {
        ManaBar.fillAmount -= 0.5f;
        UltimateEffects.SetActive(true);
    }
    public void UseAttack()
    {
        ManaBar.fillAmount -= 0.4f;
        AttackEffects.SetActive(true);
    }
    public void UseHeal()
    {
        ManaBar.fillAmount -= 0.6f;
        HealEffects.SetActive(true);
    }
    public void UseShield()
    {
        ManaBar.fillAmount -= 0.3f;
        ShieldEffects.SetActive(true);
    }

    IEnumerator WaitSkill(int s, GameObject SkillUsed)
    {
        yield return new WaitForSeconds(s);
        SkillUsed.SetActive(true);
        if (ManaBar.fillAmount != 1)
        {
            currentMana = ManaBar.fillAmount;
            ManaBar.fillAmount = currentMana;
        }
    }
}
