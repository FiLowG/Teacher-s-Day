using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeNotTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Contains("Ultimate"))
        {
            other.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        }
    }
}
