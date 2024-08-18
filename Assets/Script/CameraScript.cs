using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public Transform target; // Nhân vật mà camera sẽ theo dõi.
    public float smoothing = 5f; // Tốc độ di chuyển của camera.
    public Vector3 offset; // Khoảng cách giữa camera và nhân vật.

    void Start()
    {
        // Thiết lập giá trị offset cố định
        offset = new Vector3(6, 2.5f, -10);

        // Tỷ lệ khung hình mong muốn
        float targetAspect = 16.0f / 9.0f;

        // Tỷ lệ khung hình hiện tại của màn hình
        float windowAspect = (float)Screen.width / (float)Screen.height;

        // Tỷ lệ tỷ lệ khung hình
        float scaleHeight = windowAspect / targetAspect;

        // Lấy Camera component
        Camera camera = GetComponent<Camera>();

        if (scaleHeight < 1.0f)
        {
            // Nếu tỷ lệ hiện tại nhỏ hơn tỷ lệ mong muốn, ta sẽ điều chỉnh chiều cao của viewport
            Rect rect = camera.rect;

            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;

            camera.rect = rect;
        }
        else // Nếu tỷ lệ hiện tại lớn hơn hoặc bằng tỷ lệ mong muốn, ta sẽ điều chỉnh chiều rộng của viewport
        {
            float scaleWidth = 1.0f / scaleHeight;

            Rect rect = camera.rect;

            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;
        }
    }

    void FixedUpdate()
    {
        // Vị trí mong muốn của camera là vị trí của nhân vật cộng với khoảng cách ban đầu.
        Vector3 targetCamPos = target.position + offset;

        // Di chuyển camera từ vị trí hiện tại đến vị trí mong muốn với tốc độ nhất định.
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
