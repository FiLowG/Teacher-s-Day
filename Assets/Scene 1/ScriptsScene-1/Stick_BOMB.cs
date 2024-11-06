using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stick_BOMB : MonoBehaviour
{
    public GameObject Player_Item;
    public GameObject OnBOMB;
    public Image SLOT7;
    public Image PutBOMB;
    public GameObject Notice;
    // Start is called before the first frame update
    void Start()
    {
        OnBOMB.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void PutbomB()
    {
        // Kiểm tra nếu tag của Player_Item là "BOMB"
        if (Player_Item.tag == "BOMB")
        {
            // Gán sprite của SLOT7 vào PutBOMB
            PutBOMB.sprite = SLOT7.sprite;
            SLOT7.sprite = null;
            // Thiết lập alpha của SLOT7 về 0
            Color slot7Color = SLOT7.color;
            slot7Color.a = 0;
            SLOT7.color = slot7Color;
            

            // Thiết lập alpha của PutBOMB lên 255
            Color putBOMBColor = PutBOMB.color;
            putBOMBColor.a = 1;
            PutBOMB.color = putBOMBColor;

            // Kích hoạt OnBOMB
            OnBOMB.SetActive(true);
        }
        else if (!Notice.activeSelf)
        {
            StartCoroutine(Notices());
        }
    }
    IEnumerator Notices()
    {
        Notice.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        Notice.SetActive(false);
    }
    
}
