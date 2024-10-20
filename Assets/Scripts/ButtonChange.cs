using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonChange : MonoBehaviour
{
    public GameObject old;
    public GameObject newbie;
    public GameObject old2;
    public GameObject newbie2;
    public GameObject old3;
    public GameObject newbie3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClickChange()
    {
       
        if (newbie != null)
        {
            newbie.SetActive(true);
        }
        if (newbie2 != null)
        {
            newbie2.SetActive(true);
        }
        if (newbie3 != null)
        {
            newbie3.SetActive(true);
        }
        if (old != null)
        {
            old.SetActive(false);
        }
        if (old2 != null)
        {
            old2.SetActive(false);
        }
        if (old3 != null)
        {
            old3.SetActive(false);
        }
    }
    /*public void ChangeScene1()
    {

        if (newbie != null)
        {
            newbie.SetActive(true);
        }
        if (old != null)
        {
            old.SetActive(false);
        }
    }
    public void ChangeScene2()
    {

        if (newbie2 != null)
        {
            newbie.SetActive(true);
        }
        if (old2 != null)
        {
            old.SetActive(false);
        }
    }
    public void ChangeScene3()
    {

        if (newbie3 != null)
        {
            newbie.SetActive(true);
        }
        if (old3 != null)
        {
            old.SetActive(false);
        }
    }*/
}
