using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Services.Leaderboards;

public class ScoreManager : MonoBehaviour
{
    private int playerScore = 0;
    private string playerName;
    private string leaderboardId = "your_leaderboard_id";

    void Start()
    {
        // Load the player's name from PlayerPrefs
        playerName = PlayerPrefs.GetString("PlayerName", "Unknown Player");

        // Initialize player score (for demo purposes, we assume it starts at 0)
        playerScore = 0;
    }

    public void UpdateScore(int points)
    {
        playerScore += points;
        SubmitScore(playerScore);
    }

    async void SubmitScore(int score)
    {
        // Submit the score to Unity's leaderboard
        try
        {
            await LeaderboardsService.Instance.AddPlayerScoreAsync(leaderboardId, score);
            Debug.Log($"{playerName}'s score of {score} has been submitted.");
        }

        catch (LeaderboardServiceException e)
        {
            Debug.LogError("Error submitting score: " + e.Message);
        }
    }
}
