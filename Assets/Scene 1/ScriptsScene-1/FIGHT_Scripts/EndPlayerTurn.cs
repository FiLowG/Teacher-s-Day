using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EndPlayerTurn : MonoBehaviour
{
    public Image HealBar_Player;
    public Image HealBar_Enemy;
    public Image ManaBar_Player;
    public Image ManaBar_Enemy;
    public GameObject EndTurnButton;
    public GameObject PanelBack;
    public GameObject BossCanFight;
    private Color NotTurn = new Color(107f / 255f, 94f / 255f, 94f / 255f); // 6B5E5E
    private Color YourTurn = Color.white;
    public GameObject Shield_Player;
    public GameObject Shield_Enemy;
    public GameObject Panel_Win;
    public GameObject Panel_Loss;
    public GameObject Breath;
   
    // Start is called before the first frame update
    void Start()
    {
        Breath.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (HealBar_Enemy.fillAmount == 0)
        {
            Breath.SetActive(true);
            Panel_Win.SetActive(true);
        }
        if (HealBar_Player.fillAmount == 0)
        {

            Panel_Loss.SetActive(true);
        }
        if (EndTurnButton.GetComponent<SpriteRenderer>().color == YourTurn)
        {
            BossCanFight.SetActive(false);
            PanelBack.SetActive(false);
        }
    }
  
    public void OnEndPlayerTurn()
    {
        if (EndTurnButton.GetComponent<SpriteRenderer>().color == YourTurn)
        {
            BossCanFight.SetActive(true);
            PanelBack.SetActive(true);
            EndTurnButton.GetComponent<SpriteRenderer>().color = NotTurn;  
            ManaBar_Enemy.fillAmount = 1;
            if (Shield_Enemy.activeSelf)
            {
                Shield_Enemy.SetActive(false);
            }

        }
    }

 }
