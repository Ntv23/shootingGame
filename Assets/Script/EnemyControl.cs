using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public float speed = 1f; // Tốc độ di chuyển
    public float leftBound = 5f; // Giới hạn bên trái
    public float rightBound = 12f; // Giới hạn bên phải

    private bool movingRight = true; // Hướng di chuyển ban đầu

    void Update()
    {
        // Di chuyển đối tượng theo trục X
        if (movingRight)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            // Nếu đối tượng vượt qua giới hạn bên phải, đổi hướng
            if (transform.position.x > rightBound)
            {
                movingRight = false;
                transform.localScale = new Vector3(3, 3, 1); // Hướng về phía phải
            }
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            // Nếu đối tượng vượt qua giới hạn bên trái, đổi hướng
            if (transform.position.x < leftBound)
            {
                movingRight = true;
                transform.localScale = new Vector3(-3, 3, 1); // Hướng về phía trái
            }
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
