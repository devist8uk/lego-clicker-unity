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

*Created for Unity 2022.x / Visual Studio 2022*
*Last Updated: January 2026*
