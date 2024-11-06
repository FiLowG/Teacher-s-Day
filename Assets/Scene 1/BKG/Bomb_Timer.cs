using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_Timer : MonoBehaviour
{
    public GameObject BOMB;
    public GameObject WinScene;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(7);
        WinScene.SetActive(true);
        yield return new WaitForSeconds(4);
        BOMB.SetActive(false);
    }
}
