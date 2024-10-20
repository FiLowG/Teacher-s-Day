using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ultimate_IT : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
    }

    public void UltimateTime()
    {
        this.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        StartCoroutine(OffEffects());
    }

    IEnumerator OffEffects()
    {
        yield return new WaitForSeconds(3);
        this.transform.position = new Vector2(-0.0500000007f, 11.48f);
        this.gameObject.SetActive(false);
    }
}
