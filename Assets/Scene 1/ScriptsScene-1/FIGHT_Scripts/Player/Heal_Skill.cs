using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heal_Skill : MonoBehaviour
{
    public Image HealBar;
    private GameStatsManager objectValue;
    private float healAmount;
    public GameObject WhoUse;

    void Start()
    {
       
        objectValue = FindObjectOfType<GameStatsManager>();
        if (WhoUse.tag.Contains("Player"))
        {
           
            healAmount = 0.05f;
           
        }
        if (WhoUse.tag.Contains("Boss") && !WhoUse.name.Contains("DucThang") && !WhoUse.tag.Contains("BossAn"))
        {
            healAmount = 0.03f;
        }
        if (WhoUse.tag.Contains("Boss") && WhoUse.name.Contains("DucThang"))
        {
            healAmount = 0.01f;
        }
        if (WhoUse.tag.Contains("BossAn"))
        {
            healAmount = 0.07f;
        }





    }

    void Update()
    {
       
    }
    public void CallCoroutine()
    {
        StartCoroutine(Healing());
      
    }

    IEnumerator Healing()
    {
        Debug.Log(this.gameObject.name + " 0 " + healAmount);

        HealBar.fillAmount += healAmount;
        yield return new WaitForSeconds(0.7f);
        HealBar.fillAmount += healAmount;
        yield return new WaitForSeconds(0.7f);
        HealBar.fillAmount += healAmount;
        
        yield return new WaitForSeconds(0.7f);
        HealBar.fillAmount += healAmount;
        Debug.Log(this.gameObject.name + " 1 " + healAmount);



    }
}
