using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_Fight : MonoBehaviour
{
    public Image ManaBar;
    public Image HealBar;
    public Image HealBar_Player;
    public Image ManaBar_Player;
    public GameObject UltimateEffects;
    public GameObject AttackEffects;
    public GameObject HealEffects;
    public GameObject ShieldEffects;
    public GameObject BossCanFight;
    public GameObject BossCanUltimate;
    public GameObject EndTurnButton;
    private bool isUsingSkill = false;
    private bool ultimateCooldown = false;
    private SpriteRenderer endTurnButtonRenderer;
    public GameObject Shield_Player;

    void Start()
    {
        ManaBar.fillAmount = 1;
        endTurnButtonRenderer = EndTurnButton.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!isUsingSkill)
        {
            if (BossCanFight.activeSelf && ManaBar.fillAmount >= 0.5 && BossCanUltimate.activeSelf && !ultimateCooldown)
            {
                StartCoroutine(UseSkill(2, UseUltimate, "Ultimate"));
                StartCoroutine(StartUltimateCooldown(40));
            }
            else if (BossCanFight.activeSelf && ManaBar.fillAmount >= 0.6 && HealBar.fillAmount <= 0.8)
            {
                StartCoroutine(UseSkill(1, UseHeal, "Heal"));
            }
            else if (BossCanFight.activeSelf && ManaBar.fillAmount >= 0.3 && HealBar.fillAmount <= 0.5 && !ShieldEffects.activeSelf)
            {
                StartCoroutine(UseSkill(1, UseShield, "Shield"));
            }
            else if (BossCanFight.activeSelf && ManaBar.fillAmount >= 0.4)
            {
                StartCoroutine(UseSkill(1, UseAttack, "Attack"));
            }
            else
            {
                endTurnButtonRenderer.color = Color.white;
            }
        }
    }

    IEnumerator UseSkill(int waitTimeBefore, System.Action skillAction, string skillName)
    {
        isUsingSkill = true;
        yield return new WaitForSeconds(waitTimeBefore);
        skillAction.Invoke();
        yield return new WaitForSeconds(5);
        isUsingSkill = false;
        CheckEndTurnButtonColor();
    }

    IEnumerator StartUltimateCooldown(float cooldownTime)
    {
        ultimateCooldown = true;
        BossCanUltimate.SetActive(false);
        yield return new WaitForSeconds(cooldownTime);
        BossCanUltimate.SetActive(true);
        ultimateCooldown = false;
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
        if (ManaBar.fillAmount <= 0.4 && ManaBar.fillAmount >= 0.35)
        {
            ManaBar.fillAmount = 0.41f;
        }
    }

    public void UseShield()
    {
        ManaBar.fillAmount -= 0.3f;
        ShieldEffects.SetActive(true);
    }

    private void CheckEndTurnButtonColor()
    {
        if (!(ManaBar.fillAmount >= 0.6 && HealBar.fillAmount <= 0.8) &&
            !(ManaBar.fillAmount >= 0.5 && BossCanUltimate.activeSelf && !ultimateCooldown) &&
            !(ManaBar.fillAmount >= 0.3 && HealBar.fillAmount <= 0.5 && !ShieldEffects.activeSelf) &&
            !(ManaBar.fillAmount >= 0.4))
        {
            endTurnButtonRenderer.color = Color.white;
            ManaBar_Player.fillAmount = 1;
            if (Shield_Player.activeSelf)
            {
                Shield_Player.SetActive(false);
            }
        }
    }
}
