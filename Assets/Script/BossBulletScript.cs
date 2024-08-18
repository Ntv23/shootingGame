using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletScript : MonoBehaviour
{
    public float speed = 10f; // Tốc độ của đạn

    void Update()
    {
        // Di chuyển đạn theo hướng X
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    
}