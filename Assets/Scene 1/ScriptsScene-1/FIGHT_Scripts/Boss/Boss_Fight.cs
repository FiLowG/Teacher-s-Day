using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss_Fight : MonoBehaviour
{
    public Image ManaBar;
    public Image HealBar;
    public Image HealBar_Player;
    public Image ManaBar_Player;
    public GameObject UltimateEffects;
    public GameObject AttackEffects;
    public GameObject HealEffects;
    public GameObject ShieldEffects;
    public GameObject BossCanFight;
    public GameObject BossCanUltimate;
    public GameObject EndTurnButton;
    private bool isUsingSkill = false; // Kiểm tra trạng thái sử dụng skill
    private bool ultimateCooldown = false; // Kiểm tra hồi chiêu của Ultimate
    private SpriteRenderer endTurnButtonRenderer; // Thêm SpriteRenderer cho nút

    public GameObject Shield_Player;
    void Start()
    {
        // Lấy component SpriteRenderer của nút End Turn
        endTurnButtonRenderer = EndTurnButton.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (!isUsingSkill) // Kiểm tra nếu không có skill nào đang được sử dụng
        {
            // Ưu tiên Heal nếu Mana và máu đủ điều kiện
            if (BossCanFight.activeSelf && ManaBar.fillAmount >= 0.5 && BossCanUltimate.activeSelf && !ultimateCooldown)
            {
                StartCoroutine(UseSkill(2, UseUltimate, "Ultimate"));
                StartCoroutine(StartUltimateCooldown(40)); // Hồi chiêu Ultimate 30s
            }
            else if (BossCanFight.activeSelf && ManaBar.fillAmount >= 0.6 && HealBar.fillAmount <= 0.8)
            {
                StartCoroutine(UseSkill(1, UseHeal, "Heal"));
            }
           
           
            // Kiểm tra điều kiện cho Shield
            else if (BossCanFight.activeSelf && ManaBar.fillAmount >= 0.3 && HealBar.fillAmount <= 0.5 && !ShieldEffects.activeSelf)
            {
                StartCoroutine(UseSkill(1, UseShield, "Shield"));
            }
            // Kiểm tra điều kiện cho Attack
            else if (BossCanFight.activeSelf && ManaBar.fillAmount >= 0.4)
            {
                StartCoroutine(UseSkill(1, UseAttack, "Attack"));
            }
            else
            {
                // Không còn điều kiện để sử dụng chiêu nào, đổi màu nút EndTurn thành trắng
                endTurnButtonRenderer.color = Color.white;
               
            }
        }
    }

    // Coroutine cho việc sử dụng kỹ năng với thời gian chờ trước và sau khi thực thi
    IEnumerator UseSkill(int waitTimeBefore, System.Action skillAction, string skillName)
    {
        isUsingSkill = true; // Đánh dấu là đang sử dụng skill

        yield return new WaitForSeconds(waitTimeBefore); // Chờ trước khi sử dụng skill
        skillAction.Invoke(); // Thực hiện skill
        Debug.Log(skillName); // Ghi log tên skill

        yield return new WaitForSeconds(5); // Chờ 5 giây sau khi sử dụng skill
        isUsingSkill = false; // Đánh dấu là không còn sử dụng skill

        // Khi vừa sử dụng skill xong, kiểm tra lại điều kiện để đổi màu nút EndTurn nếu không còn chiêu nào có thể sử dụng
        CheckEndTurnButtonColor();
    }

    // Coroutine cho việc hồi chiêu Ultimate với thời gian 30s
    IEnumerator StartUltimateCooldown(float cooldownTime)
    {
        ultimateCooldown = true; // Ultimate đang trong hồi chiêu
        BossCanUltimate.SetActive(false); // Vô hiệu hóa Ultimate trong khi chờ hồi chiêu
        yield return new WaitForSeconds(cooldownTime); // Đợi hết thời gian hồi chiêu
        BossCanUltimate.SetActive(true); // Kích hoạt lại Ultimate
        ultimateCooldown = false; // Đặt lại trạng thái hồi chiêu
        Debug.Log("Ultimate is ready again!");
    }

    // Các hàm thực thi kỹ năng
    public void UseUltimate()
    {
        ManaBar.fillAmount -= 0.5f;
        UltimateEffects.SetActive(true);
    }
    public void UseAttack()
    {
        ManaBar.fillAmount -= 0.4f;
        AttackEffects.SetActive(true);
    }
    public void UseHeal()
    {
        ManaBar.fillAmount -= 0.6f;
        HealEffects.SetActive(true);
        if (ManaBar.fillAmount <= 0.4 && ManaBar.fillAmount >= 0.35)
        {
            ManaBar.fillAmount = 0.41f;
        }
    }
    public void UseShield()
    {
        ManaBar.fillAmount -= 0.3f;
        ShieldEffects.SetActive(true);
    }

    // Kiểm tra điều kiện để đổi màu EndTurnButton
    private void CheckEndTurnButtonColor()
    {
        if (!(ManaBar.fillAmount >= 0.6 && HealBar.fillAmount <= 0.8) &&
            !(ManaBar.fillAmount >= 0.5 && BossCanUltimate.activeSelf && !ultimateCooldown) &&
            !(ManaBar.fillAmount >= 0.3 && HealBar.fillAmount <= 0.5 && !ShieldEffects.activeSelf) &&
            !(ManaBar.fillAmount >= 0.4))
        {
            // Nếu không còn chiêu nào sử dụng được, đổi màu nút EndTurn thành trắng
            endTurnButtonRenderer.color = Color.white;

            ManaBar_Player.fillAmount = 1;
            if (Shield_Player.activeSelf)
            {

                Shield_Player.SetActive(false);

            }
        }
    }
}
