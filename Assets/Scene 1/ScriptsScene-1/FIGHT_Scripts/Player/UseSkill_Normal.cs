using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UseSkill_Normal : MonoBehaviour
{
    public Image ManaBar;

    public GameObject UltimateEffects;
    public GameObject AttackEffects;
    public GameObject HealEffects;
    public GameObject ShieldEffects;
    public GameObject OldHand;
    // Start is called before the first frame update
    public Text CD_Display;
    public GameObject CD_Display_Object;
    public GameObject GetActive;
    public GameObject SetColorSkill;
    public float CD_time = 25;
    private float current_CD = 0;
    private Color Used_Skill = new Color(107f / 255f, 94f / 255f, 94f / 255f); 


    void Start()
    {
        CD_Display_Object.SetActive(true);
        CD_Display.text = current_CD.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (CD_Display.text == "0" && CD_Display_Object.activeSelf)
        {
            CD_Display_Object.SetActive(false);
            SetColorSkill.GetComponent<SpriteRenderer>().color = Color.white;
        }
        if (CD_Display.text != "0" && !CD_Display_Object.activeSelf)
        {
            CD_Display_Object.SetActive(true);
        }
        if (current_CD > 0.1)
        {
            GetActive.SetActive(false);
            current_CD -= Time.deltaTime;
            CD_Display.text = Mathf.Floor(current_CD).ToString();

        }
        if (current_CD < 0.1)
        {
            GetActive.SetActive(true);
            
        }
    }

    public void UseSkill()
    {
        if (this.gameObject.CompareTag("Ultimate"))
        {
            ManaBar.fillAmount -= 0.5f;
        }
        else if (this.gameObject.CompareTag("Attack"))
        {
            ManaBar.fillAmount -= 0.4f;
        }
        else if (this.gameObject.CompareTag("Heal"))
        {
            ManaBar.fillAmount -= 0.6f;
        }
        else if (this.gameObject.CompareTag("Shield"))
        {
            ManaBar.fillAmount -= 0.4f;
        }
    }

    public void UseUltimate()
    {
        UltimateEffects.SetActive(true);
        current_CD = CD_time;
        SetColorSkill.GetComponent<SpriteRenderer>().color = Used_Skill;
    }
    public void UseAttack()
    {
        AttackEffects.SetActive(true);
        if (OldHand != null)
        {
            OldHand.SetActive(false);
        }
    }
    public void UseHeal()
    {
        HealEffects.SetActive(true);
    }
    public void UseShield()
    {
        ShieldEffects.SetActive(true);
    }

}

