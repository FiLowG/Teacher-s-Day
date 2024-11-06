using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Hanh_Ultimate : MonoBehaviour
{
    public Image HealthPlayer;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Healing());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Healing()
    {
        for (int i = 0; i < 4; i++)
        {


            HealthPlayer.fillAmount -= 0.12f;

            yield return new WaitForSeconds(0.2f);
        }
    }
}
