using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProgressBar : MonoBehaviour
{
    public Slider progressBar;     // Reference to the UI Slider (Progress Bar)
    public Transform player;       // Reference to the player object
    public float minY = -2.17f;      // Minimum Y position the player can reach (ground level)
    public float maxY = 2.17f;       // Maximum Y position the player can reach (top level)

    private void Update()
    {
        // Get the player's current Y position
        float currentY = player.position.y;

        // Normalize the Y position between 0 and 1 based on minY and maxY
        float normalizedY = Mathf.InverseLerp(minY, maxY, currentY);

        // Update the progress bar's value
        progressBar.value = normalizedY;
    }
}
