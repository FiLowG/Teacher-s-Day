using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq; // Cần thiết để sử dụng LINQ
using UnityEngine.SceneManagement;
[System.Serializable]
public class Basic_SaveData
{
    public Basic_GameState[] states;
}

[System.Serializable]
public class Basic_GameState
{
    public string gameObjectName;
    public bool isActive;
}

public class Basic_GameManager : MonoBehaviour
{

    void Update()
    {
        Debug.Log(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void SaveGame()
    {
        List<Basic_GameState> gameStates = new List<Basic_GameState>();

        // Lặp qua tất cả các GameObject trong scene hiện tại
        foreach (GameObject obj in UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects())
        {
            SaveGameObject(obj, gameStates);
        }

        Basic_SaveData saveData = new Basic_SaveData { states = gameStates.ToArray() };
        string json = JsonUtility.ToJson(saveData, true);
        string filePath = Application.persistentDataPath + "/savefile.json";
        File.WriteAllText(filePath, json);
        Debug.Log("Game Saved: " + filePath);
    }

    private void SaveGameObject(GameObject obj, List<Basic_GameState> gameStates)
    {
        Basic_GameState state = new Basic_GameState()
        {
            gameObjectName = obj.name,
            isActive = obj.activeSelf
        };
        gameStates.Add(state);

        // Ghi lại trạng thái các con của GameObject
        foreach (Transform child in obj.transform)
        {
            SaveGameObject(child.gameObject, gameStates);
        }
    }

    public void LoadGame()
    {
        if (this.gameObject.layer == 6)
        {
            SceneManager.LoadScene("Scene 1");
        }

        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Basic_SaveData loadedData = JsonUtility.FromJson<Basic_SaveData>(json);

            foreach (var state in loadedData.states)
            {
                // Tìm các GameObject nhưng chỉ trong scene hiện tại
                GameObject obj = Resources.FindObjectsOfTypeAll<GameObject>()
                    .FirstOrDefault(g => g.name == state.gameObjectName
                    && g.scene.name == UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);

                if (obj != null)
                {
                    // Khôi phục trạng thái active/inactive của đối tượng
                    obj.SetActive(state.isActive);
                }
                else
                {
                    Debug.LogWarning("Không tìm thấy GameObject: " + state.gameObjectName + " trong scene hiện tại.");
                }
            }

            Debug.Log("Load game hoàn thành.");
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
        }
    }
}