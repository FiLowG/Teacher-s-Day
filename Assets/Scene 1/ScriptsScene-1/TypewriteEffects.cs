using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.IO;

public class TypewriterEffect : MonoBehaviour
{
    public Text uiText;
    private string filePath;  // Đường dẫn tới file nội dung
    public int[] contentNumbers;  // Mảng số thứ tự nội dung cần hiển thị
    public float typingSpeed;  // Tốc độ gõ chữ
    public GameObject khungtext;
    public GameObject Talker;
    private int currentContentIndex = 0;  // Chỉ mục hiện tại trong mảng
    private Coroutine typingCoroutine;
    private bool isTyping = false;
    public GameObject StartAfterTalk;
    public GameObject Breath;
    void Start()
    {
        filePath = Application.persistentDataPath + "/Content_Teacher_sDay.txt";
        ShowNextContent();  // Hiển thị nội dung đầu tiên
    }
    void Update()
    {
        if (khungtext.activeSelf)
        {
            Breath.SetActive(false);
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

        isTyping = false;  // Đã gõ xong nội dung
    }

    string GetContentFromTxt(int contentNumber)
    {
        try
        {
            // Đọc toàn bộ nội dung file TXT
            string fullText = File.ReadAllText(filePath);

            // Chia nội dung thành các đoạn bằng cách tách theo số thứ tự (VD: "1. ", "2. ")
            string[] sections = fullText.Split(new string[] { $"{contentNumber}. " }, System.StringSplitOptions.None);

            // Kiểm tra nếu tìm thấy nội dung
            if (sections.Length > 1)
            {
                string sectionContent = sections[1]; // Lấy phần sau số thứ tự tương ứng

                // Cắt phần văn bản tới dấu $ nếu có
                int indexOfEnd = sectionContent.IndexOf('$');
                if (indexOfEnd >= 0)
                {
                    sectionContent = sectionContent.Substring(0, indexOfEnd);
                }

                return sectionContent.Trim(); // Xóa khoảng trắng thừa
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
        // Kiểm tra xem đã hết nội dung chưa
        if (currentContentIndex < contentNumbers.Length)
        {
            string content = GetContentFromTxt(contentNumbers[currentContentIndex]);
            currentContentIndex++;

            if (!string.IsNullOrEmpty(content))
            {
                // Nếu đang chạy typing, dừng lại và hiển thị nội dung ngay lập tức
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
            // Đã hết nội dung, ẩn các thành phần UI
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
            // Nếu đang gõ, dừng gõ và hiển thị ngay lập tức nội dung hiện tại
            StopCoroutine(typingCoroutine);
            uiText.text = GetContentFromTxt(contentNumbers[currentContentIndex - 1]);  // Hiển thị ngay nội dung hiện tại
            isTyping = false;
        }
        else
        {
            // Nếu đã gõ xong, chuyển sang nội dung tiếp theo
            ShowNextContent();
        }
    }
}
