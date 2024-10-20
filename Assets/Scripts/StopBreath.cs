using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBreath : MonoBehaviour
{
    public GameObject breathing;

    public void OnButtonPress()
    {
        if (breathing != null)
        {
            breathing.SetActive(false);
        }
    }

    public void OnButtonRelease()
    {
        if (breathing != null)
        {
            breathing.SetActive(true);
        }
    }
}
