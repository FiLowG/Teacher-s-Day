using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class InventoryManager : MonoBehaviour
{
    public Image[] slots = new Image[5];
    private string saveFilePath;

    [System.Serializable]
    public class InventoryData
    {
        public List<string> slotSprites;
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
                data.slotSprites.Add(slot.sprite.name);
            }
            else
            {
                data.slotSprites.Add("");
            }
        }

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(saveFilePath, json);
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
                    Sprite itemSprite = Resources.Load<Sprite>(data.slotSprites[i]);
                    if (itemSprite != null)
                    {
                        slots[i].sprite = itemSprite;
                        slots[i].color = new Color(1, 1, 1, 1);
                    }
                }
                else
                {
                    slots[i].sprite = null;
                    slots[i].color = new Color(1, 1, 1, 0);
                }
            }
        }
    }
}
