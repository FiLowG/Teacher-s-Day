using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CreateContentFile : MonoBehaviour
{
    private string contentFilePath;
    private string objectValueFilePath;
    private string tagsFilePath;

    void Start()
    {
        contentFilePath = Path.Combine(Application.persistentDataPath, "Content_Teacher_sDay.txt");
        objectValueFilePath = Path.Combine(Application.persistentDataPath, "ObjectValue.txt");
        tagsFilePath = Path.Combine(Application.persistentDataPath, "Tags.txt");

        CreateContentFileIfNotExists();
        CreateObjectValueFileIfNotExists();
        CreateTagsFileIfNotExists();
    }

    private void CreateContentFileIfNotExists()
    {
        if (!File.Exists(contentFilePath))
        {
            string content =
                "1. Ngày mai nhất định sẽ không diễn ra buổi lễ nhảm nhí đó.$\n" +
                "2. Năm 2024, vào 19/11 – chỉ còn 1 ngày nữa cho đến Ngày Nhà Giáo Việt Nam, có 1 cậu học sinh nghịch tên là Long chuyên bày trò phá phách, gây hỗn loạn FPOLY. \n" +
                "Chuẩn bị đến ngày 20/11, cậu nhóc muốn gây ra một trò đùa ác, cậu sẽ lẻn vào Trường để phá hoại hệ thống điện, nhằm ngăn buổi lễ chào mừng Ngày Nhà Giáo Việt Nam diễn ra suôn sẻ. \n" +
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
                "Đừng cố gắng chạy trốn!$\n" +
                "\nCô Khánh Ngọc:\n" +
                "10. Bạn sinh viên kia hãy dừng bước!$\n" +
                "11. Nửa đêm nửa hôm lại đi vào đây, rõ ràng rất khả nghi!$\n" +
                "12. Ơ em chỉ muốn giúp bác bảo vệ đi tuần tra thôi ạ!$\n" +
                "13. Vớ vẩn, tiếp chiêu!$\n" +
                "---------------------------------------\n" +
                "\nCô Hạnh:\n" +
                "14. Ta đã nghe về em!$\n" +
                "15. Lại nữa ư?$\n" +
                "16. Hôm nay ta sẽ trừng trị em.$\n" +
                "17. (Chết tiệt!)$\n" +
                "---------------------------------------\n" +
                "\nThầy Đức Thắng:\n" +
                "18. Tên nhóc kia, đứng lại!$\n" +
                "19. Đây là cửa ải cuối cùng sao?$\n" +
                "20. Bành Trướng Lãnh Địa: Giao Dịch Bất Công!$\n" +
                "21. Chiến đi!$\n" +
                "---------------------------------------\n" +
                "\nThầy Vũ Chí Thành:\n" +
                "22. Tên nhóc nhà cậu cũng khá quá nhỉ?$\n" +
                "23. Thầy Hiệu Trưởng?$\n" +
                "24. Ta đây, ngôi trường của ta có vẻ như đã bị cậu quậy tanh bành rồi nhỉ?$\n" +
                "25. (Đứng trước thầy Hiệu Trưởng, mình gần như không có cơ hội thắng)$\n" +
                "26. Ta sẽ không để cậu tiếp tục bày trò đâu!$\n" +
                "27. Bành Trướng Lãnh Địa: Kỷ Luật Sinh Viên!$\n" +
                "__________________________________\n" +
                "\n28. Tờ báo nói về ngày thành lập trường ư? Nó đã ở đây từ thời nào rồi cơ chứ?$\n" +
                "29. Mình từng nghe nói bảo vệ đã đặt mật mã cho cánh cửa này hơn 5 số, sao lại dài thế chứ?$\n" +
                "30. Quả nhiên ngay cả CanTeen cũng bị khóa!$\n" +
                "31. Có vẻ đây chính là tủ điện chính rồi!$\n" +
                "32. Mình sẽ cần một thứ gì đó có khả năng phá hủy mạnh mẽ.$\n" +
                "33. Quả bom có vẻ còn cần một bộ điều khiển để kích hoạt.$\n" +
                "34. Hình như cánh cửa này không khóa?$\n" +
                "35. Hình như trên bảng có vài chỗ trống cần điền?$\n" +
                "36. Trên đây có vết son?$\n" +
                "37. Có lẽ là manh mối nào đó.$\n" +
                "38. Số lượng sinh viên...40.000?$\n" +
                "39. Nó có phải một manh mối không nhỉ?$\n" +
                "40. Huy hiệu ư?$\n" +
                "41. Có lẽ mình cần gắn nó vào đâu đó.$\n" +
                "42. Những hình tròn này trông thật quen mắt.$\n" +
                "43. Là để gắn thứ gì đó vô hay sao?$\n" +
                "44. Không được làm thế!$\n" +
                "45. Trò định tự sát luôn hay sao!?$\n" +
                "46. Xin lỗi thầy.$\n" +
                "47. Đây là một ngôi trường tuyệt vời...$\n" +
                "48. Nhưng...$\n" +
                "49. Em tuyệt vời hơn!$\n" +
                "50. Nghệ thuật là sự bùng nổ!$\n";


            File.WriteAllText(contentFilePath, content);
        }
    }

    private void CreateObjectValueFileIfNotExists()
    {
        if (!File.Exists(objectValueFilePath))
        {
            string objectValues =
                "PlayerHealth=100;\n" +
                "PlayerMana=10;\n" +
                "PlayerUltimate=6;\n" +
                "PlayerAttack=15;\n" +
                "PlayerHeal=5;\n" +
                "PlayerShield=20;\n" +
                "BossHealth=100;\n" +
                "BossMana=10;\n" +
                "BossAttack=15;\n" +
                "BossHeal=5;\n" +
                "BossShield=20;";

            File.WriteAllText(objectValueFilePath, objectValues);
        }
    }

    private void CreateTagsFileIfNotExists()
    {
        if (!File.Exists(tagsFilePath))
        {
            string tags =
                "Untagged\n" +
                "Respawn\n" +
                "Finish\n" +
                "EditorOnly\n" +
                "MainCamera\n" +
                "Player\n" +
                "GameController\n" +
                "Attack\n" +
                "Heal\n" +
                "Shield\n" +
                "Ultimate\n" +
                "BossAn\n" +
                "Ultimate Dame\n" +
                "BloodScreen\n" +
                "Ultimate_Boss\n" +
                "Boss_Attack\n" +
                "Key_CanTeen\n" +
                "GameManager\n" +
                "Save1\n" +
                "ExScene\n" +
                "Key_LHall\n" +
                "LiftCard\n" +
                "HuyHieu_CNTT\n" +
                "HuyHieu_BMTA\n" +
                "Empty_1\n" +
                "Empty_2\n" +
                "Son_Pass\n" +
                "HuyHieu_TKDH\n" +
                "Remote\n" +
                "BOMB\n" +
                "HuyHieu_TMDT\n" +
                "HuyHieu_HieuTruong\n" +
                "Ultimate_DucThang\n" +
                "Ultimate_HieuTruong";

            File.WriteAllText(tagsFilePath, tags);
        }
    }
}
