using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Settings : MonoBehaviour
{
    public GameObject Tick;
    public AudioListener TakeAudio;
    private string contentFilePath;
    private string objectValueFilePath;
    public GameObject LangOptions;
    public GameObject Button_Lang_ON;
    public GameObject Button_Lang_OFF;
   
    void Start()
    {
        contentFilePath = Path.Combine(Application.persistentDataPath, "Content_Teacher_sDay.txt");
        objectValueFilePath = Path.Combine(Application.persistentDataPath, "ObjectValue.txt");
    }

    public void Music()
    {

        if (Tick.activeSelf)
        {
            TakeAudio.enabled = true;
        }
        else
        {
            TakeAudio.enabled = false;
        }
    }
       
    

    public void ClearData()
    {
        string saveFilePath = Path.Combine(Application.persistentDataPath, "savefile.json");
        string inventorySavePath = Path.Combine(Application.persistentDataPath, "inventorySave.json");

        if (File.Exists(saveFilePath))
        {
            File.WriteAllText(saveFilePath, string.Empty);
            Debug.Log("Đã xóa dữ liệu trò chơi!");

        }

        if (File.Exists(inventorySavePath))
        {
            File.WriteAllText(inventorySavePath, string.Empty);
            Debug.Log("Đã xóa dữ liệu kho đồ!");
        }
    }

    public void LanguageStory_Vietnamese()
    {
        if (File.Exists(contentFilePath))
        {
            string content = File.ReadAllText(contentFilePath);

            if (!content.Contains("Ngày mai nhất định sẽ không diễn ra buổi lễ nhảm nhí đó."))
            {
                string vietnameseContent =
                    "1. Ngày mai nhất định sẽ không diễn ra buổi lễ nhảm nhí đó.$\n" +
                    "2. Năm 2024, vào 19/11 – chỉ còn 1 ngày nữa cho đến Ngày Nhà Giáo Việt Nam, " +
                    "có 1 cậu học sinh nghịch tên là Long chuyên bày trò phá phách, gây hỗn loạn FPOLY. " +
                    "Chuẩn bị đến ngày 20/11, cậu nhóc muốn gây ra một trò đùa ác, cậu sẽ lẻn vào Trường " +
                    "để phá hoại hệ thống điện, nhằm ngăn buổi lễ chào mừng Ngày Nhà Giáo Việt Nam diễn ra suôn sẻ. " +
                    "Người chơi sẽ vào vai cậu nhóc Long, vượt qua các thầy cô và bảo vệ của nhà Trường để thực hiện thành công “phi vụ” này.$\n" +
                    "\nThầyAn:\n" +
                    "3. Bạn kia đứng lại!$\n" +
                    "4. Em là học sinh ngành nào, sao lại vào trường lúc nửa đêm thế này?$\n" +
                    "5. Trông em rất khả nghi!$\n" +
                    "6. Tiếp chiêu!$\n" +
                    "--------------\n" +
                    "7. Bấm vào các vị trí khả nghi để tìm manh mối.$\n" +
                    "8. Khám phá các không gian mới để có thêm địa điểm khám phá.$\n" +
                    "9. Khi nghe tiếng bước chân của bác bảo vệ, nhấn để nín thở ẩn nấp.\n" +
                    "Đừng cố gắng chạy trốn!$";

                File.WriteAllText(contentFilePath, vietnameseContent);
                LangOptions.SetActive(false);
                Debug.Log("Đã đổi sang Tiếng Việt!");
            }
        }
    }

    public void LanguageStory_English()
    {
        if (File.Exists(contentFilePath))
        {
            string englishContent =
                "1. Tomorrow, the nonsense ceremony will definitely not take place.$\n" +
                "2. In 2024, on 19/11 – just 1 day before Vietnamese Teachers' Day, " +
                "a mischievous student named Long, who often caused trouble, disrupted FPOLY. " +
                "As 20/11 approaches, he plans to play a cruel prank by sneaking into the school " +
                "and sabotaging the electrical system, aiming to prevent the ceremony from going smoothly. " +
                "The player will take on the role of Long, avoiding teachers and guards in the school to successfully carry out his 'mission'.$\n" +
                "\nTeacherAn:\n" +
                "3. You there, stop!$\n" +
                "4. Which department are you from? Why are you in school at midnight?$\n" +
                "5. You look suspicious!$\n" +
                "6. Take this!$\n" +
                "--------------\n" +
                "7. Tap suspicious spots to find clues.$\n" +
                "8. Explore new areas to unlock more places.$\n" +
                "9. When you hear the guard's footsteps, press to hold your breath and hide.\n" +
                "Don't try to run away!$";

            File.WriteAllText(contentFilePath, englishContent);
            LangOptions.SetActive(false);
            Debug.Log("Changed to English!");

        }

    }
    public void LangOption_OFF()
    {
        if (LangOptions.activeSelf)
        {
            LangOptions.SetActive(false);
            Button_Lang_OFF.SetActive(false);
            Button_Lang_ON.SetActive(true);
        }
        
    }
    public void LangOption_ON()
    {
        if (!LangOptions.activeSelf)
        {
            LangOptions.SetActive(true);
            Button_Lang_ON.SetActive(false);
            Button_Lang_OFF.SetActive(true);
        }

    }
}
 