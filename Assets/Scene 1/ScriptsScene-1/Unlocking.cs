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

    public GameObject notice;
    private Pick_Item NoneSlot;

    void Start()
    {
        NoneSlot = FindObjectOfType<Pick_Item>();
    }

    void Update()
    {
    }

    public void OnUnlock()
    {
        if (Player_Item.tag == ItemNameToUnlock)
        {
            if (UnlockedObject != null) UnlockedObject.SetActive(true);
            if (LockObject != null) LockObject.SetActive(false);
            if (MiniLockObject != null) MiniLockObject.SetActive(false);

            if (NoneSlot != null && NoneSlot.currentSelectedSlot != null)
            {
                NoneSlot.currentSelectedSlot.sprite = null;

                if (NoneSlot.currentActiveFrame != null)
                {
                    NoneSlot.currentActiveFrame.SetActive(false);
                    NoneSlot.currentActiveFrame = null;
                }

                NoneSlot.currentSelectedSlot = null;
            }
        }
        else
        {
            notice.SetActive(true);
            StartCoroutine(OffNotice());
        }
    }

    IEnumerator OffNotice()
    {
        yield return new WaitForSeconds(2);
        notice.SetActive(false);
    }
}
