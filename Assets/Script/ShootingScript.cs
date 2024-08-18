using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootingScript : MonoBehaviour
{

    public Transform firePoint; // Điểm bắn
    public GameObject bulletPrefab; // Prefab của viên đạn
    public float bulletForce = 20f; // Lực bắn của viên đạn

    public AudioSource audioSource; // Tham chiếu đến AudioSource
    public AudioClip shootSound; // Âm thanh bắn


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Kiểm tra nếu nút chuột trái được nhấn
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Tạo một viên đạn mới tại vị trí của FirePoint với góc quay của FirePoint
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        // Lấy Rigidbody2D của viên đạn
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        // Kiểm tra hướng hiện tại của transform BulletSpawnPoint
        if (transform.localScale.x < 0) // Nếu SpawnPoint đang hướng về phía trái
        {
            // Xoay viên đạn ngược lại khi bắn ra
            bullet.transform.localScale = new Vector3(-3, 1, 1);
            rb.AddForce(-firePoint.right * bulletForce, ForceMode2D.Impulse); // Bắn trái
        }
        else
        {
            rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse); // Bắn phải
        }

        audioSource.PlayOneShot(shootSound);
    }
}
