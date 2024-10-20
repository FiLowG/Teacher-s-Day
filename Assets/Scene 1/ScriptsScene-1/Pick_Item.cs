using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pick_Item : MonoBehaviour
{
    public Image SLOT1;
    public Image SLOT2;
    public Image SLOT3;
    public Image SLOT4;
    public Image SLOT5;

    public GameObject FrameSlot1;
    public GameObject FrameSlot2;
    public GameObject FrameSlot3;
    public GameObject FrameSlot4;
    public GameObject FrameSlot5;

    public GameObject Player_Item;
    private Image currentSelectedSlot; // Slot hiện tại đang được chọn
    private GameObject currentActiveFrame; // Frame hiện tại đang active

    // Hàm gọi để gán item vào slot
    void Update()
    {
      
            // Kiểm tra từng slot và điều chỉnh alpha dựa trên giá trị sprite
            CheckSlotAlpha(SLOT1);
            CheckSlotAlpha(SLOT2);
            CheckSlotAlpha(SLOT3);
            CheckSlotAlpha(SLOT4);
            CheckSlotAlpha(SLOT5);
        

        // Hàm kiểm tra và đặt alpha dựa trên sprite có hay không
        void CheckSlotAlpha(Image slot)
        {
            if (slot.sprite == null)
            {
                // Nếu sprite là null, đặt alpha về 0 (làm cho Image trong suốt)
                Color tempColor = slot.color;
                tempColor.a = 0;
                slot.color = tempColor;
            }
            else
            {
                // Nếu sprite không null, đặt alpha về 1 (hiển thị hình ảnh)
                Color tempColor = slot.color;
                tempColor.a = 1;
                slot.color = tempColor;
            }
        }

    }

    public void AssignToSlot(Image Item_Image)
    {
        if (Item_Image != null) // Kiểm tra nếu có hình ảnh được gán vào Item_Image
        {
            // Ưu tiên gán vào SLOT1, SLOT2, SLOT3... theo thứ tự nếu chúng trống
            if (SLOT1 != null && SLOT1.sprite == null)
            {
                AssignImageToSlot(SLOT1, Item_Image);
                SLOT1.tag = CheckItemTag(Item_Image);
            }
            else if (SLOT2 != null && SLOT2.sprite == null)
            {
                AssignImageToSlot(SLOT2, Item_Image);
                SLOT2.tag = CheckItemTag(Item_Image);
            }
            else if (SLOT3 != null && SLOT3.sprite == null)
            {
                AssignImageToSlot(SLOT3, Item_Image);
                SLOT3.tag = CheckItemTag(Item_Image);
            }
            else if (SLOT4 != null && SLOT4.sprite == null)
            {
                AssignImageToSlot(SLOT4, Item_Image);
                SLOT4.tag = CheckItemTag(Item_Image);
            }
            else if (SLOT5 != null && SLOT5.sprite == null)
            {
                AssignImageToSlot(SLOT5, Item_Image);
                SLOT5.tag = CheckItemTag(Item_Image);
            }
            else
            {
                Debug.Log("Tất cả các slot đã được sử dụng.");
            }
        }
        else
        {
            Debug.Log("Item_Image không hợp lệ.");
        }
    }

    public void PanelGotItem(GameObject panelGotItem)
    {
        panelGotItem.SetActive(true);
    }

    // Hàm riêng để gán hình ảnh và cài đặt màu sắc cho Image
    void AssignImageToSlot(Image slot, Image equipIcon)
    {
        slot.sprite = equipIcon.sprite;
        slot.color = new Color32(255, 255, 255, 255); // Hiển thị hình ảnh
        slot.enabled = true;
    }

    // Hàm kiểm tra tag của item và trả về tag tương ứng
    string CheckItemTag(Image equipIcon)
    {
        string itemName = equipIcon.sprite.name; // Lấy tên của sprite từ image
        foreach (var tag in UnityEditorInternal.InternalEditorUtility.tags)
        {
            if (tag.Contains(itemName))
            {
                return tag; // Nếu tên sprite có chứa tag phù hợp, trả về tag đó
            }
        }
        return "Untagged"; // Nếu không tìm thấy, trả về Untagged
    }

    // Hàm gọi khi bấm vào bất kỳ Button nào của Slot
    public void OnSlotButtonClick(int slotIndex)
    {
        Image selectedSlot = null;
        GameObject selectedFrame = null;

        switch (slotIndex)
        {
            case 1:
                selectedSlot = SLOT1;
                selectedFrame = FrameSlot1;
                break;
            case 2:
                selectedSlot = SLOT2;
                selectedFrame = FrameSlot2;
                break;
            case 3:
                selectedSlot = SLOT3;
                selectedFrame = FrameSlot3;
                break;
            case 4:
                selectedSlot = SLOT4;
                selectedFrame = FrameSlot4;
                break;
            case 5:
                selectedSlot = SLOT5;
                selectedFrame = FrameSlot5;
                break;
        }

        if (selectedSlot != null && selectedSlot.sprite != null) // Kiểm tra slot có hình ảnh không
        {
            if (currentSelectedSlot != null && currentSelectedSlot == selectedSlot)
            {
                // Nếu slot đã được chọn, nhấn lại sẽ tắt frame
                selectedFrame.SetActive(false);
                currentSelectedSlot = null;
                currentActiveFrame = null;
                Player_Item.tag = "Untagged";
            }
            else
            {
                // Nếu slot khác được chọn, tắt frame cũ và bật frame mới
                if (currentActiveFrame != null)
                {
                    currentActiveFrame.SetActive(false);
                }

                selectedFrame.SetActive(true);
                currentSelectedSlot = selectedSlot;
                currentActiveFrame = selectedFrame;

                // Gán tag của slot cho Player_Item
                Player_Item.tag = selectedSlot.tag;
            }
        }
    }
}
