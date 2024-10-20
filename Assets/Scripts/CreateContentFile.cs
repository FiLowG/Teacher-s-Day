using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CreateContentFile : MonoBehaviour
{
    private string contentFilePath;
    private string objectValueFilePath;

    void Start()
    {
        contentFilePath = Path.Combine(Application.persistentDataPath, "Content_Teacher_sDay.txt");
        objectValueFilePath = Path.Combine(Application.persistentDataPath, "ObjectValue.txt");

        CreateContentFileIfNotExists();
        CreateObjectValueFileIfNotExists();
    }

    private void CreateContentFileIfNotExists()
    {
        if (!File.Exists(contentFilePath))
        {
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
                "PlayerUltimate=0.06;\n" +
                "PlayerAttack=15;\n" +
                "PlayerHeal=0.05;\n" +
                "PlayerShield=10;\n" +
                "BossHealth=100;\n" +
                "BossMana=10;\n" +
                "BossAttack=15;\n" +
                "BossHeal=0.05;\n" +
                "BossShield=15;";

            File.WriteAllText(objectValueFilePath, objectValues);
        }
    }
}
