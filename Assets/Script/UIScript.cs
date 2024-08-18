using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public GameObject pauseMenuCanvas; // Canvas tạm dừng trò chơi.
    public GameObject winUICanvas; // Canvas chiến thắng
    public TextMeshProUGUI timeText; // Text để hiển thị thời gian
    //public TextMeshProUGUI finalTimeText; // Text để hiển thị thời gian cuối cùng trên UI chiến thắng

    private float gameTime; // Biến để lưu thời gian chơi
    private bool isGameOver = false; // Biến để kiểm tra xem game đã kết thúc chưa
    private bool isPaused = false; // Biến để kiểm tra xem trò chơi có đang ở trạng thái tạm dừng hay không

    void Start()
    {
        // Đảm bảo Canvas tạm dừng và Win UI bị ẩn khi bắt đầu trò chơi.
        pauseMenuCanvas.SetActive(false);
        winUICanvas.SetActive(false);

        gameTime = 0f; // Khởi tạo thời gian chơi ban đầu là 0
        UpdateTimeText(); // Cập nhật hiển thị thời gian ban đầu
    }

    void Update()
    {
        // Kiểm tra nếu người chơi nhấn phím Esc để tạm dừng hoặc tiếp tục trò chơi.
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }

        if (!isGameOver)
        {
            gameTime += Time.deltaTime; // Cập nhật thời gian chơi mỗi frame
            UpdateTimeText(); // Cập nhật hiển thị thời gian
        }
    }

    void UpdateTimeText()
    {
        int minutes = Mathf.FloorToInt(gameTime / 60f); // Tính số phút
        int seconds = Mathf.FloorToInt(gameTime % 60f); // Tính số giây
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds); // Định dạng chuỗi hiển thị giờ phút
    }

    public void EndGame()
    {
        isGameOver = true; // Đánh dấu game đã kết thúc
        Time.timeScale = 0; // Ngừng thời gian
        winUICanvas.SetActive(true); // Hiển thị Win UI
    }
    
    public void PauseGame()
    {
        pauseMenuCanvas.SetActive(true); // Hiển thị Canvas tạm dừng.
        Time.timeScale = 0; // Dừng tất cả các hoạt động trong trò chơi.
        isPaused = true; // Đặt trạng thái là tạm dừng.
    }

    public void ResumeGame()
    {
        pauseMenuCanvas.SetActive(false); // Ẩn Canvas tạm dừng.
        Time.timeScale = 1; // Tiếp tục tất cả các hoạt động trong trò chơi.
        isPaused = false; // Đặt trạng thái là không tạm dừng.
    }

    public void RestartGame()
    {
        Time.timeScale = 1; // Đặt lại Time.timeScale để trò chơi tiếp tục chạy bình thường
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Tải lại cảnh hiện tại
    }

    public void GoToHomeScene()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit Game");
    }
}