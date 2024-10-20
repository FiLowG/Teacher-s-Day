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
    public Image currentSelectedSlot;
    public GameObject currentActiveFrame;

    void Update()
    {
        CheckSlotAlpha(SLOT1);
        CheckSlotAlpha(SLOT2);
        CheckSlotAlpha(SLOT3);
        CheckSlotAlpha(SLOT4);
        CheckSlotAlpha(SLOT5);

        void CheckSlotAlpha(Image slot)
        {
            if (slot.sprite == null)
            {
                Color tempColor = slot.color;
                tempColor.a = 0;
                slot.color = tempColor;
            }
            else
            {
                Color tempColor = slot.color;
                tempColor.a = 1;
                slot.color = tempColor;
            }
        }
    }

    public void AssignToSlot(Image Item_Image)
    {
        if (Item_Image != null)
        {
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
        }
    }

    public void PanelGotItem(GameObject panelGotItem)
    {
        panelGotItem.SetActive(true);
    }

    void AssignImageToSlot(Image slot, Image equipIcon)
    {
        slot.sprite = equipIcon.sprite;
        slot.color = new Color32(255, 255, 255, 255);
        slot.enabled = true;
    }

    string CheckItemTag(Image equipIcon)
    {
        string itemName = equipIcon.sprite.name;
        foreach (var tag in UnityEditorInternal.InternalEditorUtility.tags)
        {
            if (tag.Contains(itemName))
            {
                return tag;
            }
        }
        return "Untagged";
    }

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

        if (selectedSlot != null && selectedSlot.sprite != null)
        {
            if (currentSelectedSlot != null && currentSelectedSlot == selectedSlot)
            {
                selectedFrame.SetActive(false);
                currentSelectedSlot = null;
                currentActiveFrame = null;
                Player_Item.tag = "Untagged";
            }
            else
            {
                if (currentActiveFrame != null)
                {
                    currentActiveFrame.SetActive(false);
                }

                selectedFrame.SetActive(true);
                currentSelectedSlot = selectedSlot;
                currentActiveFrame = selectedFrame;

                Player_Item.tag = selectedSlot.tag;
            }
        }
    }
}
