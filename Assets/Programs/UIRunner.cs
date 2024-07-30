using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UIRunner : MonoBehaviour
{
    private float timer;
    private int score;
    [SerializeField] private int goal;
    public TextMeshProUGUI goalText;

    private bool gameOn;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;
    public TestMeshProUGUI countDownText;

    public GameObject startBoard;
    public GameObject looseBoard;
    public TextMeshProUGUI yourScore;
    public GameObject winBoard;
    public TextMeshProUGUI bestRecord;
    
    public float countDown;

    [SerializeField] private int highestScore;
    public TextMeshProUGUI highestText;

    private bool timeUp;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text =  score.ToString();
        gameOn = true; //change this to false inorder to use game start board
        goalText.text = goal.ToString();
        highestText.text = highestScore.ToString();
        countDown = 3.0f;
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
        if(countDown <= 0){
            if(timeUp == false){
                timer -= Time.deltaTime;
                timerText.text = "0" + timer.ToString("F2");
                if(timer <= 0){
                    timeUp = true;
                    timerText.text = "00:00";
                    StartCoroutine(Boards());
                }
            }
            countDown = 0;
        }
    }

    public void GameOn()
    {
        gameOn = true;
        startBoard.SetActive(false);
        timer = 5.0f;
        countDown = 3.0f;
    }
    public void PlayAgain(){
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    IEnumerator Boards(){
        Scores();
        yield return new WaitForSeconds(1.0f); //creates delays for 1 second
        if(score >= goal){
            winBoard.SetActive(true);
            bestRecord.text = score.ToString();

        }else{
            looseBoard.SetActive(true);
            yourScore.text = score.ToString();
        }
    }
    public void GenerateGoal(){
        PlayerPrefs.SetInt("Highest", highestScore);
        goal = highestScore;
        goal++;
        winBoard.SetActive(false);
        looseBoard.SetActive(false);
        goalText.text = goal.ToString();
        timer = 5.0f;
        score = 0;
        timeUp = false;
        countDown = 3.0f;
    }

    private void Scores()
    {
        if(score > PlayerPrefs.GetInt("Highest"))
        {
            highestScore = score;
        }
        else
        {
            highestScore = PlayerPrefs.GetInt("Highest");
        }

       //highestScoreText.text = highestScore.ToString();
    }
}
