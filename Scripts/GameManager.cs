// ============================================================================
// GameManager.cs - The Main Controller for Lego Clicker
// ============================================================================
// This script manages the entire game: scoring, leveling, and progression.
// Attach this to an empty GameObject called "GameManager" in your scene.
// ============================================================================

using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ========================================================================
    // SINGLETON PATTERN
    // ========================================================================
    // This allows other scripts to easily access GameManager using:
    // GameManager.Instance.AddPoints(10);
    // ========================================================================

    public static GameManager Instance { get; private set; }

    // ========================================================================
    // GAME STATE VARIABLES
    // ========================================================================
    // These track the current state of the game
    // ========================================================================

    [Header("Current Game State")]
    public int currentPoints = 0;        // Player's current point total
    public int totalClicks = 0;          // Total clicks made (for stats)
    public int currentLevel = 1;         // Current level (1-20)

    // ========================================================================
    // LEVEL CONFIGURATION
    // ========================================================================
    // Arrays that define what happens at each level
    // ========================================================================

    [Header("Level Configuration")]

    // Points needed to reach the NEXT level (index 0 = level 1 -> 2)
    // We have 19 values because level 20 is the max
    private int[] pointsToNextLevel = new int[]
    {
        // Size progression (Levels 1-8)
        10,      // Level 1 -> 2
        25,      // Level 2 -> 3
        50,      // Level 3 -> 4
        100,     // Level 4 -> 5
        200,     // Level 5 -> 6
        400,     // Level 6 -> 7
        800,     // Level 7 -> 8
        1500,    // Level 8 -> 9

        // Color progression (Levels 9-16)
        2500,    // Level 9 -> 10
        4000,    // Level 10 -> 11
        6000,    // Level 11 -> 12
        9000,    // Level 12 -> 13
        13000,   // Level 13 -> 14
        18000,   // Level 14 -> 15
        25000,   // Level 15 -> 16
        35000,   // Level 16 -> 17

        // Special materials (Levels 17-20)
        50000,   // Level 17 -> 18
        75000,   // Level 18 -> 19
        100000   // Level 19 -> 20 (MAX)
    };

    // Brick scale at each level (how big the brick appears)
    // Index 0 = Level 1, Index 19 = Level 20
    private float[] brickScales = new float[]
    {
        // Size progression - brick gets bigger
        0.5f,    // Level 1: 1x1 (small)
        0.6f,    // Level 2: 1x2
        0.7f,    // Level 3: 1x3
        0.8f,    // Level 4: 1x4
        0.9f,    // Level 5: 2x2
        1.0f,    // Level 6: 2x3
        1.1f,    // Level 7: 2x4
        1.2f,    // Level 8: 2x4 (slightly bigger)

        // Color levels - same size, different colors
        1.2f, 1.2f, 1.2f, 1.2f, 1.2f, 1.2f, 1.2f, 1.2f,

        // Special materials - same size
        1.2f, 1.2f, 1.2f, 1.2f
    };

    // Colors for each level
    // Levels 1-8 use the default brick color (index 0)
    // Levels 9-16 use different colors
    // Levels 17-20 use special material colors
    private Color[] levelColors = new Color[]
    {
        // Size levels (1-8) - Default red brick color
        new Color(0.8f, 0.1f, 0.1f),  // Level 1: Red
        new Color(0.8f, 0.1f, 0.1f),  // Level 2: Red
        new Color(0.8f, 0.1f, 0.1f),  // Level 3: Red
        new Color(0.8f, 0.1f, 0.1f),  // Level 4: Red
        new Color(0.8f, 0.1f, 0.1f),  // Level 5: Red
        new Color(0.8f, 0.1f, 0.1f),  // Level 6: Red
        new Color(0.8f, 0.1f, 0.1f),  // Level 7: Red
        new Color(0.8f, 0.1f, 0.1f),  // Level 8: Red

        // Color progression (9-16)
        new Color(0.9f, 0.2f, 0.2f),  // Level 9: Bright Red
        new Color(0.2f, 0.4f, 0.9f),  // Level 10: Blue
        new Color(0.2f, 0.8f, 0.3f),  // Level 11: Green
        new Color(0.95f, 0.9f, 0.2f), // Level 12: Yellow
        new Color(1.0f, 0.5f, 0.0f),  // Level 13: Orange
        new Color(0.6f, 0.2f, 0.8f),  // Level 14: Purple
        new Color(1.0f, 0.4f, 0.7f),  // Level 15: Pink
        new Color(0.15f, 0.15f, 0.15f), // Level 16: Black

        // Special materials (17-20)
        new Color(0.75f, 0.75f, 0.8f),  // Level 17: Silver
        new Color(1.0f, 0.84f, 0.0f),   // Level 18: Gold
        new Color(1.0f, 0.5f, 0.5f),    // Level 19: Rainbow (will animate)
        new Color(0.6f, 0.9f, 1.0f)     // Level 20: Diamond
    };

    // Points earned per click at each level
    private int[] pointsPerClick = new int[]
    {
        // Size levels (1-8): 1 point per click
        1, 1, 1, 1, 1, 1, 1, 1,

        // Color levels (9-12): 2 points per click
        2, 2, 2, 2,

        // Color levels (13-16): 3 points per click
        3, 3, 3, 3,

        // Special levels (17-19): 5 points per click
        5, 5, 5,

        // Diamond level (20): 10 points per click
        10
    };

    // Names for each level (displayed in UI)
    private string[] levelNames = new string[]
    {
        "1x1 Brick", "1x2 Brick", "1x3 Brick", "1x4 Brick",
        "2x2 Brick", "2x3 Brick", "2x4 Brick", "2x4 Brick",
        "Red Brick", "Blue Brick", "Green Brick", "Yellow Brick",
        "Orange Brick", "Purple Brick", "Pink Brick", "Black Brick",
        "Silver Brick", "Gold Brick", "Rainbow Brick", "Diamond Brick"
    };

    // ========================================================================
    // REFERENCES TO OTHER SCRIPTS
    // ========================================================================
    // These will be set in the Unity Inspector
    // ========================================================================

    [Header("Script References")]
    public BrickController brickController;  // Controls the brick visuals
    public UIManager uiManager;              // Controls the UI display

    // ========================================================================
    // UNITY LIFECYCLE METHODS
    // ========================================================================

    /// <summary>
    /// Called when the script first loads.
    /// Sets up the singleton instance.
    /// </summary>
    void Awake()
    {
        // Singleton setup - ensures only one GameManager exists
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            // If another GameManager exists, destroy this one
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Called on the first frame.
    /// Initializes the game state.
    /// </summary>
    void Start()
    {
        // Initialize the game at level 1
        UpdateBrickAppearance();
        UpdateUI();
    }

    // ========================================================================
    // CORE GAME METHODS
    // ========================================================================

    /// <summary>
    /// Called when the player clicks the brick.
    /// This is the main game action!
    /// </summary>
    public void OnBrickClicked()
    {
        // Increment click counter
        totalClicks++;

        // Calculate points earned for this click
        int pointsEarned = GetPointsPerClick();

        // Add points to total
        currentPoints += pointsEarned;

        // Check if we've earned enough points to level up
        CheckForLevelUp();

        // Update the UI to show new values
        UpdateUI();

        // Tell the brick to play its click animation
        if (brickController != null)
        {
            brickController.PlayClickEffect();
        }

        // Debug log (you can see this in Unity's Console window)
        Debug.Log($"Click! +{pointsEarned} points. Total: {currentPoints}");
    }

    /// <summary>
    /// Returns how many points each click gives at the current level.
    /// </summary>
    public int GetPointsPerClick()
    {
        // Array is 0-indexed, so level 1 = index 0
        int index = currentLevel - 1;

        // Make sure we don't go out of bounds
        if (index >= 0 && index < pointsPerClick.Length)
        {
            return pointsPerClick[index];
        }

        return 1; // Default fallback
    }

    /// <summary>
    /// Returns the points needed to reach the next level.
    /// </summary>
    public int GetPointsForNextLevel()
    {
        // If we're at max level, return 0
        if (currentLevel >= 20)
        {
            return 0;
        }

        // Array is 0-indexed
        int index = currentLevel - 1;

        if (index >= 0 && index < pointsToNextLevel.Length)
        {
            return pointsToNextLevel[index];
        }

        return 999999; // Fallback for safety
    }

    /// <summary>
    /// Returns the name/description of the current level.
    /// </summary>
    public string GetCurrentLevelName()
    {
        int index = currentLevel - 1;

        if (index >= 0 && index < levelNames.Length)
        {
            return levelNames[index];
        }

        return "Unknown";
    }

    /// <summary>
    /// Returns a value from 0 to 1 representing progress to next level.
    /// Used for the progress bar.
    /// </summary>
    public float GetLevelProgress()
    {
        // If at max level, progress bar is full
        if (currentLevel >= 20)
        {
            return 1f;
        }

        int pointsNeeded = GetPointsForNextLevel();

        if (pointsNeeded <= 0)
        {
            return 1f;
        }

        // Calculate progress as a percentage
        float progress = (float)currentPoints / (float)pointsNeeded;

        // Clamp between 0 and 1
        return Mathf.Clamp01(progress);
    }

    // ========================================================================
    // LEVEL UP SYSTEM
    // ========================================================================

    /// <summary>
    /// Checks if the player has enough points to level up.
    /// If so, triggers the level up!
    /// </summary>
    private void CheckForLevelUp()
    {
        // Can't level up past 20
        if (currentLevel >= 20)
        {
            return;
        }

        int pointsNeeded = GetPointsForNextLevel();

        // Check if we have enough points
        if (currentPoints >= pointsNeeded)
        {
            // Level up!
            LevelUp();
        }
    }

    /// <summary>
    /// Handles the level up process.
    /// </summary>
    private void LevelUp()
    {
        // Subtract the points spent on leveling
        currentPoints -= GetPointsForNextLevel();

        // Increase level
        currentLevel++;

        // Make sure we don't exceed max level
        if (currentLevel > 20)
        {
            currentLevel = 20;
        }

        // Update the brick's appearance for the new level
        UpdateBrickAppearance();

        // Play level up effects
        if (brickController != null)
        {
            brickController.PlayLevelUpEffect();
        }

        if (uiManager != null)
        {
            uiManager.ShowLevelUpMessage(currentLevel, GetCurrentLevelName());
        }

        Debug.Log($"LEVEL UP! Now level {currentLevel}: {GetCurrentLevelName()}");

        // Check if we can level up again (if we have lots of points)
        CheckForLevelUp();
    }

    /// <summary>
    /// Updates the brick's visual appearance based on current level.
    /// </summary>
    private void UpdateBrickAppearance()
    {
        if (brickController == null)
        {
            Debug.LogWarning("BrickController not assigned!");
            return;
        }

        int index = currentLevel - 1;

        // Get the scale for this level
        float scale = brickScales[index];

        // Get the color for this level
        Color color = levelColors[index];

        // Check if this is a special material level (17-20)
        bool isSpecial = currentLevel >= 17;

        // Tell the brick controller to update
        brickController.UpdateAppearance(scale, color, isSpecial, currentLevel);
    }

    /// <summary>
    /// Updates all UI elements.
    /// </summary>
    private void UpdateUI()
    {
        if (uiManager != null)
        {
            uiManager.UpdateDisplay(
                currentPoints,
                currentLevel,
                GetCurrentLevelName(),
                GetPointsForNextLevel(),
                GetLevelProgress(),
                totalClicks,
                GetPointsPerClick()
            );
        }
    }

    // ========================================================================
    // SAVE/LOAD (Optional - for later)
    // ========================================================================

    /// <summary>
    /// Saves the game state. Call this periodically or when the game closes.
    /// </summary>
    public void SaveGame()
    {
        PlayerPrefs.SetInt("CurrentPoints", currentPoints);
        PlayerPrefs.SetInt("CurrentLevel", currentLevel);
        PlayerPrefs.SetInt("TotalClicks", totalClicks);
        PlayerPrefs.Save();

        Debug.Log("Game Saved!");
    }

    /// <summary>
    /// Loads the saved game state.
    /// </summary>
    public void LoadGame()
    {
        if (PlayerPrefs.HasKey("CurrentLevel"))
        {
            currentPoints = PlayerPrefs.GetInt("CurrentPoints", 0);
            currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
            totalClicks = PlayerPrefs.GetInt("TotalClicks", 0);

            UpdateBrickAppearance();
            UpdateUI();

            Debug.Log("Game Loaded!");
        }
    }

    /// <summary>
    /// Resets the game to the beginning.
    /// </summary>
    public void ResetGame()
    {
        currentPoints = 0;
        currentLevel = 1;
        totalClicks = 0;

        // Clear saved data
        PlayerPrefs.DeleteAll();

        UpdateBrickAppearance();
        UpdateUI();

        Debug.Log("Game Reset!");
    }
}
