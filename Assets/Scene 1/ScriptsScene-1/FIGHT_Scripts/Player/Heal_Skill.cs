using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heal_Skill : MonoBehaviour
{
    public Image HealBar;
    private GameStatsManager objectValue;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Healing());
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    IEnumerator Healing()
    {
        HealBar.fillAmount += objectValue.GetPlayerHeal();
        yield return new WaitForSeconds(0.7f);
        HealBar.fillAmount += objectValue.GetPlayerHeal();
        yield return new WaitForSeconds(0.7f);
        HealBar.fillAmount += objectValue.GetPlayerHeal();
        yield return new WaitForSeconds(0.7f);
        HealBar.fillAmount += objectValue.GetPlayerHeal();
    }
}
