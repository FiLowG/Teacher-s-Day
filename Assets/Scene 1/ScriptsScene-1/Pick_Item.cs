using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Pick_Item : MonoBehaviour
{
    public List<string> availableTags = new List<string>(); // Danh sách để lưu các tag từ file
    public Image SLOT1;
    public Image SLOT2;
    public Image SLOT3;
    public Image SLOT4;
    public Image SLOT5;
    public Image SLOT6; // Slot đặc biệt cho thẻ thang máy
    public Image SLOT7; // Slot đặc biệt cho Bomb

    // Các frame slot
    public GameObject FrameSlot1;
    public GameObject FrameSlot2;
    public GameObject FrameSlot3;
    public GameObject FrameSlot4;
    public GameObject FrameSlot5;
    public GameObject FrameSlot6; // Frame cho SLOT6
    public GameObject FrameSlot7; // Frame cho SLOT7

    public GameObject Player_Item;
    public Image currentSelectedSlot;
    public GameObject currentActiveFrame;
    public GameObject remote;

    void Start()
    {
        LoadTagsFromFile(); // Gọi hàm để load tag từ file
    }

    // Hàm đọc file và lưu các tag vào danh sách
    void LoadTagsFromFile()
    {
        string path = Path.Combine(Application.persistentDataPath, "Tags.txt");

        if (File.Exists(path))
        {
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                availableTags.Add(line.Trim());
            }
        }
        else
        {
            Debug.LogError("Tags file not found at: " + path);
        }
    }

    void Update()
    {
       
       
        CheckSlotAlpha(SLOT1);
        CheckSlotAlpha(SLOT2);
        CheckSlotAlpha(SLOT3);
        CheckSlotAlpha(SLOT4);
        CheckSlotAlpha(SLOT5);
        CheckSlotAlpha(SLOT6);
        CheckSlotAlpha(SLOT7);
    }

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

    public void AssignToSlot(Image Item_Image)
    {
        if (Item_Image != null)
        {
            if (Item_Image.name.Contains("BOMB"))
            {
                if (SLOT7 != null && SLOT7.sprite == null) // Gán cho SLOT7 nếu là Bomb
                {
                    AssignImageToSlot(SLOT7, Item_Image);
                    SLOT7.tag = CheckItemTag(Item_Image);
                }
            }
            else if (Item_Image.name.Contains("Remote"))
            {
                if (SLOT6 != null && SLOT6.sprite == null) 
                {
                    AssignImageToSlot(SLOT6, Item_Image);
                    SLOT6.tag = CheckItemTag(Item_Image);
                }
            }
            else
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
        foreach (var tag in availableTags)
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
            case 6:
                selectedSlot = SLOT6;
                selectedFrame = FrameSlot6;
                break;
            case 7:
                selectedSlot = SLOT7;
                selectedFrame = FrameSlot7;
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
    public void OnBOMB()
    {
        if (Player_Item.tag == "Remote")
        {
            if (remote != null)
            {
                remote.SetActive(true);
            }
        }
    }
}
