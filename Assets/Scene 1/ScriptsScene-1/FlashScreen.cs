using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class FlashScreen : MonoBehaviour
{
    public GameObject introVIDEO;

    public GameObject loginVIDEO;

    void Start()
    {
        StartCoroutine(wait());
    }
    void Update()
    {



    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(10.147f);
        loginVIDEO.SetActive(true);
        introVIDEO.SetActive(false);
    }
}





