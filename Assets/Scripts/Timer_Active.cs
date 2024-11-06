using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer_Active : MonoBehaviour
{
    public GameObject Object1;
    public GameObject Object2;
    public GameObject Object3;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(30);
        if (Object1 != null)
        {
            Object1.SetActive(true);
        }
        if (Object2 != null)
        {
            Object2.SetActive(true);
        }
        if (Object3 != null)
        {
            Object3.SetActive(true);
        }
    }
}