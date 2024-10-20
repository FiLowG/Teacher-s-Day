using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notice_Guide : MonoBehaviour
{
    public GameObject GuideEffects;
    public GameObject NoticePanel;
    public GameObject OffToOn;
    private bool OnEffects;
    private int ToOnEfffects = 1;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.layer == 3 && !OffToOn.activeSelf && ToOnEfffects == 1)
        {
            OnClickGuide();
            ToOnEfffects -= 1;
        }
    }
    public void OnClickGuide()
    {
        StartCoroutine(WaitNotice());
    }

    IEnumerator WaitNotice()
    {
        yield return new WaitForSeconds(1);
        if (GuideEffects != null && NoticePanel != null) 
        {
            GuideEffects.SetActive(true);
            NoticePanel.SetActive(true);
           
        }
    }
    public void OnClickOffEffects()
    {
        if (GuideEffects != null && NoticePanel != null)
        {
            GuideEffects.SetActive(false);
            NoticePanel.SetActive(false);
           
        }
    }
}
