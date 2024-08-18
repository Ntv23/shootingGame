using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinningFlag : MonoBehaviour
{
    public GameObject winUICanvas; // Canvas chứa UI chiến thắng

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player touched the flag!"); // Log xác nhận va chạm với lá cờ
            Time.timeScale = 0; // Ngừng thời gian
            winUICanvas.SetActive(true); // Kích hoạt Win UI
        }
    }
}
