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
        GameObject[] allObjects = FindObjectsOfType<GameObject>();
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

                foreach (GameObject duplicate in entry.Value)
                {
                }
            }
        }

        if (!hasDuplicate)
        {
        }
    }
}
