using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class KillCountManager : MonoBehaviour
{
    public Text killCountText;
    public int killCount;

    public int firstKillsCount;
    public int secondKillsCount;
    public int thirdKillsCount;
    public int fourthKillsCount;

    public static KillCountManager Instance { get; private set; }

    [SerializeField] GameObject timer;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] public float remainingTime;
    [SerializeField] GameObject gameOver;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        gameOver.SetActive(false);
        timer.SetActive(false);
        killCountText.text = "Kills: 0";

        StartCoroutine(CountDown());
    }

    private void Update()
    {
        
        Win();


        if (remainingTime >= 15)
        {
            firstKillsCount = killCount;
        }

        if (remainingTime >= 10)
        {
            secondKillsCount = killCount;
        }

        if (remainingTime >= 5)
        {
            thirdKillsCount = killCount;
        }

        if (remainingTime >= 0)
        {
            fourthKillsCount = killCount;
        }

    }

    public void IncrementKillCount()
    {
        killCount++;
        killCountText.text = "Kills: " + killCount;
    }

    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(17f);

        timer.SetActive(true);
        while (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;

            int minutes = Mathf.FloorToInt(remainingTime / 60);
            int seconds = Mathf.FloorToInt(remainingTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            yield return null; // Waits for the next frame
        }

        remainingTime = 0;
        timerText.text = "00:00";
    }

    void Win()
    {
        if(remainingTime < 0)
        {
            Debug.Log("Completed");
            timer.SetActive(false);
            SceneManager.LoadScene("Win");
        }
        /*else if(remainingTime < 0 && killCount < 2)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Debug.Log("Failed");
            gameOver.SetActive(true);
            timer.SetActive(false);
            
        }*/
    }
}
