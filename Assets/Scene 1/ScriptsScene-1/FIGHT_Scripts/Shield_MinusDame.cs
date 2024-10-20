using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shield_MinusDame : MonoBehaviour
{
    public Image HealBar;

    private float previousHealth;
    private float currentHealth;
    private GameStatsManager objectValue;

    void Start()
    {
        objectValue = FindObjectOfType<GameStatsManager>();

        if (objectValue == null) return;

        currentHealth = HealBar.fillAmount * 100f;
        previousHealth = currentHealth;
    }

    void Update()
    {
        if (objectValue == null) return;

        currentHealth = HealBar.fillAmount * 100f;
        float healthDifference = previousHealth - currentHealth;

        if (healthDifference > 0)
        {
            float healingPercentage = objectValue.GetPlayerShield();
            float healAmount = healthDifference * (healingPercentage / 100f);
            healAmount = Mathf.Floor(healAmount);

            currentHealth += healAmount;

            if (currentHealth > 100f)
            {
                currentHealth = 100f;
            }

            HealBar.fillAmount = currentHealth / 100f;
        }

        previousHealth = currentHealth;
    }
}
