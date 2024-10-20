using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ultimate_IT : MonoBehaviour
{ 

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
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
