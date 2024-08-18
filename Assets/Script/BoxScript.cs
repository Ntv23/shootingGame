using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxScript : MonoBehaviour
{
    public float speed = 2f; // Tốc độ di chuyển
    public float leftBound = -3f; // Giới hạn bên trái
    public float rightBound = 5f; // Giới hạn bên phải

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
            }
        }
        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            // Nếu đối tượng vượt qua giới hạn bên trái, đổi hướng
            if (transform.position.x < leftBound)
            {
                movingRight = true;
            }
        }
    }
}
