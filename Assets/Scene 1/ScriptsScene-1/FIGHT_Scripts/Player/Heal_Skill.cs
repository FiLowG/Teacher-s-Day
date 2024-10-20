using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Heal_Skill : MonoBehaviour
{
    public Image HealBar;
    private GameStatsManager objectValue;

    void Start()
    {
        objectValue = FindObjectOfType<GameStatsManager>();

        if (objectValue == null)
        {
            return;
        }

        StartCoroutine(Healing());
    }

    void Update()
    {
    }

    IEnumerator Healing()
    {
        for (int i = 0; i < 4; i++)
        {
            float healAmount = objectValue.GetPlayerHeal();

            HealBar.fillAmount += healAmount;

            if (HealBar.fillAmount > 1f)
            {
                HealBar.fillAmount = 1f;
            }

            yield return new WaitForSeconds(0.7f);
        }
    }
}
