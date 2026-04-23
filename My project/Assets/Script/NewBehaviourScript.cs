using UnityEngine;
using UnityEngine.UI;

public class BackToMainMenu : MonoBehaviour
{
    [Header("UI引用")]
    // 主菜单的 Canvas
    public GameObject mainMenuCanvas;
    // 当前的 ProducerPanel
    public GameObject producerPanel;

    // 按钮点击时调用这个方法
    public void OnBackClicked()
    {
        // 关闭介绍页
        if (producerPanel != null)
        {
            producerPanel.SetActive(false);
        }

        // 显示主菜单
        if (mainMenuCanvas != null)
        {
            mainMenuCanvas.SetActive(true);
        }
    }
}