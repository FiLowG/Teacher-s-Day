using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSettings : MonoBehaviour
{
    public GameObject OnIconSFX;
    public GameObject OffIconSFX;
    public GameObject OnIconMusic;
    public GameObject OffIconMusic;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnToggleSFX()
    {
        OnIconSFX.SetActive(true);
        OffIconSFX.SetActive(false);
    }
    public void OffToggleSFX()
    {
        OnIconSFX.SetActive(false);
        OffIconSFX.SetActive(true);
    }
    public void OnToggleMusic()
    {
        OnIconMusic.SetActive(true);
        OffIconMusic.SetActive(false);
    }
    public void OffToggleMusic()
    {
        OnIconMusic.SetActive(false);
        OffIconMusic.SetActive(true);
    }
}
