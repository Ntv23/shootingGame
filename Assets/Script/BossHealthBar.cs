using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealthBar : MonoBehaviour
{
    private float maxHealth = 100;
    private float currentHealth;
    public Image healthBarFill;
    private float damageAmount = 10f; // mỗi lần thay đổi 10
    public GameObject Boss;
    public GameObject flag;

    private void Awake()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    private void Start()
    {
        flag.SetActive(false); // Ẩn lá cờ ban đầu
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("bullet"))
        {
            Debug.Log("Boss hit !"); // Kiểm tra xem va chạm có xảy ra không
            TakeDamage(damageAmount);
            Destroy(collision.gameObject); // Hủy đạn sau khi va chạm
        }
    }

    private void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Giới hạn giá trị máu để không âm
        Debug.Log("Boss Current Health: " + currentHealth); // Kiểm tra giá trị máu hiện tại
        if (currentHealth <= 0)
        {
            Destroy(Boss); // Phá hủy đối tượng Boss nếu máu <= 0
            // Hiển thị và bắt đầu di chuyển lá cờ từ vị trí ban đầu
            flag.SetActive(true);
        }
        UpdateHealthBar(); // Cập nhật thanh máu
    }

    private void UpdateHealthBar()
    {
        healthBarFill.fillAmount = currentHealth / maxHealth; // Cập nhật lượng máu trên thanh dựa trên máu hiện tại
    }

}
