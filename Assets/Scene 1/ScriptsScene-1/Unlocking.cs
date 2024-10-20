using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlocking : MonoBehaviour
{
    public GameObject Player_Item;
    public string ItemNameToUnlock;
    public GameObject UnlockedObject;
    public GameObject LockObject;
    public GameObject MiniLockObject;

    // Start is called before the first frame update
    public  GameObject notice;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnUnlock()
    {
        if (Player_Item.tag == ItemNameToUnlock)
        {
            if (UnlockedObject != null)
            {
                UnlockedObject.SetActive(true);
            }
            if (LockObject != null)
            {
                LockObject.SetActive(false);
            }
            if (MiniLockObject != null)
            {
                MiniLockObject.SetActive(false);
            }
        }
        else
        {
            /* notice.OnClick("Cần chìa khóa để mở!");*/
            notice.SetActive(true);
            StartCoroutine(OffNotice());
        }

    }
    IEnumerator OffNotice()
    {
        yield return new WaitForSeconds(2) ;
        notice.SetActive(false);
    }
}
