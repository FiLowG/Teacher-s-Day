using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class TypewriterEffect : MonoBehaviour
{
    public Text uiText;
    private string filePath;
    public int[] contentNumbers;
    public float typingSpeed;
    public GameObject khungtext;
    public GameObject Talker;
    private int currentContentIndex = 0;
    private Coroutine typingCoroutine;
    private bool isTyping = false;
    public GameObject StartAfterTalk;
    public GameObject Breath;

    void Start()
    {
        filePath = Application.persistentDataPath + "/Content_Teacher_sDay.txt";
        ShowNextContent();
    }

    void Update()
    {
        if (khungtext.activeSelf)
        {
            if (Breath != null)
            {
                Breath.SetActive(false);
            }
        }
    }

    IEnumerator TypeText(string content)
    {
        uiText.text = "";
        isTyping = true;

        foreach (char letter in content)
        {
            uiText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        isTyping = false;
    }

    string GetContentFromTxt(int contentNumber)
    {
        try
        {
            string fullText = File.ReadAllText(filePath);
            string[] sections = fullText.Split(new string[] { $"{contentNumber}. " }, System.StringSplitOptions.None);

            if (sections.Length > 1)
            {
                string sectionContent = sections[1];
                int indexOfEnd = sectionContent.IndexOf('$');
                if (indexOfEnd >= 0)
                {
                    sectionContent = sectionContent.Substring(0, indexOfEnd);
                }

                return sectionContent.Trim();
            }
            else
            {
                Debug.LogError("Không tìm thấy nội dung với số thứ tự này.");
                return null;
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Có lỗi khi đọc file TXT: {e.Message}");
            return null;
        }
    }

    void ShowNextContent()
    {
        if (currentContentIndex < contentNumbers.Length)
        {
            string content = GetContentFromTxt(contentNumbers[currentContentIndex]);
            currentContentIndex++;

            if (!string.IsNullOrEmpty(content))
            {
                if (typingCoroutine != null)
                {
                    StopCoroutine(typingCoroutine);
                }
                typingCoroutine = StartCoroutine(TypeText(content));
            }
            else
            {
                Debug.LogError("Nội dung không tồn tại hoặc không thể đọc được!");
            }
        }
        else
        {
            khungtext.SetActive(false);
            if (Talker != null)
            {
                if (StartAfterTalk != null)
                {
                    StartAfterTalk.SetActive(true);
                }
                if (Breath != null)
                {
                    Breath.SetActive(true);
                }
                Talker.SetActive(false);
            }
        }
    }

    public void OnButtonNext()
    {
        if (isTyping)
        {
            StopCoroutine(typingCoroutine);
            uiText.text = GetContentFromTxt(contentNumbers[currentContentIndex - 1]);
            isTyping = false;
        }
        else
        {
            ShowNextContent();
        }
    }
}
