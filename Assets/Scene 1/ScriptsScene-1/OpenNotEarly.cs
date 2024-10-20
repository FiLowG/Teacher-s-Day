using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenNotEarly : MonoBehaviour
{
    public GameObject KhungText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(NotEarly());
    }

    void Update()
    {
        
    }
    IEnumerator NotEarly()
    {
        yield return new WaitForSeconds(2);
        KhungText.SetActive(true);
    }
}
