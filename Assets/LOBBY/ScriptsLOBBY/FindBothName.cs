using System.Collections.Generic;
using UnityEngine;

public class FindDuplicateObjects : MonoBehaviour
{
    void Start()
    {
        FindDuplicateObjectsInScene();
    }

    void FindDuplicateObjectsInScene()
    {
        // Tìm tất cả GameObjects, bao gồm cả những GameObject chưa kích hoạt
        GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject>(true);
        Dictionary<string, List<GameObject>> objectNameDictionary = new Dictionary<string, List<GameObject>>();

        bool hasDuplicate = false;

        foreach (GameObject obj in allObjects)
        {
            string objectName = obj.name;

            if (objectNameDictionary.ContainsKey(objectName))
            {
                objectNameDictionary[objectName].Add(obj);
            }
            else
            {
                objectNameDictionary[objectName] = new List<GameObject> { obj };
            }
        }

        foreach (KeyValuePair<string, List<GameObject>> entry in objectNameDictionary)
        {
            if (entry.Value.Count > 1)
            {
                hasDuplicate = true;
                Debug.Log("Found duplicates for: " + entry.Key + " (Count: " + entry.Value.Count + ")");

                for (int i = 0; i < entry.Value.Count; i++)
                {
                    GameObject duplicate = entry.Value[i];
                    duplicate.name = entry.Key + " +" + (i + 1); // Đổi tên GameObject
                    Debug.Log("Renamed to: " + duplicate.name);
                }
            }
        }

        if (!hasDuplicate)
        {
            Debug.Log("No duplicates found.");
        }
    }
}
