<div align="center">

# Wacky Warriors

**A 2.5D local-multiplayer arena fighting game built in Unity and C#.**

[![Unity](https://img.shields.io/badge/Unity-2022.3-000000?logo=unity&logoColor=white)](https://unity.com)
[![C#](https://img.shields.io/badge/C%23-239120?logo=csharp&logoColor=white)](https://learn.microsoft.com/dotnet/csharp/)
[![Figma](https://img.shields.io/badge/Figma-UI_Design-F24E1E?logo=figma&logoColor=white)](https://figma.com)
[![Status](https://img.shields.io/badge/Type-Gymnasiearbete-blue)](#about-the-project)

<img src="images/gameplay-nice-garden.png" alt="Wacky Warriors gameplay in the Nice Garden arena" width="900" />

</div>

---

## About the Project

Wacky Warriors is a head-to-head fighting game developed as my **Gymnasiearbete** (Swedish upper-secondary thesis project) at LBS Kreativa Gymnasiet. I worked on it for more than a year, covering gameplay programming, UI design and implementation, animation integration and level setup.

Two players pick a character and an arena, then fight until one health bar is empty or the round timer runs out.

## Features

- **2.5D combat** with punches, kicks and a back-spin kick, each with its own timing and cooldowns.
- **Multiple playable characters** (an alien/soldier and a ninja).
- **Multiple arenas**, including *Old Sea Port* and *Nice Garden*.
- **Local multiplayer** for two players on one machine.
- **Cross-input support** so players can mix input devices.
- **Custom animation system** built with Unity's Animator and Humanoid rigs.
- **Complete game flow:** main menu, character selection, map selection, and match HUD with health bars and a round timer.
- **UI designed in Figma** and implemented with TextMeshPro.

## Screenshots

### Gameplay

<table>
  <tr>
    <td width="50%"><img src="images/gameplay-closeup.png" alt="Close-up of a character with the match HUD" /></td>
    <td width="50%"><img src="images/gameplay-old-sea-port.png" alt="Gameplay in the Old Sea Port arena" /></td>
  </tr>
  <tr>
    <td align="center"><sub>Match HUD with health bars and round timer</sub></td>
    <td align="center"><sub>Old Sea Port arena</sub></td>
  </tr>
</table>

### Menus

<table>
  <tr>
    <td width="50%"><img src="images/character-selection.png" alt="Character selection screen" /></td>
    <td width="50%"><img src="images/map-selection.png" alt="Map selection screen" /></td>
  </tr>
  <tr>
    <td align="center"><sub>Character selection with ready-up for both players</sub></td>
    <td align="center"><sub>Map selection</sub></td>
  </tr>
</table>

## Development

### Unity setup and animation pipeline

<table>
  <tr>
    <td width="50%"><img src="images/unity-main-menu.png" alt="Main menu scene in the Unity editor" /></td>
    <td width="50%"><img src="images/unity-character-rig.png" alt="Humanoid character rig import in Unity" /></td>
  </tr>
  <tr>
    <td align="center"><sub>Main menu scene and UI canvas in the Unity editor</sub></td>
    <td align="center"><sub>Humanoid rig setup for the character models</sub></td>
  </tr>
</table>

Character animations such as walking and fighting stances were sourced from **Mixamo** and integrated through Unity's Animator.

<div align="center">
  <img src="images/mixamo-animations.png" alt="Selecting animations in Mixamo" width="640" />
</div>

### Gameplay code

Player behaviour lives in a `PlayerController` MonoBehaviour that handles movement, facing direction, jumping, and attack state (punching, kicking and back-spin kicking) together with cooldown timers. Other scripts handle level initialisation, player spawning and menu setup.

<div align="center">
  <img src="images/player-controller.png" alt="PlayerController.cs in Visual Studio" width="760" />
</div>

## Tech Stack

| Area | Technology |
| --- | --- |
| Engine | Unity 2022.3 |
| Language | C# |
| UI design | Figma, TextMeshPro |
| Animation | Unity Animator, Mixamo |
| IDE | Visual Studio |
| Rendering | Unity Universal Render Pipeline |

## What I Learned

- Structuring a larger Unity project with scenes, prefabs and scripts over a long development period.
- Building responsive character controls and managing combat state.
- Supporting several input devices in the same game.
- Taking a game from design in Figma through to a playable build.

## Credits

- Character animations from [Mixamo](https://www.mixamo.com).
- *Nice Garden* environment by Vanilla Art Studio.

## Author

**Firat Kaya**

- Portfolio: Firatportfolio.com
- GitHub: [@Firathubgit](https://github.com/Firathubgit)
- LinkedIn: [Firat Kaya](https://www.linkedin.com/in/firat-kaya-baba45267)
