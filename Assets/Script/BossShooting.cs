using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShooting : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab của đạn
    public Transform firePoint1;    // Vị trí bắn đạn 1
    public Transform firePoint2;    // Vị trí bắn đạn 2
    public float fireRate = 1f;     // Tốc độ bắn (số lần bắn mỗi giây)

    private float nextFireTime = 0f; // Thời gian để bắn tiếp theo

    void Update()
    {
        // Kiểm tra nếu đến thời gian bắn tiếp theo
        if (Time.time > nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    // Hàm bắn đạn
    private void Shoot()
    {
        // Chọn ngẫu nhiên một trong hai điểm spawn
        Transform chosenFirePoint = (Random.value > 0.5f) ? firePoint1 : firePoint2;

        // Tạo đạn tại điểm spawn được chọn
        Instantiate(bulletPrefab, chosenFirePoint.position, chosenFirePoint.rotation);
    }
}