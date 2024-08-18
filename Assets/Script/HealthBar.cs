using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;


public class HealthBar : MonoBehaviour
{
    // Số lượng máu của nhân vật, ban đầu là 5.
    public int health = 5;
    public int maxHealth = 5; // Số lượng máu tối đa của nhân vật.
    // Mảng chứa các Image đại diện cho các trái tim trên UI.
    public Image[] hearts;
    // Sprite của trái tim đầy.
    public Sprite fullHeart;
    // Sprite của trái tim rỗng.
    public Sprite emptyHeart;

    public GameObject gameOverCanvas; // Tham chiếu đến Canvas "Game Over".


    public AudioSource audioSource; 
    public AudioClip gameOverSound;
    public AudioClip getHurt;

    private void Start()
    {
        gameOverCanvas.SetActive(false);
        // Cập nhật trạng thái các trái tim khi trò chơi bắt đầu.
        UpdateHearts();
    }

    // Hàm cập nhật các sprite của các trái tim dựa trên giá trị health hiện tại.
    private void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            // Nếu chỉ số của Image nhỏ hơn giá trị health hiện tại, đặt sprite là fullHeart.
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            // Ngược lại, đặt sprite là emptyHeart.
            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }

    // Hàm giảm số lượng máu của nhân vật khi nhận sát thương.
    public void TakeDamage(int damage)
    {
        audioSource.PlayOneShot(getHurt);
        health -= damage; // Giảm giá trị health bởi giá trị damage.
        // Đảm bảo rằng health không nhỏ hơn 0.
        if (health < 0)
        {
            health = 0;
        }
        // Cập nhật trạng thái các trái tim sau khi nhận sát thương.
        UpdateHearts();

        // Kiểm tra nếu health là 0, dừng trò chơi.
        if (health == 0)
        {
            audioSource.PlayOneShot(gameOverSound);
            GameOver();
        }
    }
    // Hàm tăng số lượng máu của nhân vật khi nhận máu.
    public void Heal(int healAmount)
    {
        health += healAmount; // Tăng giá trị health bởi giá trị healAmount.
        // Đảm bảo rằng health không lớn hơn maxHealth.
        if (health > maxHealth)
        {
            health = maxHealth;
        }
        // Cập nhật trạng thái các trái tim sau khi hồi máu.
        UpdateHearts();
    }


    // Hàm xử lý va chạm với các đối tượng khác.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Kiểm tra nếu va chạm với đối tượng có tag "Enemy" hoặc trap
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Trap"))
        {
            // Gọi hàm TakeDamage với giá trị damage là 1.
            TakeDamage(1);
        }
        // Kiểm tra nếu va chạm với "Bossbullet", phá hủy "Bossbullet"
        if (collision.gameObject.CompareTag("Bossbullet"))
        {
            TakeDamage(1);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("heart"))
        {
            // Gọi hàm Heal với giá trị healAmount là 1.
            Heal(1);
            // Phá hủy đối tượng "Heart" sau khi va chạm.
            Destroy(collision.gameObject);
        }


    }

    // Hàm dừng trò chơi khi health là 0.
    private void GameOver()
    {
        // Hiển thị Canvas "Game Over".
        gameOverCanvas.SetActive(true);
        // Dừng tất cả các hoạt động trong trò chơi.
        Time.timeScale = 0;
        Debug.Log("Game Over");
    }
}
