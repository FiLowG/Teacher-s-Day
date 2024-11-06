using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPlayer : MonoBehaviour
{
    public GameObject Old_Hand;
    public GameObject New_Hand;
    public GameObject Effects;
  /*  public GameObject Sound;*/
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OFF_Old_Hand()
    {
        New_Hand.SetActive(true);
        Old_Hand.SetActive(false);
       
    }
    public void OFF_New_Hand()
    {
        Old_Hand.SetActive(true);
        New_Hand.SetActive(false);
       
    }
    public void ON_Effects()
    {
        Effects.SetActive(true);
    }
    /*public void ON_Sound()
    { 
        Sound.SetActive(true);
    }*/
}
