using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    [Header("UI引用")]
    public GameObject mainMenuCanvas;
    public GameObject producerPanel;

    // 游戏启动时自动执行
    void Start()
    {
        // 让ProducerPanel默认隐藏
        if (producerPanel != null)
        {
            producerPanel.SetActive(false);
        }
    }

    // 点击Producer按钮：显示介绍页，隐藏主菜单
    public void ShowProducerPanel()
    {
        if (mainMenuCanvas != null)
            mainMenuCanvas.SetActive(false);
        
        if (producerPanel != null)
            producerPanel.SetActive(true);
    }

    // 点击Back按钮：显示主菜单，隐藏介绍页
    public void BackToMainMenu()
    {
        if (producerPanel != null)
            producerPanel.SetActive(false);
        
        if (mainMenuCanvas != null)
            mainMenuCanvas.SetActive(true);
    }
}