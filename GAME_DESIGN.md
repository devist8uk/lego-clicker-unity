# Lego Clicker - Game Design Document

## Game Concept
A simple clicker game where players click a Lego brick to earn points and level up. As they level up, the brick grows from a 1x1 to a 2x4, then changes through different colors and materials.

---

## Leveling System

### Brick Size Progression (Levels 1-8)
| Level | Brick Size | Points to Next Level |
|-------|------------|---------------------|
| 1     | 1x1        | 10                  |
| 2     | 1x2        | 25                  |
| 3     | 1x3        | 50                  |
| 4     | 1x4        | 100                 |
| 5     | 2x2        | 200                 |
| 6     | 2x3        | 400                 |
| 7     | 2x4        | 800                 |
| 8     | 2x4 (Max Size) | Continue to colors |

### Color Progression (Levels 9-16)
| Level | Color      | Points to Next Level |
|-------|------------|---------------------|
| 9     | Red        | 1,500               |
| 10    | Blue       | 2,500               |
| 11    | Green      | 4,000               |
| 12    | Yellow     | 6,000               |
| 13    | Orange     | 9,000               |
| 14    | Purple     | 13,000              |
| 15    | Pink       | 18,000              |
| 16    | Black      | 25,000              |

### Special Material Progression (Levels 17-20)
| Level | Material   | Points to Next Level |
|-------|------------|---------------------|
| 17    | Silver     | 35,000              |
| 18    | Gold       | 50,000              |
| 19    | Rainbow    | 75,000              |
| 20    | Diamond    | MAX LEVEL!          |

---

## Scoring Mechanics

### Base Points
- Each click = 1 point (base)

### Multipliers
- Points per click increases with level
- Level 1-8: 1 point per click
- Level 9-12: 2 points per click
- Level 13-16: 3 points per click
- Level 17-19: 5 points per click
- Level 20: 10 points per click

### Visual Feedback
- Brick scales up slightly when clicked (punch effect)
- Particle effects on click
- Level up celebration effect
- Score counter updates in real-time

---

## UI Elements

1. **Score Display** - Top center, shows current points
2. **Level Display** - Shows current level and brick type
3. **Progress Bar** - Shows progress to next level
4. **Click Counter** - Total clicks made
5. **Points Per Click** - Shows current multiplier

---

## Visual Effects

1. **Click Effect** - Brick bounces/pulses
2. **Level Up Effect** - Flash + particles
3. **Size Change** - Smooth scale transition
4. **Color Change** - Smooth color fade
5. **Special Materials** - Shimmer/glow effects

---

## Future Enhancements (Optional)
- Auto-clickers (buy with points)
- Achievements
- Sound effects
- Save/Load progress
- Prestige system (restart for permanent bonuses)
