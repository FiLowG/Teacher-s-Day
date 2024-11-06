using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightBoss_Again : MonoBehaviour
{
    // GameObjects cho 4 chiêu thức của Player
    public GameObject playerSkill1;
    public GameObject playerSkill2;
    public GameObject playerSkill3;
    public GameObject playerSkill4;

    // GameObjects cho 4 chiêu thức của Boss
    public GameObject bossSkill1;
    public GameObject bossSkill2;
    public GameObject bossSkill3;
    public GameObject bossSkill4;

    // Biến Image cho Heal và Mana của Player
    public Image healPlayer;
    public Image manaPlayer;
    public GameObject SawPlayer;
    // Biến Image cho Heal và Mana của Enemy
    public Image healEnemy;
    public Image manaEnemy;
    private Ultimate_HieuTruong CD_Time;
    // Hàm reset trạng thái trận đấu

     void Start()
    {
        CD_Time = FindObjectOfType<Ultimate_HieuTruong>();
    }
    public void ResetBattleState()
    {
        if (CD_Time != null) { CD_Time.countdownTime = 90; }
       

        // Đưa fillAmount của các Image về 1
        healPlayer.fillAmount = 1;
        manaPlayer.fillAmount = 1;
        healEnemy.fillAmount = 1;
        manaEnemy.fillAmount = 1;

        // False active tất cả các GameObject hiệu ứng chiêu thức của Player
        playerSkill1.SetActive(false);
        playerSkill2.SetActive(false);
        playerSkill3.SetActive(false);
        playerSkill4.SetActive(false);

        // False active tất cả các GameObject hiệu ứng chiêu thức của Boss
        bossSkill1.SetActive(false);
        bossSkill2.SetActive(false);
        bossSkill3.SetActive(false);
        bossSkill4.SetActive(false);
        if (SawPlayer != null)
        {
            SawPlayer.SetActive(false);
        }

        if (bossSkill1.tag.Contains("DucThang") || bossSkill1.tag.Contains("HieuTruong"))
        {
            bossSkill1.SetActive(true);
        }
    }
}
