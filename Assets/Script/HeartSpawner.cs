using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSpawner : MonoBehaviour
{
    public GameObject heartPrefab; // Prefab bạn muốn spawn
    public Transform[] spawnPoints; // Các điểm cố định để spawn
    public float spawnInterval = 6f; // Khoảng thời gian giữa các lần spawn

    private void Start()
    {
        // Gọi phương thức SpawnPrefab mỗi 6 giây
        InvokeRepeating("SpawnPrefab", spawnInterval, spawnInterval);
    }

    void SpawnPrefab()
    {
        // Chọn ngẫu nhiên một trong các điểm spawn
        int randomIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[randomIndex];

        // Tạo một instance của prefab tại vị trí spawnPoint đã chọn
        Instantiate(heartPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
