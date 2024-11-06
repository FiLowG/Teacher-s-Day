using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sticky_Pass : MonoBehaviour
{
    public GameObject Player_Item;
    public string ItemNameToUnlock;
    public Image EmptyToAssign;
    public Image EmptyToAssign2;
    public GameObject notice;
    private Pick_Item NoneSlot;
    public GameObject Passed;
    public GameObject On_Boss;
    void Start()
    {
        NoneSlot = FindObjectOfType<Pick_Item>();
    }

    void Update()
    {
        if (EmptyToAssign.sprite != null && EmptyToAssign2.sprite != null)
        {
            Passed.SetActive(true);
            On_Boss.SetActive(true);
        }
    }

    public void OnUnlock()
    {
        // Kiểm tra nếu ItemNameToUnlock khớp với tag của Player_Item
        if (Player_Item.tag == ItemNameToUnlock)
        {
            // Gán sprite của currentSelectedSlot vào EmptyToAssign
            if (NoneSlot != null && NoneSlot.currentSelectedSlot != null)
            {
                EmptyToAssign.sprite = NoneSlot.currentSelectedSlot.sprite;

                // Đặt alpha của EmptyToAssign về 1 (255)
                Color color = EmptyToAssign.color;
                color.a = 1; // 1 tương đương với alpha 255
                EmptyToAssign.color = color;

                // Xóa sprite trong slot hiện tại
                NoneSlot.currentSelectedSlot.sprite = null;

                // Tắt currentActiveFrame nếu có
                if (NoneSlot.currentActiveFrame != null)
                {
                    NoneSlot.currentActiveFrame.SetActive(false);
                    NoneSlot.currentActiveFrame = null;
                }

                NoneSlot.currentSelectedSlot = null;
            }
        }
        else
        {
            // Hiển thị thông báo nếu ItemNameToUnlock không khớp
            if (notice != null)
            {
                notice.SetActive(true);
            
                StartCoroutine(OffNotice());
            }
        }
    }

    IEnumerator OffNotice()
    {
        yield return new WaitForSeconds(2);
        notice.SetActive(false);
    }
}
