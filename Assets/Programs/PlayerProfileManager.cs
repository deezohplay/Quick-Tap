using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProfileManager : MonoBehaviour
{
    public InputField playerNameInput;
    public Button submitButton;
    public TextMeshProUGUI welcomeText;

    void Start()
    {
        // Check if the player's name has already been saved
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            // Load the player's name from PlayerPrefs
            string playerName = PlayerPrefs.GetString("PlayerName");
            welcomeText.text = "Welcome back, " + playerName + "!";
        }
        else
        {
            // Prompt the player to enter their name
            welcomeText.text = "Enter your name to begin:";
        }

        submitButton.onClick.AddListener(SavePlayerName);
    }

    void SavePlayerName()
    {
        string playerName = playerNameInput.text;
        if (!string.IsNullOrEmpty(playerName))
        {
            // Save the player's name
            PlayerPrefs.SetString("PlayerName", playerName);
            PlayerPrefs.Save();
            welcomeText.text = "Welcome, " + playerName + "!";
        }
        else
        {
            Debug.LogWarning("Player name is empty!");
        }
    }
}
