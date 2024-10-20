using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class InventoryManager : MonoBehaviour
{
    public Image[] slots = new Image[5]; // 5 slot đồ
    private string saveFilePath;

    [System.Serializable]
    public class InventoryData
    {
        public List<string> slotSprites; // Lưu tên của sprite
    }

    void Start()
    {
        saveFilePath = Application.persistentDataPath + "/inventorySave.json";
    }

    public void SaveInventory()
    {
        InventoryData data = new InventoryData();
        data.slotSprites = new List<string>();

        foreach (Image slot in slots)
        {
            if (slot.sprite != null)
            {
                data.slotSprites.Add(slot.sprite.name); // Lưu tên sprite
            }
            else
            {
                data.slotSprites.Add(""); // Nếu slot trống
            }
        }

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(saveFilePath, json);
        Debug.Log("Inventory Saved: " + saveFilePath);
    }

    public void LoadInventory()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            InventoryData data = JsonUtility.FromJson<InventoryData>(json);

            for (int i = 0; i < slots.Length; i++)
            {
                if (!string.IsNullOrEmpty(data.slotSprites[i]))
                {
                    // Tìm sprite theo tên trong Resources (bạn phải đảm bảo sprite nằm trong thư mục Resources)
                    Sprite itemSprite = Resources.Load<Sprite>(data.slotSprites[i]);
                    if (itemSprite != null)
                    {
                        slots[i].sprite = itemSprite;
                        slots[i].color = new Color(1, 1, 1, 1); // Đảm bảo hiển thị
                    }
                }
                else
                {
                    slots[i].sprite = null;
                    slots[i].color = new Color(1, 1, 1, 0); // Ẩn hình ảnh nếu trống
                }
            }

            Debug.Log("Inventory Loaded");
        }
        else
        {
            Debug.LogWarning("Save file not found!");
        }
    }
}
