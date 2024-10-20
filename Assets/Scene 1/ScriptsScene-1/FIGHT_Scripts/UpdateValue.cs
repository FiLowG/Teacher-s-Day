using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameStatsManager : MonoBehaviour
{
    private Dictionary<string, float> stats = new Dictionary<string, float>();

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
                string[] parts = line.Split(';');
                foreach (var part in parts)
                {
                    if (string.IsNullOrWhiteSpace(part)) continue;

                    string[] keyValue = part.Split('=');
                    if (keyValue.Length == 2)
                    {
                        string key = keyValue[0].Trim();
                        string valueStr = keyValue[1].Trim();

                        if (float.TryParse(valueStr, out float value))
                        {
                            stats[key] = value;
                        }
                    }
                }
            }
        }
    }

    void Update()
    {
    }

    public float GetPlayerHealth() => GetStatValue("PlayerHealth") / 100;
    public float GetPlayerMana() => GetStatValue("PlayerMana") / 10;
    public float GetPlayerUltimate() => GetStatValue("PlayerUltimate") / 100;
    public float GetPlayerAttack() => GetStatValue("PlayerAttack") / 100;
    public float GetPlayerHeal() => GetStatValue("PlayerHeal") / 100;
    public float GetPlayerShield() => GetStatValue("PlayerShield");

    public float GetBossHealth() => GetStatValue("BossHealth") / 100;
    public float GetBossMana() => GetStatValue("BossMana") / 10;
    public float GetBossAttack() => GetStatValue("BossAttack") / 100;
    public float GetBossHeal() => GetStatValue("BossHeal") / 100;
    public float GetBossShield() => GetStatValue("BossShield");

    private float GetStatValue(string key)
    {
        return stats.ContainsKey(key) ? stats[key] : 0f;
    }
}
