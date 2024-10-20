using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{
    public GameObject hide;  // GameObject mà bạn muốn ẩn/hiện
    public Text pass;        // Text mà bạn kiểm tra giá trị null
    private Coroutine blinkCoroutine;  // Giữ tham chiếu tới Coroutine

    void Start()
    {
        // Bắt đầu Coroutine nếu text ban đầu là rỗng
        if (pass.text == "")
        {
            blinkCoroutine = StartCoroutine(Blinku());
        }
    }

    void Update()
    {
        if (pass.text != "" && blinkCoroutine != null)
        {
            // Dừng Coroutine nếu pass.text không rỗng
            StopCoroutine(blinkCoroutine);
            blinkCoroutine = null;  // Đặt lại tham chiếu về null
            hide.SetActive(true);   // Đảm bảo rằng GameObject hiển thị
        }
        else if (pass.text == "" && blinkCoroutine == null)
        {
            // Bắt đầu lại Coroutine nếu pass.text rỗng và chưa có Coroutine nào chạy
            blinkCoroutine = StartCoroutine(Blinku());
        }
    }

    IEnumerator Blinku()
    {
        while (pass.text == "")
        {
            hide.SetActive(false);  // Ẩn đối tượng
            yield return new WaitForSeconds(1f);  // Chờ 1 giây
            hide.SetActive(true);   // Hiện đối tượng
            yield return new WaitForSeconds(1f);  // Chờ thêm 1 giây
        }
    }
}
