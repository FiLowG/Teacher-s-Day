using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour
{
    public GameObject OpenText; 
    public GameObject OpenYet;
    public GameObject Opened;
    // Start is called before the first frame update
    void Start()
    {
       
            OpenYet.SetActive(false);
            Opened.SetActive(true);
        
    }

    void Update()
    {
        
    }
}
