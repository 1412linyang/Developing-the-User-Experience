using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameFinish : MonoBehaviour
{
    [Header("跳转场景名称")]
    public string targetScene;
    [Header("延迟秒数")]
    public float waitTime = 3f;

    private List<GameObject> coinList = new List<GameObject>();
    private bool isFinished = false;

    void Start()
    {
        // 自动找到场景里所有金币
        GameObject[] allCoins = GameObject.FindGameObjectsWithTag("Coin");
        coinList.AddRange(allCoins);
    }

    // 每帧检测：金币是不是全都没了
    void Update()
    {
        if (isFinished) return;

        // 判断列表里所有金币 是否 不存在（被销毁）
        bool allClear = true;
        foreach (var coin in coinList)
        {
            if (coin != null)
            {
                allClear = false;
                break;
            }
        }

        // 全部收集完毕
        if (allClear)
        {
            isFinished = true;
            Invoke(nameof(ChangeScene), waitTime);
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(targetScene);
    }
}