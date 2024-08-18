using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float lifeTime = 5f; // Thời gian tồn tại của viên đạn

    // Start is called before the first frame update
    void Awake()
    {
        // Hủy viên đạn sau một khoảng thời gian để tránh việc tồn tại vĩnh viễn
        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Hủy viên đạn khi va chạm với bất kỳ đối tượng nào
        Destroy(gameObject);
    }


}
