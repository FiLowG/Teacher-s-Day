using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stick_HuyHieu : MonoBehaviour
{
    public GameObject Player_Item;
    private Pick_Item PickItem;
    public List<Image> SlotRemotes;
    public GameObject ButtonPut;
    public GameObject ButtonTake;
    public GameObject BossLast; // GameObject BossLast
    public GameObject Timing; // GameObject Timing
    public GameObject RemoteBomb; // GameObject RemoteBomb
    public Image RemoteSlot0;
    public Image RemoteSlot1;
    public Image RemoteSlot3;
    public Image RemoteSlot4;

    private bool bossActivated = false; // Biến bool để chắc chắn chỉ kích hoạt BossLast một lần

    void Start()
    {
        PickItem = FindObjectOfType<Pick_Item>();
    }

    public void AssignToRemoteSlot()
    {
        foreach (Image slot in SlotRemotes)
        {
            if (Player_Item.tag.Contains("HuyHieu") && slot.sprite == null)
            {
                slot.sprite = PickItem.currentSelectedSlot.sprite;
                PickItem.currentSelectedSlot.sprite = null;

                Color color = slot.color;
                color.a = 1;
                slot.color = color;

                Color currentSlotColor = PickItem.currentSelectedSlot.color;
                currentSlotColor.a = 0;
                PickItem.currentSelectedSlot.color = currentSlotColor;

                ButtonPut.SetActive(false);
                ButtonTake.SetActive(true);
                CheckFourHuyHieu();
                return;
            }
        }
    }

    public void RemoveFromRemoteSlot()
    {
        foreach (Image slot in SlotRemotes)
        {
            if (slot.sprite != null)
            {
                PickItem.AssignToSlot(slot);

                Color color = slot.color;
                color.a = 0;
                slot.color = color;
                slot.sprite = null;

                ButtonPut.SetActive(true);
                ButtonTake.SetActive(false);
                return;
            }
        }
    }

    // Hàm kiểm tra các slot và thực hiện hành động khi điều kiện thỏa mãn
    public void CheckFourHuyHieu()
    {
        if (!this.gameObject.name.Contains("2"))
        {
            // Kiểm tra điều kiện cho 4 slot cụ thể để kích hoạt BossLast một lần duy nhất
            bool requiredSlotsFilled =
                RemoteSlot0.sprite != null &&
                RemoteSlot1.sprite != null &&
                RemoteSlot3.sprite != null &&
                RemoteSlot4.sprite != null;

            if (requiredSlotsFilled && !bossActivated)
            {
                BossLast.SetActive(true);
                bossActivated = true; // Đảm bảo chỉ kích hoạt một lần
            }
        }
    }
    public void CheckAllSlotsForHuyHieu()
    {
       

            // Kiểm tra điều kiện cho 5 huy hiệu vào đúng vị trí
            bool allSlotsMatch =
                RemoteSlot0.sprite != null && RemoteSlot0.sprite.name == "HuyHieu_BMTA" &&
                RemoteSlot1.sprite != null && RemoteSlot1.sprite.name == "HuyHieu_TMDT" &&
                SlotRemotes[2].sprite != null && SlotRemotes[2].sprite.name == "HuyHieu_HieuTruong" &&
                RemoteSlot3.sprite != null && RemoteSlot3.sprite.name == "HuyHieu_CNTT" &&
                RemoteSlot4.sprite != null && RemoteSlot4.sprite.name == "HuyHieu_TKDH";

            if (allSlotsMatch)
            {
                Timing.SetActive(true); // Kích hoạt Timing khi đủ 5 huy hiệu
                RemoteBomb.SetActive(true); // Kích hoạt RemoteBomb khi đủ 5 huy hiệu
            }
        
    }
}
