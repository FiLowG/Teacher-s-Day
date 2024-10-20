using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Settings : MonoBehaviour
{
    // Biến cho hàm Music
    public GameObject Tick;  // Biến Tick là object dùng để đánh dấu
    public GameObject BKGMusic;  // Biến BKGMusic dùng để bật/tắt nhạc nền
    public AudioListener TakeAudio;
    private string contentFilePath;
    private string objectValueFilePath;
    public GameObject LangOptions;
    void Start()
    {
        // Đường dẫn đến file
        contentFilePath = Path.Combine(Application.persistentDataPath, "Content_Teacher_sDay.txt");
        objectValueFilePath = Path.Combine(Application.persistentDataPath, "ObjectValue.txt");
    }

    // Hàm Music để bật/tắt nhạc nền
    public void Music()
    {
        if (BKGMusic != null)
        {

            if (Tick.activeSelf)
            {
                BKGMusic.SetActive(true);  // Nếu Tick đang active, bật nhạc nền
            }
            else
            {
                BKGMusic.SetActive(false);  // Nếu Tick không active, tắt nhạc nền
            }
        }
        else
        {
            TakeAudio.enabled = false;
        }
    }

    // Hàm ClearData để xóa dữ liệu lưu trữ của game
    public void ClearData()
    {
        string saveFilePath = Path.Combine(Application.persistentDataPath, "savefile.json");
        string inventorySavePath = Path.Combine(Application.persistentDataPath, "inventorySave.json");

        // Kiểm tra và xóa file savefile.json nếu tồn tại
        if (File.Exists(saveFilePath))
        {
            File.WriteAllText(saveFilePath, string.Empty);
            Debug.Log("Cleared savefile.json data");
        }

        // Kiểm tra và xóa file inventorySave.json nếu tồn tại
        if (File.Exists(inventorySavePath))
        {
            File.WriteAllText(inventorySavePath, string.Empty);
            Debug.Log("Cleared inventorySave.json data");
        }
    }

    // Hàm LanguageStory-Vietnamese để thay nội dung bằng tiếng Việt
    public void LanguageStory_Vietnamese()
    {
        if (File.Exists(contentFilePath))
        {
            // Đọc nội dung file hiện tại
            string content = File.ReadAllText(contentFilePath);

            // Kiểm tra nếu đã là tiếng Việt, giữ nguyên
            if (!content.Contains("Ngày mai nhất định sẽ không diễn ra buổi lễ nhảm nhí đó."))
            {
                // Nội dung bằng tiếng Việt
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

                // Ghi lại nội dung tiếng Việt
                File.WriteAllText(contentFilePath, vietnameseContent);
                LangOptions.SetActive(false);
            }
           
        }
      
    }

    // Hàm LanguageStory-English để thay toàn bộ nội dung bằng tiếng Anh
    public void LanguageStory_English()
    {
        if (File.Exists(contentFilePath))
        {
            // Nội dung bằng tiếng Anh
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

            // Ghi lại nội dung tiếng Anh
            File.WriteAllText(contentFilePath, englishContent);
            LangOptions.SetActive(false);
        }
        
    }
}
