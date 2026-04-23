using UnityEngine;

public class ProducerPanelSwitcher : MonoBehaviour
{
    [Header("UI引用")]
    public GameObject mainMenuCanvas;  
    public GameObject producerPanel;   


    public void ShowProducerPage()
    {
        mainMenuCanvas.SetActive(false);
        producerPanel.SetActive(true);
    }
    public void BackToMainMenu()
    {
        producerPanel.SetActive(false);
        mainMenuCanvas.SetActive(true);
    }
}