using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;
public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;
    public Slider hungerBar;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI pointsText;
    public CanvasGroup topPanel;
    public CanvasGroup pointsPanel;
    public CanvasGroup gameOverPanel;
    public bool gameOver = false;
    public Transform player;
    int points;
    public float gameTimer;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Update()
    {
        gameTimer += 1* Time.deltaTime;
        timeText.text = gameTimer.ToString("00");

    }

    void Start()
    {
        InitCanvas();
    }
    void InitCanvas()
    {
        hungerBar.value = hungerBar.maxValue;
        pointsPanel.alpha = 0;
        pointsPanel.DOFade(1, .25f);
        pointsPanel.transform.DOLocalMoveY(400, .25f);
    }
public void Hunger(float amt)
    {
        hungerBar.DOValue(hungerBar.value += amt,.25f);
        if(hungerBar.value<=0)
        {
            GameOver();
        }
    }
public void GameOver()
{
        if(!gameOver)
        {
            gameOver = true;
            gameOverPanel.DOFade(1, 1).OnComplete(() => { 
            Destroy(player.gameObject);
            });
        }
}
    public void GameWon()
    {
        if (!gameOver)
        {
            gameOver = true;
            gameOverPanel.GetComponentInChildren<TextMeshProUGUI>().text = "You Win! With a Time of " + gameTimer.ToString("00") + " Seconds";
            gameOverPanel.DOFade(1, 1).OnComplete(() => {
                Destroy(player.gameObject);
            });
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Destroy(this.gameObject);
    }
    public void AddPoints(int amt)
    {
        points += amt;
        if(points >5000)
        {
            GameWon();
        }
        pointsText.text = points.ToString("000");
    }
}