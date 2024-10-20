using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BossAn_Skill: MonoBehaviour
{
    public Image ManaBar_Enemy;
    public Image HealthBar_Enemy;
    public Text CurrentHealth_Enemy;
    public Text CurrentMana_Enemy;
    private GameStatsManager objectValue;
    // Start is called before the first frame update
    void Start()
    {
        ManaBar_Enemy.fillAmount = objectValue.GetBossMana() / 10;
        HealthBar_Enemy.fillAmount = objectValue.GetBossHealth() / 100;
    }

    // Update is called once per frame
    void Update()
    {
        int displayMana = Mathf.RoundToInt(ManaBar_Enemy.fillAmount * 10);
        CurrentMana_Enemy.text = displayMana.ToString();
        
        if (ManaBar_Enemy.fillAmount < 0.09999997 && ManaBar_Enemy.fillAmount != 0)
        {
            ManaBar_Enemy.fillAmount += 0.00000004f;
        }
        if (ManaBar_Enemy.fillAmount < 0.1 && ManaBar_Enemy.fillAmount > 0.09999998 && ManaBar_Enemy.fillAmount != 0)
        {
            ManaBar_Enemy.fillAmount += 0.00000001f;
        }
        int displayHealth = Mathf.RoundToInt(HealthBar_Enemy.fillAmount * 100);
        CurrentHealth_Enemy.text = displayHealth.ToString();
    }
}
