
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
   [SerializeField] private GameObject GameOverPanel;
   [SerializeField] private Text timerText;
    private int LevelCount = GameManager.LevelCount;
    private float startTime;
    [SerializeField] private float time = 120;

    void Start()
    {
        startTime = Time.time;
        if(LevelCount>=4) time=150;
        
    }
    void Update()
    {
        GameTimer();
    }

    private void GameTimer()
    {
        string seconds = "";
        if (time > 0)
        {
            time -= Time.deltaTime;
            seconds = time.ToString("f0");
        }
        else
        {
            seconds = time.ToString("f0");
            seconds = "x";
            GameOverPanel.SetActive(true);
        }

        timerText.text = seconds;
    }
}

