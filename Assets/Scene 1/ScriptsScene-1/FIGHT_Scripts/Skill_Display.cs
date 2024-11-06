using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SKILL_Display : MonoBehaviour
{
    public Image ManaBar_Player;
    public GameObject UltimateSkill;
    public GameObject HealSkill;
    public GameObject ShieldSkill;
    public GameObject AttackSkill;
    public GameObject UltimateSkill_Button;
    public GameObject HealSkill_Button;
    public GameObject ShieldSkill_Button;
    public GameObject AttackSkill_Button;
    public Text CurrentMana_Player;
    public Image HealthBar_Player;
    public Text CurrentHealth_Player;
    public GameObject GetActive;

    private GameStatsManager objectValue;
    private Color insufficientManaColor = new Color(107f / 255f, 94f / 255f, 94f / 255f);
    private Color normalColor = Color.white;

    void Start()
    {
        objectValue = FindObjectOfType<GameStatsManager>();

        if (objectValue == null) return;

        ManaBar_Player.fillAmount = objectValue.GetPlayerMana();
        HealthBar_Player.fillAmount = objectValue.GetPlayerHealth();

        SetSkillColor(HealSkill, normalColor);
        SetSkillColor(ShieldSkill, normalColor);
        SetSkillColor(AttackSkill, normalColor);
        SetSkillColor(UltimateSkill, normalColor);
    }

    void Update()
    {
        if (objectValue == null) return;

        int displayMana = Mathf.FloorToInt(ManaBar_Player.fillAmount * 10);
        CurrentMana_Player.text = displayMana.ToString();

        if (ManaBar_Player.fillAmount < 0.09999997 && ManaBar_Player.fillAmount != 0)
        {
            ManaBar_Player.fillAmount += 0.00000004f;
        }
        if (ManaBar_Player.fillAmount < 0.1 && ManaBar_Player.fillAmount > 0.09999998 && ManaBar_Player.fillAmount != 0)
        {
            ManaBar_Player.fillAmount += 0.00000001f;
        }

        int displayHealth = Mathf.FloorToInt(HealthBar_Player.fillAmount * 100);
        CurrentHealth_Player.text = displayHealth.ToString();

        if (ManaBar_Player.fillAmount >= 0.6)
        {
            SetSkillColor(HealSkill, normalColor);
            HealSkill_Button.SetActive(true);
        }
        else
        {
            SetSkillColor(HealSkill, insufficientManaColor);
            HealSkill_Button.SetActive(false);
        }

        if (ManaBar_Player.fillAmount >= 0.39f)
        {
            SetSkillColor(AttackSkill, normalColor);
            AttackSkill_Button.SetActive(true);
        }
        else
        {
            SetSkillColor(AttackSkill, insufficientManaColor);
            AttackSkill_Button.SetActive(false);
        }

        if (ManaBar_Player.fillAmount >= 0.3)
        {
            SetSkillColor(ShieldSkill, normalColor);
            ShieldSkill_Button.SetActive(true);
        }
        else
        {
            SetSkillColor(ShieldSkill, insufficientManaColor);
            ShieldSkill_Button.SetActive(false);
        }

        if (ManaBar_Player.fillAmount >= 0.5 && GetActive.activeSelf)
        {
            SetSkillColor(UltimateSkill, normalColor);
            UltimateSkill_Button.SetActive(true);
        }
        else
        {
            SetSkillColor(UltimateSkill, insufficientManaColor);
            UltimateSkill_Button.SetActive(false);
        }
    }

    void SetSkillColor(GameObject skill, Color color)
    {
        SpriteRenderer spriteRenderer = skill.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.color = color;
        }
    }
}
