using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Runtime.CompilerServices;

public class UIRunner : MonoBehaviour
{
    [SerializeField] private float timer;
    [SerializeField] private int score;
    private int goal;
    public TextMeshProUGUI goalText;

    private bool gameOn;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI countDownText;

    public GameObject countText;
    public GameObject startBoard;
    public GameObject looseBoard;
    public TextMeshProUGUI yourScore;
    public GameObject winBoard;
    public TextMeshProUGUI bestRecord;

    [SerializeField] private int highestScore;
    public TextMeshProUGUI highestText;
    private bool begin;

    private bool timeUp;
    // Start is called before the first frame update
    private float currCountdownValue;
    public int gamePlayed = 0;
    public static UIRunner Instance { get; private set; }

    public bool isRewarded = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        StartCoroutine(DisplayBanner());
    }

    private IEnumerator DisplayBanner()
    {
        yield return new WaitForSeconds(1f);
        AdsManager.Instance.bannerAds.ShowBannerAd();
    }

    void Start()
    {
        scoreText.text =  score.ToString();
        gameOn = false; //change this to false inorder to use game start board
        goalText.text = goal.ToString();
        highestText.text = highestScore.ToString();
        timer = 5.0f;
        begin = false;
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
        if(!timeUp && begin == true)
        {
            score++;
            scoreText.text = score.ToString();
        }
    }

    private void Timer()
    {
        if(begin == true){
            if(timer > 0){
                if(timeUp == false){
                    timer -= Time.deltaTime;
                    timerText.text = "0" + timer.ToString("F2");
                    if(timer <= 0){
                        timeUp = true;
                        timerText.text = "00:00";
                        StartCoroutine(Boards());
                        begin = false;
                        AdsManager.Instance.bannerAds.HideBannerAd();
                        if (gamePlayed % 3 == 0)
                        {
                            AdsManager.Instance.interstitialAds.ShowInterstitialAd();
                        }
                    }
                }
            }
        }
    }

    public void GameOn()
    {
        gameOn = true;
        startBoard.SetActive(false);
        GenerateGoal();
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
        countText.SetActive(true);
        score = 0;
        timeUp = false;
        gamePlayed++;
        AdsManager.Instance.bannerAds.ShowBannerAd();
        StartCoroutine(StartCountdown());
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
    }

    IEnumerator StartCountdown(float countdownValue = 4)
    {
        currCountdownValue = countdownValue;
        countDownText.text = currCountdownValue.ToString();
        while (currCountdownValue > 0)
        {
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--; 
            if(currCountdownValue <= 0){
                begin = true;
                countText.SetActive(false);
            }
            countDownText.text = currCountdownValue.ToString();
        }
    }

    public void MoreSeconds()
    {
        AdsManager.Instance.rewardedAds.ShowRewardedAd();
    }

    public void ContinueClick()
    {
        if (isRewarded == true)
        {
            looseBoard.SetActive(false);
            timer = 1.0f;
            timeUp = false;
            AdsManager.Instance.bannerAds.ShowBannerAd();
            StartCoroutine(StartCountdown());
            isRewarded = false;

        }
    }
}
