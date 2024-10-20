using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeNotTrigger : MonoBehaviour
{
    void Start()
    {
    }

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
