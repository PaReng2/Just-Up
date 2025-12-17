using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject GameOverPanel;
    public Button reTryButton;

    private void Start()
    {
        // 1. 초기 상태 설정
        if (GameOverPanel != null)
            GameOverPanel.SetActive(false);

        // 2. 버튼 리스너 연결
        if (reTryButton != null)
            reTryButton.onClick.AddListener(ReStartGame);
    }

    // 게임 오버 창을 띄우는 함수 (외부에서 호출 가능)
    public void ShowGameOver()
    {
        if (GameOverPanel != null)
        {
            GameOverPanel.SetActive(true);
            Time.timeScale = 0f; // 시간 정지
        }
    }

    // 재시작 로직
    public void ReStartGame()
    {
        Time.timeScale = 1f; // 시간 초기화

        // 현재 활성화된 씬을 다시 로드
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}