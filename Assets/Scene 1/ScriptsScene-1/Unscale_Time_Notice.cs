using System.Collections;
using UnityEngine;

public class Unscale_Time_Notice : MonoBehaviour
{
    public GameObject NoticePanel;
    public GameObject GuideEffects;

    private bool isNoticeActive = false;

    void Start()
    {
        if (NoticePanel != null)
        {
            NoticePanel.SetActive(false);
        }

        if (GuideEffects != null)
        {
            GuideEffects.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            ToggleNotice();
        }
    }

    public void ToggleNotice()
    {
        isNoticeActive = !isNoticeActive;

        if (isNoticeActive)
        {
            Time.timeScale = 0;
            if (NoticePanel != null)
            {
                NoticePanel.SetActive(true);
            }

            if (GuideEffects != null)
            {
                GuideEffects.SetActive(true);
            }
        }
        else
        {
            Time.timeScale = 1;
            if (NoticePanel != null)
            {
                NoticePanel.SetActive(false);
            }

            if (GuideEffects != null)
            {
                GuideEffects.SetActive(false);
            }
        }
    }
}
