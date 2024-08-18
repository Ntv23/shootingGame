using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{

    public Transform player;        // Vị trí của player
    public float moveSpeed = 2f;    // Tốc độ di chuyển của boss
    public float attackRange = 2f;  // Khoảng cách tấn công
    public Renderer playerRenderer; // Renderer của player

    private Rigidbody2D rb;         // Rigidbody2D của boss để điều khiển vật lý
    private Vector2 movement;       // Vector2 để lưu trữ hướng di chuyển


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Kiểm tra nếu cả player và boss đều nằm trong khung hình của camera
        if (IsInCameraView(player) && IsInCameraView(transform))
        {
            // Tính toán khoảng cách đến player
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);

            if (distanceToPlayer > attackRange)
            {
                // Di chuyển về phía player nếu ngoài phạm vi tấn công
                Vector2 direction = (player.position - transform.position).normalized;
                movement = new Vector2(direction.x, 0) * moveSpeed;

            }
            else
            {
                // Dừng di chuyển và chuyển sang trạng thái tấn công nếu trong phạm vi tấn công
                movement = Vector2.zero;

            }

            // Xoay boss dựa trên hướng di chuyển
            if (player.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1); // Hướng về phía phải
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1); // Hướng về phía trái
            }
        }
        else
        {
            // Dừng di chuyển khi player không nằm trong khung hình
            movement = Vector2.zero;
        }
    }

    void FixedUpdate()
    {
        // Áp dụng di chuyển cho boss
        if (movement != Vector2.zero)
        {
            rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
        }
    }

    // Hàm kiểm tra nếu đối tượng nằm trong khung hình của camera
    private bool IsInCameraView(Transform target)
    {
        Vector3 viewportPoint = Camera.main.WorldToViewportPoint(target.position);
        return viewportPoint.x >= 0 && viewportPoint.x <= 1 && viewportPoint.y >= 0 && viewportPoint.y <= 1;
    }
}