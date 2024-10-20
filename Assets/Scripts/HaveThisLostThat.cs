using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaveThisLostThat : MonoBehaviour
{
    public GameObject Present;
    public GameObject Hidden;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (Present != null && Hidden != null && Present.activeSelf )
        {
            Hidden.SetActive(false);
        } 
       if (Present != null && Hidden != null && !Present.activeSelf)
            {
                Hidden.SetActive(true);
            } 
    }
}
