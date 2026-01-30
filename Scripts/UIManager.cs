// ============================================================================
// UIManager.cs - Controls All User Interface Elements
// ============================================================================
// This script handles:
// - Score display
// - Level display
// - Progress bar
// - Level up messages
// - Stats display
//
// Attach this to a UI Canvas or an empty "UIManager" GameObject.
// ============================================================================

using UnityEngine;
using UnityEngine.UI;   // Required for UI components like Text, Image, Slider

public class UIManager : MonoBehaviour
{
    // ========================================================================
    // UI ELEMENT REFERENCES
    // ========================================================================
    // Drag and drop your UI elements here in the Unity Inspector
    // ========================================================================

    [Header("Score Display")]
    public Text scoreText;              // Shows current points
    // If using TextMeshPro, change to: public TMPro.TextMeshProUGUI scoreText;

    [Header("Level Display")]
    public Text levelText;              // Shows "Level X"
    public Text levelNameText;          // Shows "2x4 Brick" etc.

    [Header("Progress Bar")]
    public Slider progressSlider;       // The progress bar slider
    public Image progressFillImage;     // The fill image (to change color)
    public Text progressText;           // Shows "150 / 500" points

    [Header("Stats Display")]
    public Text totalClicksText;        // Shows total clicks
    public Text pointsPerClickText;     // Shows points earned per click

    [Header("Level Up Message")]
    public GameObject levelUpPanel;     // Panel that appears on level up
    public Text levelUpText;            // Text in the level up panel
    public float levelUpDisplayTime = 2f; // How long to show level up message

    [Header("Progress Bar Colors")]
    public Color normalProgressColor = new Color(0.2f, 0.8f, 0.2f);  // Green
    public Color almostThereColor = new Color(1f, 0.8f, 0f);         // Yellow/Gold
    public Color maxLevelColor = new Color(0.6f, 0.9f, 1f);          // Diamond blue

    // ========================================================================
    // UNITY LIFECYCLE
    // ========================================================================

    /// <summary>
    /// Called at the start. Hides the level up panel.
    /// </summary>
    void Start()
    {
        // Make sure level up panel is hidden at start
        if (levelUpPanel != null)
        {
            levelUpPanel.SetActive(false);
        }
    }

    // ========================================================================
    // PUBLIC METHODS - Called by GameManager
    // ========================================================================

    /// <summary>
    /// Updates all UI elements with current game state.
    /// Called by GameManager whenever values change.
    /// </summary>
    /// <param name="points">Current point total</param>
    /// <param name="level">Current level (1-20)</param>
    /// <param name="levelName">Name of current level</param>
    /// <param name="pointsToNext">Points needed for next level</param>
    /// <param name="progress">Progress to next level (0-1)</param>
    /// <param name="totalClicks">Total clicks made</param>
    /// <param name="pointsPerClick">Points earned per click</param>
    public void UpdateDisplay(
        int points,
        int level,
        string levelName,
        int pointsToNext,
        float progress,
        int totalClicks,
        int pointsPerClick)
    {
        // Update score display
        UpdateScoreDisplay(points);

        // Update level display
        UpdateLevelDisplay(level, levelName);

        // Update progress bar
        UpdateProgressBar(points, pointsToNext, progress, level);

        // Update stats
        UpdateStatsDisplay(totalClicks, pointsPerClick);
    }

    /// <summary>
    /// Shows a level up celebration message.
    /// Called by GameManager when player levels up.
    /// </summary>
    /// <param name="newLevel">The new level number</param>
    /// <param name="levelName">The name of the new level</param>
    public void ShowLevelUpMessage(int newLevel, string levelName)
    {
        if (levelUpPanel == null || levelUpText == null)
        {
            Debug.LogWarning("Level up panel or text not assigned!");
            return;
        }

        // Set the message text
        levelUpText.text = $"LEVEL UP!\nLevel {newLevel}\n{levelName}";

        // Show the panel
        levelUpPanel.SetActive(true);

        // Hide it after a delay
        CancelInvoke(nameof(HideLevelUpMessage)); // Cancel any pending hide
        Invoke(nameof(HideLevelUpMessage), levelUpDisplayTime);
    }

    // ========================================================================
    // PRIVATE HELPER METHODS
    // ========================================================================

    /// <summary>
    /// Updates the score text display.
    /// </summary>
    private void UpdateScoreDisplay(int points)
    {
        if (scoreText != null)
        {
            // Format large numbers with commas for readability
            scoreText.text = FormatNumber(points);
        }
    }

    /// <summary>
    /// Updates the level text displays.
    /// </summary>
    private void UpdateLevelDisplay(int level, string levelName)
    {
        if (levelText != null)
        {
            levelText.text = $"Level {level}";
        }

        if (levelNameText != null)
        {
            levelNameText.text = levelName;
        }
    }

    /// <summary>
    /// Updates the progress bar.
    /// </summary>
    private void UpdateProgressBar(int currentPoints, int pointsToNext, float progress, int level)
    {
        // Update slider value
        if (progressSlider != null)
        {
            progressSlider.value = progress;
        }

        // Update progress text
        if (progressText != null)
        {
            if (level >= 20)
            {
                // Max level reached
                progressText.text = "MAX LEVEL!";
            }
            else
            {
                progressText.text = $"{FormatNumber(currentPoints)} / {FormatNumber(pointsToNext)}";
            }
        }

        // Update progress bar color
        if (progressFillImage != null)
        {
            if (level >= 20)
            {
                // Max level - use special color
                progressFillImage.color = maxLevelColor;
            }
            else if (progress > 0.8f)
            {
                // Almost there - use yellow/gold
                progressFillImage.color = almostThereColor;
            }
            else
            {
                // Normal progress - use green
                progressFillImage.color = normalProgressColor;
            }
        }
    }

    /// <summary>
    /// Updates the stats display.
    /// </summary>
    private void UpdateStatsDisplay(int totalClicks, int pointsPerClick)
    {
        if (totalClicksText != null)
        {
            totalClicksText.text = $"Clicks: {FormatNumber(totalClicks)}";
        }

        if (pointsPerClickText != null)
        {
            pointsPerClickText.text = $"+{pointsPerClick} per click";
        }
    }

    /// <summary>
    /// Hides the level up message panel.
    /// </summary>
    private void HideLevelUpMessage()
    {
        if (levelUpPanel != null)
        {
            levelUpPanel.SetActive(false);
        }
    }

    /// <summary>
    /// Formats a number with commas for readability.
    /// Example: 1234567 becomes "1,234,567"
    /// </summary>
    private string FormatNumber(int number)
    {
        return number.ToString("N0");
    }

    // ========================================================================
    // BUTTON HANDLERS (Optional - for UI buttons)
    // ========================================================================

    /// <summary>
    /// Called when the Save button is pressed.
    /// Hook this up to a UI Button's OnClick event.
    /// </summary>
    public void OnSaveButtonPressed()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.SaveGame();
            ShowTemporaryMessage("Game Saved!");
        }
    }

    /// <summary>
    /// Called when the Load button is pressed.
    /// </summary>
    public void OnLoadButtonPressed()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.LoadGame();
            ShowTemporaryMessage("Game Loaded!");
        }
    }

    /// <summary>
    /// Called when the Reset button is pressed.
    /// </summary>
    public void OnResetButtonPressed()
    {
        if (GameManager.Instance != null)
        {
            GameManager.Instance.ResetGame();
            ShowTemporaryMessage("Game Reset!");
        }
    }

    /// <summary>
    /// Shows a temporary message using the level up panel.
    /// </summary>
    private void ShowTemporaryMessage(string message)
    {
        if (levelUpPanel != null && levelUpText != null)
        {
            levelUpText.text = message;
            levelUpPanel.SetActive(true);
            CancelInvoke(nameof(HideLevelUpMessage));
            Invoke(nameof(HideLevelUpMessage), 1.5f);
        }
    }
}
