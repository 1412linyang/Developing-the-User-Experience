using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameStarUI : MonoBehaviour
{
    [Header("UI引用")]
    public GameObject startPanel;
    public Button startButton;
    public TextMeshProUGUI startButtonText;

    void Start()
    {
        // 初始化显示开始面板，暂停游戏
        startPanel.SetActive(true);
        startButton.onClick.AddListener(OnStartGameClicked);
        Time.timeScale = 0; // 暂停赛车物理
    }

    // 开始游戏按钮点击事件
    public void OnStartGameClicked()
    {
        // 隐藏开始面板
        startPanel.SetActive(false);
        // 恢复游戏时间
        Time.timeScale = 1;
    }
}