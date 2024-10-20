using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;  // Thêm thư viện để thao tác với file

public class CreateContentFile : MonoBehaviour
{
    // Đường dẫn đến thư mục lưu trữ file của Unity
    private string contentFilePath;
    private string objectValueFilePath;

    // Start is called before the first frame update
    void Start()
    {
        // Đường dẫn đến file trong Application.persistentDataPath
        contentFilePath = Path.Combine(Application.persistentDataPath, "Content_Teacher_sDay.txt");
        objectValueFilePath = Path.Combine(Application.persistentDataPath, "ObjectValue.txt");

        // Tạo file nếu chưa tồn tại
        CreateContentFileIfNotExists();
        CreateObjectValueFileIfNotExists();
    }

    // Tạo file Content_Teacher_sDay.txt nếu chưa tồn tại
    private void CreateContentFileIfNotExists()
    {
        if (!File.Exists(contentFilePath))
        {
            // Nội dung của file Content_Teacher_sDay.txt
            string content =
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

            // Ghi nội dung vào file
            File.WriteAllText(contentFilePath, content);
            Debug.Log("Created Content_Teacher_sDay.txt at " + contentFilePath);
        }
        else
        {
            Debug.Log("Content_Teacher_sDay.txt already exists at " + contentFilePath);
        }
    }

    // Tạo file ObjectValue.txt nếu chưa tồn tại
    private void CreateObjectValueFileIfNotExists()
    {
        if (!File.Exists(objectValueFilePath))
        {
            // Nội dung của file ObjectValue.txt
            string objectValues =
                "PlayerHealth=100;\n" +
                "PlayerMana=10;\n" +
                "PlayerUltimate=0.06;\n" +
                "PlayerAttack=15;\n" +
                "PlayerHeal=0.05;\n" +
                "PlayerShield=10;\n" +
                "BossHealth=100;\n" +
                "BossMana=10;\n" +
                "BossAttack=15;\n" +
                "BossHeal=0.05;\n" +
                "BossShield=15;";

            // Ghi nội dung vào file
            File.WriteAllText(objectValueFilePath, objectValues);
            Debug.Log("Created ObjectValue.txt at " + objectValueFilePath);
        }
        else
        {
            Debug.Log("ObjectValue.txt already exists at " + objectValueFilePath);
        }
    }
}
