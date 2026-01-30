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
