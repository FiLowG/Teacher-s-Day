using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DucThang_Ultimate : MonoBehaviour
{
    public Image HealBar;
    public Image healBar_Player;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(HealUltimate());
        StartCoroutine(DameUltimate());
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator HealUltimate()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            HealBar.fillAmount += 0.02f;

        }

    }
    IEnumerator DameUltimate()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            healBar_Player.fillAmount -= 0.01f;

        }

    }
}
