using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // ★ 가장 중요한 싱글톤 인스턴스
    public static GameManager Instance;

    [Header("UI Components")]
    public GameObject GameOverPannel;
    public Button reTryButton;

    // 현재 씬 번호를 저장하는 변수 (LoadScene(int) 방식 사용 시)
    // -1로 초기화하여 'LoadScene(string)' 방식을 선호하도록 유도
    private int curSceneBuildIndex = -1;

    // --- 1. 싱글톤 패턴 설정 (Awake) ---
    private void Awake()
    {
        // 1. 인스턴스가 없을 경우, 이 오브젝트를 인스턴스로 지정하고 씬이 바뀌어도 파괴되지 않게 합니다.
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        // 2. 이미 인스턴스가 존재할 경우, 새로 생성된 이 오브젝트(복제본)는 파괴합니다.
        else
        {
            Destroy(gameObject);
        }
    }

    // --- 2. 초기 설정 및 이벤트 리스너 (Start) ---
    private void Start()
    {
        // UI 컴포넌트 유효성 검사
        if (GameOverPannel != null)
        {
            GameOverPannel.SetActive(false);
        }

        // 버튼 클릭 이벤트 리스너 추가
        if (reTryButton != null)
        {
            reTryButton.onClick.AddListener(ReStart);
        }

        // 현재 씬의 빌드 인덱스를 저장합니다.
        // Die()가 호출되기 전에 씬을 전환할 경우를 대비하여 Start에서 업데이트합니다.
        curSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
    }

    // --- 3. 재시작 로직 (ReStart) ---
    void ReStart()
    {
        // 씬 재시작 시, 시간을 다시 흐르게 합니다. (Time.timeScale = 1f;)
        Time.timeScale = 1f;

        // 게임 오버 패널을 비활성화합니다.
        if (GameOverPannel != null)
        {
            GameOverPannel.SetActive(false);
        }

        // 저장된 씬 인덱스를 사용하여 씬을 로드합니다.
        // 현재 씬의 빌드 인덱스가 -1이 아니면 로드합니다.
        if (curSceneBuildIndex != -1)
        {
            SceneManager.LoadScene(curSceneBuildIndex);
        }
        else
        {
            // 안전 장치: 인덱스를 사용하지 못할 경우, 현재 활성화된 씬 이름을 사용해 로드 시도
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    // --- 4. 게임 오버 로직 (Die) ---
    public void Die()
    {
        if (GameOverPannel != null)
        {
            GameOverPannel.SetActive(true);
        }
        // 게임을 일시정지합니다.
        Time.timeScale = 0f;
    }
}