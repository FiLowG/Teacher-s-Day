using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaveThisLostThat : MonoBehaviour
{
    public GameObject Present;
    public GameObject Present2;
    public GameObject Hidden;

    void Start()
    {
    }

    void Update()
    {
        if (Present2 != null)
        {
            if (Present != null && Hidden != null && !Present.activeSelf || Present != null && !Present2.activeSelf)
            {
                Hidden.SetActive(true);
            }
            if (Present != null && Hidden != null && Present.activeSelf || Present != null && Hidden != null && Present2.activeSelf)
            {
                Hidden.SetActive(false);
            }
        }
        else
        {
            if (Present != null && Hidden != null && !Present.activeSelf)
            {
                Hidden.SetActive(true);
            }
            if (Present != null && Hidden != null && Present.activeSelf)
            {
                Hidden.SetActive(false);
            }
        }
    }
}
