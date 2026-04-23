using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RaceCore : MonoBehaviour
{
    [Header("比赛设置")]
    public float maxRaceTime = 600f;

    [Header("UI面板引用")]
    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject startPanel;

    [Header("车辆初始位置")]
    public Vector3 startPosition;
    public Quaternion startRotation;

    private float _currentTime;
    private bool _isRaceOver = false;
    private Rigidbody _carRigidbody;

    void Start()
    {
        _carRigidbody = GetComponent<Rigidbody>();
        _currentTime = maxRaceTime;
        _isRaceOver = false;
        
        // 记录车辆初始位置和旋转
        startPosition = transform.position;
        startRotation = transform.rotation;

        // 初始状态：显示开始面板，暂停游戏
        startPanel.SetActive(true);
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        Time.timeScale = 0;
    }

    // 开始比赛（由StartButton调用）
    public void StartRace()
    {
        startPanel.SetActive(false);
        Time.timeScale = 1;
        _isRaceOver = false;
        _currentTime = maxRaceTime;

        // 恢复车辆物理
        if (_carRigidbody != null)
        {
            _carRigidbody.isKinematic = false;
            _carRigidbody.velocity = Vector3.zero;
            _carRigidbody.angularVelocity = Vector3.zero;
        }
    }

    void Update()
    {
        if (_isRaceOver || Time.timeScale == 0) return;
        _currentTime -= Time.deltaTime;
        if (_currentTime <= 0) OnRaceLose();
    }

    void OnTriggerEnter(Collider other)
    {
        if (_isRaceOver || Time.timeScale == 0) return;
        if (other.CompareTag("FinishLine")) OnRaceWin();
    }

    void OnRaceWin()
    {
        _isRaceOver = true;
        Time.timeScale = 0;
        winPanel.SetActive(true);
        losePanel.SetActive(false);
        FreezeCar();
    }

    void OnRaceLose()
    {
        _isRaceOver = true;
        Time.timeScale = 0;
        losePanel.SetActive(true);
        winPanel.SetActive(false);
        FreezeCar();
    }

    // 冻结车辆（比赛结束时）
    void FreezeCar()
    {
        if (_carRigidbody != null)
        {
            _carRigidbody.velocity = Vector3.zero;
            _carRigidbody.angularVelocity = Vector3.zero;
            _carRigidbody.isKinematic = true;
        }
    }

    // 回到初始状态（由RestartButton调用）
    public void BackToStart()
    {
        // 重置UI
        winPanel.SetActive(false);
        losePanel.SetActive(false);
        startPanel.SetActive(true);

        // 重置比赛状态
        _isRaceOver = false;
        _currentTime = maxRaceTime;
        Time.timeScale = 0;

        // 重置车辆位置和物理
        transform.position = startPosition;
        transform.rotation = startRotation;
        if (_carRigidbody != null)
        {
            _carRigidbody.isKinematic = false;
            _carRigidbody.velocity = Vector3.zero;
            _carRigidbody.angularVelocity = Vector3.zero;
        }
    }
}