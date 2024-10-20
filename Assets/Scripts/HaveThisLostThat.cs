using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaveThisLostThat : MonoBehaviour
{
    public GameObject Present;
    public GameObject Hidden;

    void Start()
    {
    }

    void Update()
    {
        if (Present != null && Hidden != null && Present.activeSelf)
        {
            Hidden.SetActive(false);
        }
        if (Present != null && Hidden != null && !Present.activeSelf)
        {
            Hidden.SetActive(true);
        }
    }
}
