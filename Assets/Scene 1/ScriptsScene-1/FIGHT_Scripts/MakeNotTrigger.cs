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
        if (other.gameObject.tag.Contains("Ultimate") && !other.gameObject.name.Contains("DucThang"))
        {
            other.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
        }
        if (other.gameObject.tag.Contains("Ultimate") && other.gameObject.name.Contains("DucThang"))
        {
            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.gravityScale = 0;
                rb.velocity = Vector2.zero; // Đặt velocity về 0
            }
        }
    }
}
