using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossKhanhNgoc_Ultimate : MonoBehaviour
{
    public GameObject Ulti_Effects;
    public GameObject Ulti_Panel;
    // Start is called before the first frame update
    void Start()
    {
        Ulti_Panel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OFF_Effects()
    {
        Ulti_Effects.SetActive(false);
    }
}
