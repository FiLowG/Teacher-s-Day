using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{
    public GameObject hide;
    public Text pass;
    private Coroutine blinkCoroutine;

    void Start()
    {
        if (pass.text == "")
        {
            blinkCoroutine = StartCoroutine(Blinku());
        }
    }

    void Update()
    {
        if (pass.text != "" && blinkCoroutine != null)
        {
            StopCoroutine(blinkCoroutine);
            blinkCoroutine = null;
            hide.SetActive(true);
        }
        else if (pass.text == "" && blinkCoroutine == null)
        {
            blinkCoroutine = StartCoroutine(Blinku());
        }
    }

    IEnumerator Blinku()
    {
        while (pass.text == "")
        {
            hide.SetActive(false);
            yield return new WaitForSeconds(1f);
            hide.SetActive(true);
            yield return new WaitForSeconds(1f);
        }
    }
}
