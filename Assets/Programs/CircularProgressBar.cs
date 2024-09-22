using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircularProgressBar : MonoBehaviour
{
    public static CircularProgressBar Instance { get; private set; }
    public Image progressBar;
    private float timeRemaining = 5f;
    private float maxTime = 5f;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeRemaining > 0 && PlayerFloat.Instance.isInWater == true)
        {
            timeRemaining -= Time.deltaTime;
            UpdateProgressBar();
        }
        else
        {
            timeRemaining = 0;
            UpdateProgressBar();
        }
    }
    void UpdateProgressBar()
    {
        float progress = timeRemaining/ maxTime;
        progressBar.fillAmount = progress;
    }
}
