using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [Header("音频设置")]
    public AudioClip backgroundMusic;
    public Button musicToggleBtn;

    [Header("按钮图标设置")]
    public Sprite musicOnSprite; 
    public Sprite musicOffSprite; 

    private AudioSource audioSource;
    private bool isMusicOn = true;

    void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = backgroundMusic;
        audioSource.loop = true;
        audioSource.playOnAwake = true;
        audioSource.volume = 0.5f;
        audioSource.Play();

        if (musicToggleBtn != null)
        {
            musicToggleBtn.onClick.AddListener(ToggleMusic);
           
            UpdateButtonSprite();
        }
    } 
    public void ToggleMusic()
    {
        isMusicOn = !isMusicOn;
        audioSource.volume = isMusicOn ? 0.5f : 0f;
    
        UpdateButtonSprite();
    }


    private void UpdateButtonSprite()
    {
        if (musicToggleBtn == null || musicOnSprite == null || musicOffSprite == null)
            return;

        Image btnImage = musicToggleBtn.GetComponent<Image>();
        if (btnImage != null)
        {
            btnImage.sprite = isMusicOn ? musicOnSprite : musicOffSprite;
        }
    }
}