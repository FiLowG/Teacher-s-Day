using System.Collections;
using UnityEngine;

public class Unscale_Time_Notice : MonoBehaviour
{
    public GameObject NoticePanel;  // Bảng thông báo
    public GameObject GuideEffects; // Hiệu ứng đi kèm (nếu có)

    // Để kiểm tra xem Notice có đang mở không
    private bool isNoticeActive = false;

    void Start()
    {
        // Khởi tạo, ẩn bảng Notice khi bắt đầu game (nếu cần)
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
        // Khi người chơi bấm phím để hiển thị Notice (hoặc có thể là một sự kiện khác)
        if (Input.GetKeyDown(KeyCode.N)) // Phím "N" để mở thông báo
        {
            ToggleNotice();
        }
    }

    // Bật/tắt thông báo và điều chỉnh Time.timeScale
    public void ToggleNotice()
    {
        isNoticeActive = !isNoticeActive;  // Chuyển trạng thái

        if (isNoticeActive)
        {
            // Hiển thị Notice, dừng thời gian
            Time.timeScale = 0;  // Dừng thời gian game
            if (NoticePanel != null)
            {
                NoticePanel.SetActive(true);  // Bật Notice
            }

            if (GuideEffects != null)
            {
                GuideEffects.SetActive(true);  // Bật hiệu ứng nếu có
            }
        }
        else
        {
            // Tắt Notice, tiếp tục thời gian
            Time.timeScale = 1;  // Khôi phục thời gian
            if (NoticePanel != null)
            {
                NoticePanel.SetActive(false);  // Tắt Notice
            }

            if (GuideEffects != null)
            {
                GuideEffects.SetActive(false);  // Tắt hiệu ứng nếu có
            }
        }
    }
}
