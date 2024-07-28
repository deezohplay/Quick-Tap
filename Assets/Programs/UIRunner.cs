using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIRunner : MonoBehaviour
{
    public float timer;
    [SerializeField] private int score;

    private bool gameOn;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;

    public GameObject startBoard;

    private bool timeUp;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text =  score.ToString();
        gameOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOn == true){
            Timer();
        }
    }

    public void TapTap()
    {
        if(!timeUp)
        {
            score++;
            scoreText.text = score.ToString();
        }
    }

    private void Timer()
    {
        if(timeUp == false){
            timer -= Time.deltaTime;
            timerText.text = "0" + timer.ToString("F2");
            if(timer <= 0){
                timeUp = true;
                timerText.text = "00:00";
            }
        }
    }

    public void GameOn()
    {
        gameOn = true;
        startBoard.SetActive(false);
    }
}
