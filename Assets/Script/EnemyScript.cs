using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Rigidbody2D enemy;
    public float speed = 5f;
    public Transform pointA;
    public Transform pointB;
    private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        // Đặt vị trí ban đầu của kẻ thù là pointA
        targetPosition = pointB.position;
    }

    // Update is called once per frame
    void Update()
    {

        // Di chuyển kẻ thù về phía targetPosition
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // Nếu kẻ thù đến targetPosition, đổi targetPosition
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            targetPosition = targetPosition == pointA.position ? pointB.position : pointA.position;
        }

        // Xoay kẻ thù dựa trên hướng di chuyển
        if (targetPosition == pointB.position)
        {
            transform.localScale = new Vector3(1, 1, 1); // Hướng về phía phải
        }
        else
        {
            transform.localScale = new Vector3(-1, 1, 1); // Hướng về phía trái
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Kiểm tra nếu va chạm với đối tượng có tag là "Bullet"
        if (collision.gameObject.CompareTag("bullet"))
        {
            // Hủy game object khi bị bắn trúng
            Destroy(gameObject);

        }
    }

}
