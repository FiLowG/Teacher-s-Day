using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameStatsManager : MonoBehaviour
{
    private Dictionary<string, int> stats = new Dictionary<string, int>();

    void Start()
    {
        LoadStats();
    }

    void LoadStats()
    {
        string path = Application.persistentDataPath + "/ObjectValue.txt";

        if (File.Exists(path))
        {
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                // Tách các chỉ số theo dấu ";" và "="
                string[] parts = line.Split(';');
                foreach (var part in parts)
                {
                    if (string.IsNullOrWhiteSpace(part)) continue; // Bỏ qua các phần trống

                    string[] keyValue = part.Split('=');
                    if (keyValue.Length == 2)
                    {
                        string key = keyValue[0].Trim();  // Khóa
                        int value = int.Parse(keyValue[1].Trim());  // Giá trị
                        stats[key] = value;  // Lưu vào Dictionary
                    }
                }
            }
        }
        else
        {
            Debug.LogWarning("File không tồn tại: " + path);
        }
    }

    // Các hàm đọc từng chỉ số
    public float GetPlayerHealth() => GetStatValue("PlayerHealth");
    public float GetPlayerMana() => GetStatValue("PlayerMana");
    public float GetPlayerUltimate() => GetStatValue("PlayerUltimate");
    public float GetPlayerAttack() => GetStatValue("PlayerAttack");
    public float GetPlayerHeal() => GetStatValue("PlayerHeal");
    public float GetPlayerShield() => GetStatValue("PlayerShield");

    public float GetBossHealth() => GetStatValue("BossHealth");
    public float GetBossMana() => GetStatValue("BossMana");
    public float GetBossAttack() => GetStatValue("BossAttack");
    public float GetBossShield() => GetStatValue("BossShield");
    public float GetBossHeal() => GetStatValue("BossHeal");

    private int GetStatValue(string key)
    {
        return stats.ContainsKey(key) ? stats[key] : 0; // Trả về 0 nếu không tìm thấy
    }
}
