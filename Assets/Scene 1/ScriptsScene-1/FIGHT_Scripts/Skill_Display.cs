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
    // Màu khi không đủ mana
    private Color insufficientManaColor = new Color(107f / 255f, 94f / 255f, 94f / 255f); // 6B5E5E

    // Màu bình thường của kỹ năng
    private Color normalColor = Color.white; // Màu mặc định hoặc bạn có thể đặt lại

    void Start()
    {
        ManaBar_Player.fillAmount = objectValue.GetPlayerMana() /10;
        HealthBar_Player.fillAmount = objectValue.GetPlayerHealth() / 100;
        // Đặt màu ban đầu cho tất cả các kỹ năng là màu bình thường
        SetSkillColor(HealSkill, normalColor);
        SetSkillColor(ShieldSkill, normalColor);
        SetSkillColor(AttackSkill, normalColor);
        SetSkillColor(UltimateSkill, normalColor);
    }

    void Update()
    {

        int displayMana = Mathf.RoundToInt(ManaBar_Player.fillAmount * 10); // Làm tròn chính xác

        CurrentMana_Player.text = displayMana.ToString();
        if (ManaBar_Player.fillAmount < 0.09999997 && ManaBar_Player.fillAmount != 0)
        {
            ManaBar_Player.fillAmount += 0.00000004f;
        }
        if (ManaBar_Player.fillAmount < 0.1 && ManaBar_Player.fillAmount > 0.09999998 && ManaBar_Player.fillAmount != 0)
        {
            ManaBar_Player.fillAmount += 0.00000001f;
        }
        int displayHealth = Mathf.RoundToInt(HealthBar_Player.fillAmount * 100);
        CurrentHealth_Player.text = displayHealth.ToString();

        // HealSkill cần 0.6 mana
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

        // AttackSkill cần 0.4 mana
        if (ManaBar_Player.fillAmount >= 0.4)
        {
            SetSkillColor(AttackSkill, normalColor);
            AttackSkill_Button.SetActive(true);
        }
        else
        {
            SetSkillColor(AttackSkill, insufficientManaColor);
            AttackSkill_Button.SetActive(false);
        }

        // ShieldSkill cần 0.3 mana
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

        // UltimateSkill cần 0.5 mana
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

    // Hàm đổi màu SpriteRenderer của kỹ năng
    void SetSkillColor(GameObject skill, Color color)
    {
        SpriteRenderer spriteRenderer = skill.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            spriteRenderer.color = color;
        }
    }
}
