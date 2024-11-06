using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Unlock_BoxLock : MonoBehaviour
{
    public GameObject First;
    public GameObject Second;
    public GameObject Third;
    public GameObject OFF1;
    public GameObject OFF2;
    public GameObject ON1;
    public GameObject ON2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (First.activeSelf && Second.activeSelf && Third.activeSelf) 
        {
            if (ON1 != null) { ON1.SetActive(true); }
            if (ON2 != null) { ON2.SetActive(true); }
            if (OFF1 != null) { OFF1.SetActive(false); }
            if (OFF2 != null) { OFF2.SetActive(false); }
        }
    }
}
