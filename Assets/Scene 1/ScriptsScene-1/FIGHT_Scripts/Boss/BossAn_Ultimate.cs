using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAn_Ultimate : MonoBehaviour
{
    public GameObject skill1;
    public GameObject skill2;
    public GameObject skill3;
    public GameObject skill4;

    private List<int> weightedList;

    void OnEnable()
    {
        weightedList = new List<int>();

        for (int i = 0; i < 1; i++) { weightedList.Add(1); }
        for (int i = 0; i < 2; i++) { weightedList.Add(2); }
        for (int i = 0; i < 7; i++) { weightedList.Add(3); }
        for (int i = 0; i < 7; i++) { weightedList.Add(4); }

        StartCoroutine(WaitToRandom());
    }

    IEnumerator WaitToRandom()
    {
        yield return new WaitForSeconds(2);
        RandomDeleteSkill();
    }

    void RandomDeleteSkill()
    {
        if (weightedList.Count == 0)
        {
            Debug.Log("Out of skills.");
            return;
        }

        int randomIndex = Random.Range(0, weightedList.Count);
        int randomSkill = weightedList[randomIndex];

        switch (randomSkill)
        {
            case 1:
                if (skill1.activeSelf)
                {
                    skill1.SetActive(false);
                    RemoveFromWeightedList(1);
                }
                break;
            case 2:
                if (skill2.activeSelf)
                {
                    skill2.SetActive(false);
                    RemoveFromWeightedList(2);
                }
                break;
            case 3:
                if (skill3.activeSelf)
                {
                    skill3.SetActive(false);
                    RemoveFromWeightedList(3);
                }
                break;
            case 4:
                if (skill4.activeSelf)
                {
                    skill4.SetActive(false);
                    RemoveFromWeightedList(4);
                }
                break;
        }

        Debug.Log("Skill " + randomSkill + " active false.");
    }

    void RemoveFromWeightedList(int skillNumber)
    {
        weightedList.RemoveAll(skill => skill == skillNumber);
    }
}
