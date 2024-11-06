using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explain : MonoBehaviour
{
    public GameObject Panel_Explain;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickExplain()
    {
        Time.timeScale = 1;
        Panel_Explain.SetActive(false);
    }
}
