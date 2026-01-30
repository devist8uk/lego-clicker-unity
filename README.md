# Lego Clicker - Unity Setup Guide

## Complete Step-by-Step Instructions for Beginners

This guide will walk you through creating a Lego Clicker game in Unity from scratch. Follow each step carefully!

---

## Table of Contents
1. [Create a New Unity Project](#step-1-create-a-new-unity-project)
2. [Set Up the Project Folders](#step-2-set-up-the-project-folders)
3. [Import the Scripts](#step-3-import-the-scripts)
4. [Create the Game Manager](#step-4-create-the-game-manager)
5. [Add Your Background Image](#step-5-add-your-background-image)
6. [Create the Lego Brick](#step-6-create-the-lego-brick)
7. [Set Up the User Interface](#step-7-set-up-the-user-interface)
8. [Connect Everything Together](#step-8-connect-everything-together)
9. [Test Your Game](#step-9-test-your-game)
10. [Troubleshooting](#troubleshooting)

---

## Step 1: Create a New Unity Project

1. **Open Unity Hub**
   - Launch Unity Hub from your Start menu or desktop

2. **Click "New Project"**
   - It's the blue button in the top-right corner

3. **Configure the Project**
   - **Template**: Select **"2D (Built-In Render Pipeline)"** - this is important!
   - **Project Name**: Type `LegoClicker`
   - **Location**: Choose where to save it (your Documents folder is fine)

4. **Click "Create Project"**
   - Wait for Unity to create and open your new project (this may take a few minutes)

---

## Step 2: Set Up the Project Folders

Once Unity opens, you'll see the **Project** window at the bottom.

1. **Create a Scripts Folder**
   - Right-click in the Project window (in the Assets area)
   - Select **Create → Folder**
   - Name it `Scripts`

2. **Create an Images Folder**
   - Right-click again in the Assets area
   - Select **Create → Folder**
   - Name it `Images`

Your Project window should now show:
```
Assets
├── Scripts
└── Images
```

---

## Step 3: Import the Scripts

You need to add 3 script files to your project.

### Method A: Copy from This Folder (Easiest)

1. Open Windows Explorer and navigate to:
   ```
   C:\Users\david\lego-clicker-unity\Scripts\
   ```

2. Select all 3 files:
   - `GameManager.cs`
   - `BrickController.cs`
   - `UIManager.cs`

3. Copy them (Ctrl+C)

4. In Unity, click on your **Scripts** folder in the Project window

5. Paste (Ctrl+V) or right-click and select **Paste**

6. Unity will import the scripts - you'll see them appear in the Scripts folder

### Method B: Create Scripts Manually

If copying doesn't work:

1. In Unity, right-click on the **Scripts** folder
2. Select **Create → C# Script**
3. Name it exactly `GameManager` (no .cs, Unity adds that)
4. Double-click the script to open it in Visual Studio
5. Delete everything in the file
6. Copy the entire contents from `C:\Users\david\lego-clicker-unity\Scripts\GameManager.cs`
7. Paste it into Visual Studio and save (Ctrl+S)
8. Repeat for `BrickController` and `UIManager`

**Important**: Make sure there are no errors! Look at the bottom of Unity for red error messages. If you see errors, the script names might not match the class names inside.

---

## Step 4: Create the Game Manager

The Game Manager is an invisible object that controls the entire game.

1. **Create an Empty GameObject**
   - In the menu bar, click **GameObject → Create Empty**
   - Or right-click in the **Hierarchy** window (left side) and select **Create Empty**

2. **Rename It**
   - Click on the new object in the Hierarchy
   - Press F2 or right-click and select **Rename**
   - Name it `GameManager`

3. **Add the Script**
   - With GameManager selected, look at the **Inspector** window (right side)
   - Click **Add Component** at the bottom
   - Type `GameManager` in the search box
   - Click on **GameManager** (your script) to add it

4. **Verify**
   - You should see the GameManager script in the Inspector
   - It will show "Brick Controller" and "UI Manager" fields (empty for now)

---

## Step 5: Add Your Background Image

### Import Your Tabletop Image

1. **Find your tabletop image file** (PNG or JPG)

2. **Drag it into Unity**
   - Drag the image file from Windows Explorer directly into the **Images** folder in Unity's Project window
   - Or right-click Images folder → **Import New Asset** → select your image

3. **Configure the Image for 2D**
   - Click on the image in the Project window
   - In the Inspector, make sure:
     - **Texture Type**: Sprite (2D and UI)
     - **Sprite Mode**: Single
   - Click **Apply** at the bottom if you changed anything

### Add Background to the Scene

1. **Drag the image into the Scene**
   - Drag your tabletop image from the Project window into the **Hierarchy** window
   - It will appear in your Scene view

2. **Position the Background**
   - Click on the background object in the Hierarchy
   - In the Inspector, find the **Transform** component
   - Set these values:
     - **Position**: X = `0`, Y = `0`, Z = `1` (Z=1 puts it behind other objects)

3. **Scale the Background**
   - Still in Transform, adjust the **Scale** to fill the screen
   - Try X = `10`, Y = `10`, Z = `1` (adjust as needed)
   - You can also drag the corners in the Scene view

4. **Rename It**
   - Rename this object to `Background`

---

## Step 6: Create the Lego Brick

### Import Your Brick Image

1. **Import your Lego brick image** the same way as the background
   - Drag it into the Images folder

2. **Configure for 2D**
   - Click the image in Project window
   - Set **Texture Type** to **Sprite (2D and UI)**
   - Click **Apply**

### Create the Brick GameObject

1. **Drag the brick image into the Hierarchy**
   - It will create a new Sprite object

2. **Rename it**
   - Name it `Brick`

3. **Position the Brick**
   - Select the Brick in Hierarchy
   - In Transform, set:
     - **Position**: X = `0`, Y = `0`, Z = `0` (in front of background)
     - **Scale**: Start with X = `0.5`, Y = `0.5`, Z = `1` (adjust to taste)

### Add Click Detection (Very Important!)

For the brick to detect mouse clicks, it needs a Collider:

1. **Select the Brick** in the Hierarchy

2. **Add a Box Collider 2D**
   - Click **Add Component** in the Inspector
   - Type `Box Collider 2D`
   - Click on **Box Collider 2D** to add it

3. **Verify the Collider**
   - You should see a green rectangle around your brick in the Scene view
   - If it doesn't match your brick size, click **Edit Collider** and drag the edges

### Add the Brick Controller Script

1. **With Brick still selected**, click **Add Component**

2. **Type `BrickController`** and select it

3. **Verify**
   - The Inspector should now show both:
     - Sprite Renderer (automatically added with the sprite)
     - Box Collider 2D
     - Brick Controller (Script)

---

## Step 7: Set Up the User Interface

The UI displays your score, level, and progress bar.

### Create the Canvas

1. **Create a Canvas**
   - Right-click in the Hierarchy
   - Select **UI → Canvas**
   - A Canvas and EventSystem will be created

2. **Configure Canvas Settings** (Optional but recommended)
   - Select the Canvas in Hierarchy
   - In Inspector, find **Canvas Scaler**
   - Set **UI Scale Mode** to **Scale With Screen Size**
   - Set **Reference Resolution** to X = `1920`, Y = `1080`

### Create Score Display

1. **Create Score Text**
   - Right-click on **Canvas** in the Hierarchy
   - Select **UI → Text - TextMeshPro**
   - If prompted to import TMP Essentials, click **Import TMP Essentials**
   - Rename it to `ScoreText`

2. **Position the Score**
   - Select ScoreText
   - In the Inspector, find **Rect Transform**
   - Click the anchor preset box (square icon in top-left of Rect Transform)
   - Hold Alt and click **top-center** to anchor to top-center
   - Set **Pos Y** to `-50` to move it down from the edge

3. **Style the Score**
   - In the **TextMeshPro - Text (UI)** component:
   - Set **Text** to `0` (placeholder)
   - Set **Font Size** to `72`
   - Set **Alignment** to **Center** (both horizontal and vertical)
   - Change **Vertex Color** to white or any color you like

### Create Level Display

1. **Create Level Text**
   - Right-click on Canvas → **UI → Text - TextMeshPro**
   - Rename to `LevelText`

2. **Position It**
   - Anchor to top-left (Alt+click)
   - Set **Pos X** to `150`, **Pos Y** to `-50`

3. **Style It**
   - Text: `Level 1`
   - Font Size: `36`

### Create Level Name Display

1. **Create another Text**
   - Right-click Canvas → **UI → Text - TextMeshPro**
   - Rename to `LevelNameText`

2. **Position below Level Text**
   - Anchor top-left
   - Pos X: `150`, Pos Y: `-90`

3. **Style It**
   - Text: `1x1 Brick`
   - Font Size: `24`

### Create Progress Bar

1. **Create a Slider**
   - Right-click Canvas → **UI → Slider**
   - Rename to `ProgressSlider`

2. **Position the Slider**
   - Anchor to bottom-center (Alt+click)
   - Pos Y: `100`
   - Width: `600`, Height: `30`

3. **Configure as Progress Bar (not interactive)**
   - Select ProgressSlider
   - **Uncheck "Interactable"** in the Inspector
   - Set **Value** to `0`
   - Set **Min Value** to `0`
   - Set **Max Value** to `1`

4. **Remove the Handle**
   - Expand ProgressSlider in Hierarchy (click the arrow)
   - Find **Handle Slide Area**
   - Delete it (select and press Delete)

5. **Style the Fill**
   - Expand **Fill Area → Fill**
   - Select **Fill**
   - In **Image** component, change **Color** to green

### Create Progress Text

1. **Create Text as child of Slider**
   - Right-click on ProgressSlider → **UI → Text - TextMeshPro**
   - Rename to `ProgressText`

2. **Center it on the slider**
   - Anchor to stretch-stretch (fills parent)
   - All offsets to 0

3. **Style It**
   - Text: `0 / 10`
   - Font Size: `20`
   - Alignment: Center
   - Color: Black or white (whatever shows on your bar)

### Create Stats Display

1. **Create Total Clicks Text**
   - Right-click Canvas → **UI → Text - TextMeshPro**
   - Rename to `TotalClicksText`
   - Anchor bottom-left, Pos X: `150`, Pos Y: `50`
   - Text: `Clicks: 0`, Size: `24`

2. **Create Points Per Click Text**
   - Right-click Canvas → **UI → Text - TextMeshPro**
   - Rename to `PointsPerClickText`
   - Anchor bottom-left, Pos X: `150`, Pos Y: `20`
   - Text: `+1 per click`, Size: `20`

### Create Level Up Panel

1. **Create a Panel**
   - Right-click Canvas → **UI → Panel**
   - Rename to `LevelUpPanel`

2. **Size and Position**
   - Anchor to middle-center
   - Width: `400`, Height: `200`

3. **Style the Panel**
   - In **Image** component, change color to semi-transparent black (RGBA: 0, 0, 0, 200)

4. **Add Level Up Text**
   - Right-click LevelUpPanel → **UI → Text - TextMeshPro**
   - Rename to `LevelUpText`
   - Anchor stretch-stretch, all offsets to 20
   - Text: `LEVEL UP!`
   - Font Size: `48`
   - Alignment: Center
   - Color: Gold/Yellow

5. **Hide the Panel**
   - Select LevelUpPanel
   - **Uncheck the checkbox** at the top of the Inspector (next to the name)
   - This hides it - the game will show it when you level up

### Create UI Manager Object

1. **Create Empty GameObject**
   - GameObject → Create Empty
   - Rename to `UIManager`

2. **Add UIManager Script**
   - Select UIManager object
   - Add Component → type `UIManager` → select it

---

## Step 8: Connect Everything Together

Now we need to tell our scripts about each other. This is done by dragging objects into slots.

### Connect the Game Manager

1. **Select GameManager** in the Hierarchy

2. **In the Inspector**, find the GameManager script component

3. **Drag and Drop References**:
   - **Brick Controller**: Drag the `Brick` object from Hierarchy into this slot
   - **UI Manager**: Drag the `UIManager` object from Hierarchy into this slot

### Connect the Brick Controller

1. **Select Brick** in the Hierarchy

2. **Find the Brick Controller component**

3. **Sprite Renderer** should auto-fill, but if empty:
   - Drag the Brick object itself into the slot
   - Or leave it empty (the script will find it automatically)

### Connect the UI Manager

1. **Select UIManager** in the Hierarchy

2. **Find the UIManager script component**

3. **Drag each UI element into its matching slot**:

   | Slot Name | Drag This Object |
   |-----------|------------------|
   | Score Text | ScoreText |
   | Level Text | LevelText |
   | Level Name Text | LevelNameText |
   | Progress Slider | ProgressSlider |
   | Progress Fill Image | Fill (inside ProgressSlider/Fill Area) |
   | Progress Text | ProgressText |
   | Total Clicks Text | TotalClicksText |
   | Points Per Click Text | PointsPerClickText |
   | Level Up Panel | LevelUpPanel |
   | Level Up Text | LevelUpText |

**Tip**: You can lock the Inspector by clicking the lock icon at the top-right, then drag multiple objects without losing your selection.

---

## Step 9: Test Your Game

1. **Save Your Scene**
   - Press Ctrl+S
   - Name it `MainScene` and save in Assets folder

2. **Press Play**
   - Click the **Play button** at the top center of Unity (▶️)
   - Or press Ctrl+P

3. **Test These Things**:

   | Action | Expected Result |
   |--------|-----------------|
   | Click the brick | Score increases by 1 |
   | Click 10 times | Level up to Level 2, brick grows slightly |
   | Keep clicking | Progress bar fills up |
   | Level up | "LEVEL UP!" message appears briefly |
   | Reach Level 9 | Brick starts changing colors |
   | Reach Level 17+ | Special metallic colors |

4. **Stop the Game**
   - Press the Play button again to stop
   - Or press Ctrl+P

---

## Step 10: Build Your Game (Optional)

To create a standalone .exe file:

1. **File → Build Settings**

2. **Add Open Scenes**
   - Click "Add Open Scenes" to add your MainScene

3. **Select Platform**
   - Make sure "Windows, Mac, Linux" is selected
   - Click "Switch Platform" if needed

4. **Click Build**
   - Choose a folder for the build
   - Wait for Unity to build

5. **Run Your Game**
   - Open the build folder
   - Double-click the .exe file

---

## Troubleshooting

### "Script can't be loaded" Error
- Make sure the script filename matches the class name inside
- `GameManager.cs` must contain `public class GameManager`

### Clicking the Brick Does Nothing
- Check that the Brick has a **Box Collider 2D** component
- Make sure the collider covers the brick sprite
- Check that GameManager exists and has the GameManager script

### UI Not Updating
- Make sure UIManager object has the UIManager script
- Check all UI references are connected (no empty slots)
- Make sure GameManager has the UIManager reference set

### Brick Not Visible
- Check the Z position (should be 0, in front of background at Z=1)
- Check the Scale isn't 0
- Make sure there's a Sprite Renderer with a sprite assigned

### "NullReferenceException" Error
- This means something isn't connected
- Check the error message to see which script has the problem
- Make sure all the Inspector slots are filled

### Level Up Panel Keeps Appearing at Start
- Make sure LevelUpPanel is disabled (checkbox unchecked in Inspector)

### Progress Bar Shows Wrong Colors
- Make sure Progress Fill Image is connected to the actual Fill image
- Check that the colors are set in the UIManager Inspector

---

## Understanding the Code

### GameManager.cs
This is the "brain" of your game. It:
- Tracks your points and level
- Decides when you level up
- Tells other scripts what to do

### BrickController.cs
This controls the Lego brick. It:
- Detects when you click it
- Plays animations (bounce on click, grow on level up)
- Changes size and color based on level
- Has special rainbow and diamond effects

### UIManager.cs
This handles everything you see on screen. It:
- Updates the score display
- Shows your level and progress
- Shows the "Level Up!" message
- Formats numbers nicely (1000 → 1,000)

---

## Customization Ideas

Once everything works, try these modifications:

1. **Change the point values** in GameManager.cs (pointsToNextLevel array)
2. **Change the colors** in GameManager.cs (levelColors array)
3. **Adjust animation speed** in BrickController.cs
4. **Change level names** in GameManager.cs (levelNames array)
5. **Add sound effects** using Unity's AudioSource

---

## Need Help?

If you get stuck:
1. Re-read the relevant section carefully
2. Check the Troubleshooting section
3. Make sure Unity has no red error messages in the Console
4. Try restarting Unity and opening the project again

Good luck with your project! 🧱

---

## Complete Script Code

Below is the full code for all three scripts. You can copy and paste these directly into Unity.

---

### GameManager.cs (Copy this entire code block)

```csharp
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
```

---

### BrickController.cs (Copy this entire code block)

```csharp
// ============================================================================
// BrickController.cs - Controls the Lego Brick Visual Behavior
// ============================================================================
// This script handles:
// - Click detection on the brick
// - Visual effects (scale, color, animations)
// - Special material effects (shimmer, glow)
//
// Attach this script to your Brick GameObject (the one with the sprite).
// ============================================================================

using UnityEngine;

public class BrickController : MonoBehaviour
{
    // ========================================================================
    // COMPONENT REFERENCES
    // ========================================================================
    // These are set automatically or in the Inspector
    // ========================================================================

    [Header("Component References")]
    public SpriteRenderer spriteRenderer;    // The sprite renderer showing the brick image

    // ========================================================================
    // ANIMATION SETTINGS
    // ========================================================================
    // Tweak these values to adjust how the animations feel
    // ========================================================================

    [Header("Click Animation Settings")]
    public float clickScaleMultiplier = 1.2f;   // How much bigger the brick gets when clicked
    public float clickAnimationSpeed = 10f;      // How fast the click animation plays

    [Header("Level Up Animation Settings")]
    public float levelUpScaleMultiplier = 1.5f;  // How big the brick gets on level up
    public float levelUpAnimationSpeed = 5f;     // How fast the level up animation plays

    [Header("Special Effects")]
    public bool enableRainbowEffect = false;     // For rainbow brick (level 19)
    public float rainbowSpeed = 2f;              // How fast rainbow colors cycle

    // ========================================================================
    // PRIVATE STATE VARIABLES
    // ========================================================================
    // These track the current animation state
    // ========================================================================

    private Vector3 baseScale = Vector3.one;     // The normal scale of the brick
    private Vector3 targetScale;                  // The scale we're animating towards
    private Color baseColor = Color.white;        // The normal color of the brick
    private Color targetColor;                    // The color we're animating towards

    private bool isAnimatingClick = false;        // Are we playing the click animation?
    private bool isAnimatingLevelUp = false;      // Are we playing the level up animation?
    private bool isSpecialBrick = false;          // Is this a special material brick?

    private int currentLevelForEffects = 1;       // Track level for special effects

    // ========================================================================
    // UNITY LIFECYCLE METHODS
    // ========================================================================

    /// <summary>
    /// Called when the script first loads.
    /// Gets references to required components.
    /// </summary>
    void Awake()
    {
        // If sprite renderer wasn't assigned in inspector, try to find it
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        // Store the initial scale as our base
        baseScale = transform.localScale;
        targetScale = baseScale;
    }

    /// <summary>
    /// Called at the start of the game.
    /// </summary>
    void Start()
    {
        targetColor = baseColor;
    }

    /// <summary>
    /// Called every frame.
    /// Handles smooth animations and special effects.
    /// </summary>
    void Update()
    {
        // Smoothly animate scale changes
        AnimateScale();

        // Handle special rainbow effect for level 19
        if (enableRainbowEffect && currentLevelForEffects == 19)
        {
            AnimateRainbow();
        }

        // Handle diamond shimmer for level 20
        if (currentLevelForEffects == 20)
        {
            AnimateDiamondShimmer();
        }
    }

    // ========================================================================
    // CLICK DETECTION
    // ========================================================================

    /// <summary>
    /// Called by Unity when the mouse clicks on this object.
    /// Requires a Collider2D component on the brick!
    /// </summary>
    void OnMouseDown()
    {
        // Tell the GameManager that the brick was clicked
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnBrickClicked();
        }
        else
        {
            Debug.LogError("GameManager.Instance is null! Make sure GameManager exists in the scene.");
        }
    }

    // ========================================================================
    // PUBLIC METHODS - Called by GameManager
    // ========================================================================

    /// <summary>
    /// Updates the brick's appearance based on the current level.
    /// Called by GameManager when level changes.
    /// </summary>
    /// <param name="scale">The new scale multiplier</param>
    /// <param name="color">The new color</param>
    /// <param name="isSpecial">Is this a special material level?</param>
    /// <param name="level">The current level number</param>
    public void UpdateAppearance(float scale, Color color, bool isSpecial, int level)
    {
        // Update base scale (what we return to after animations)
        baseScale = Vector3.one * scale;
        targetScale = baseScale;

        // Update color
        baseColor = color;
        targetColor = color;

        // Apply color to sprite
        if (spriteRenderer != null)
        {
            spriteRenderer.color = color;
        }

        // Track special state
        isSpecialBrick = isSpecial;
        currentLevelForEffects = level;

        // Enable rainbow for level 19
        enableRainbowEffect = (level == 19);

        Debug.Log($"Brick updated: Scale={scale}, Color={color}, Special={isSpecial}");
    }

    /// <summary>
    /// Plays the click feedback animation.
    /// Called by GameManager when brick is clicked.
    /// </summary>
    public void PlayClickEffect()
    {
        // Start the click animation
        isAnimatingClick = true;

        // Set target to enlarged scale
        targetScale = baseScale * clickScaleMultiplier;

        // After a short delay, return to normal
        Invoke(nameof(ResetClickAnimation), 0.1f);
    }

    /// <summary>
    /// Plays the level up celebration animation.
    /// Called by GameManager when player levels up.
    /// </summary>
    public void PlayLevelUpEffect()
    {
        // Start level up animation
        isAnimatingLevelUp = true;

        // Make brick bigger temporarily
        targetScale = baseScale * levelUpScaleMultiplier;

        // Flash white briefly
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.white;
        }

        // Return to normal after animation
        Invoke(nameof(ResetLevelUpAnimation), 0.3f);
    }

    // ========================================================================
    // PRIVATE ANIMATION METHODS
    // ========================================================================

    /// <summary>
    /// Smoothly animates the brick's scale towards the target.
    /// </summary>
    private void AnimateScale()
    {
        // Only animate if we're not at target scale
        if (transform.localScale != targetScale)
        {
            // Determine animation speed based on what we're animating
            float speed = isAnimatingLevelUp ? levelUpAnimationSpeed : clickAnimationSpeed;

            // Smoothly move towards target scale
            transform.localScale = Vector3.Lerp(
                transform.localScale,
                targetScale,
                Time.deltaTime * speed
            );

            // Snap to target if very close (prevents jittering)
            if (Vector3.Distance(transform.localScale, targetScale) < 0.01f)
            {
                transform.localScale = targetScale;
            }
        }
    }

    /// <summary>
    /// Resets the click animation back to normal.
    /// </summary>
    private void ResetClickAnimation()
    {
        isAnimatingClick = false;
        targetScale = baseScale;
    }

    /// <summary>
    /// Resets the level up animation back to normal.
    /// </summary>
    private void ResetLevelUpAnimation()
    {
        isAnimatingLevelUp = false;
        targetScale = baseScale;

        // Return to base color
        if (spriteRenderer != null)
        {
            spriteRenderer.color = baseColor;
        }
    }

    /// <summary>
    /// Creates the rainbow cycling effect for level 19.
    /// </summary>
    private void AnimateRainbow()
    {
        if (spriteRenderer == null) return;

        // Use HSV color space to cycle through all colors
        float hue = Mathf.PingPong(Time.time * rainbowSpeed, 1f);

        // Convert HSV to RGB (full saturation and value)
        Color rainbowColor = Color.HSVToRGB(hue, 1f, 1f);

        spriteRenderer.color = rainbowColor;
    }

    /// <summary>
    /// Creates a shimmer effect for the diamond brick (level 20).
    /// </summary>
    private void AnimateDiamondShimmer()
    {
        if (spriteRenderer == null) return;

        // Create a subtle pulsing brightness
        float brightness = 0.8f + Mathf.Sin(Time.time * 3f) * 0.2f;

        // Apply brightness to the base diamond color
        Color shimmerColor = new Color(
            baseColor.r * brightness,
            baseColor.g * brightness,
            baseColor.b * brightness + 0.1f  // Slight blue tint
        );

        spriteRenderer.color = shimmerColor;
    }

    // ========================================================================
    // OPTIONAL: Touch Support for Mobile
    // ========================================================================

    /// <summary>
    /// Alternative click detection that works better on some setups.
    /// You can use this instead of OnMouseDown if needed.
    /// </summary>
    public void OnClick()
    {
        // Same as OnMouseDown - call GameManager
        if (GameManager.Instance != null)
        {
            GameManager.Instance.OnBrickClicked();
        }
    }
}
```

---

### UIManager.cs (Copy this entire code block)

```csharp
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
```

---

*Created for Unity 2022.x / Visual Studio 2022*
*Last Updated: January 2026*
