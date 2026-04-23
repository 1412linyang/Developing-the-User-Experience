using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelRestart : MonoBehaviour
{
    [Header("设置")]
    public GameObject losePanel;


    public void RestartLevel()
    {
       
        if (losePanel != null)
        {
            losePanel.SetActive(false);
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}