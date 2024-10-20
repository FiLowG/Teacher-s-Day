using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroVideo : MonoBehaviour
{
    public GameObject introVideo;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(IntroOfff());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator IntroOfff()
    {
        yield return new WaitForSeconds(10.6f);
        introVideo.SetActive(false);
    }
}
