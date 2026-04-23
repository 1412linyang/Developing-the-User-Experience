using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [Header("设置")]
    public string gameSceneName = "level1";
    public void LoadGameScene()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void OpenSettings()
    {
        Debug.Log("打开设置面板");
        // 后续可以在这里扩展设置UI的逻辑
    }
    public void OpenGameIntro()
    {
        Debug.Log("打开游戏介绍");
    }
    public void OpenAbout()
    {
        Debug.Log("打开团队介绍");
    }
}