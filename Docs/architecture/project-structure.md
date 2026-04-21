# Bike Super Racing — Project Structure Baseline

## Purpose
This document fixes the target folder structure for the Unity project and the minimum documentation structure required for MVP production.

The structure is designed to:
- keep runtime code readable;
- keep assets searchable;
- reduce name drift between code and content;
- support MVP first and future scale second.

## Root structure
```text
/Assets
/Docs
/Packages
/ProjectSettings
```

## Required documentation structure
```text
/Docs
  /architecture
    naming-convention.md
    project-structure.md
    architecture-baseline.md
  /design
    game-vision.md
    core-gameplay-loop.md
    onboarding-teaching-strategy.md
    race-flow-and-hud.md
    mvp-scope-and-feature-priority-matrix.md
```

## Recommended Unity structure
```text
/Assets
  /_Project
    /Art
      /Environment
      /Bike
      /UI
      /VFX
    /Audio
      /Music
      /SFX
    /Config
      /Game
      /Maps
      /Bikes
      /Colors
    /Localization
    /Materials
    /Prefabs
      /Core
      /Environment
      /Gameplay
      /UI
    /Scenes
    /Scripts
      /Bootstrap
      /Domain
      /Application
      /Infrastructure
      /Gameplay
      /UI
      /Tests
    /ScriptableObjects
    /Sprites
      /Bike
      /Map
      /UI
    /UI
      /Fonts
      /Layouts
      /Widgets
    /VFX
```

## Scene folder
```text
/Assets/_Project/Scenes
  00_Bootstrap.unity
  01_MainMenu.unity
  02_Race.unity
  90_TestGameplay.unity
  91_TestUI.unity
```

## Config folder
```text
/Assets/_Project/Config
  /Game
    CFG_Game_Main.asset
  /Maps
    CFG_Map_Map01.asset
  /Bikes
    CFG_Bike_Bike01.asset
  /Colors
    CFG_Color_Red.asset
```

## Prefab folder
```text
/Assets/_Project/Prefabs
  /Core
  /Environment
  /Gameplay
    PREF_Bike_Bike01.prefab
    PREF_Map_Map01.prefab
  /UI
    PREF_MainMenuScreen.prefab
    PREF_RaceHudView.prefab
    PREF_CountdownWidget.prefab
    PREF_ResultPanel.prefab
```

## Scripts folder
The scripts layer should separate domain, orchestration, infrastructure and presentation.

```text
/Assets/_Project/Scripts
  /Bootstrap
    Bootstrapper.cs
  /Domain
    MapDefinition.cs
    BikeDefinition.cs
    BikeColorDefinition.cs
    PlayerProfile.cs
    RaceSession.cs
    RaceResult.cs
    GameConfig.cs
  /Application
    Services
      IAppStateService.cs
      ISceneLoader.cs
      IConfigService.cs
      IPlayerProfileService.cs
      ISaveService.cs
      ILeaderboardService.cs
      IRaceSessionService.cs
      IRaceTimerService.cs
      ICountdownService.cs
      IRaceResultService.cs
      IAudioSettingsService.cs
      ILocalizationService.cs
      ITimeService.cs
  /Infrastructure
    SceneLoader.cs
    AppStateService.cs
    ConfigService.cs
    PlayerProfileService.cs
    LocalSaveService.cs
    CloudSaveStubService.cs
    TimeService.cs
  /Gameplay
    /Race
    /Bike
    /Map
    /Countdown
    /Finish
  /UI
    MainMenuScreen.cs
    SettingsPopup.cs
    LeaderboardPopup.cs
    RaceHudView.cs
    CountdownWidget.cs
    ResultPanel.cs
```

## UI folder intent
The UI layer for MVP should stay thin.

Recommended split:
```text
/Assets/_Project/UI
  /Layouts
  /Widgets
  /Screens
  /Popups
```

Use this intent mapping:
- `Screens` — full-screen interfaces such as main menu;
- `Popups` — modal overlays such as settings and leaderboard;
- `Widgets` — reusable pieces such as countdown or timer block;
- `Layouts` — shared canvas layouts and structure assets.

## Audio folder intent
```text
/Assets/_Project/Audio
  /Music
  /SFX
```

Naming examples:
- `MUS_Menu_MainLoop`;
- `MUS_Race_Loop_01`;
- `SFX_Countdown_Beep`;
- `SFX_Race_Finish`;
- `SFX_UI_Click`.

## Art folder intent
```text
/Assets/_Project/Art
  /Environment
  /Bike
  /UI
  /VFX
```

Use this split to prevent environment, bike and UI assets from mixing in one flat folder.

## MVP implementation priority inside structure
The following folders are critical first:
- `/Assets/_Project/Scenes`;
- `/Assets/_Project/Config`;
- `/Assets/_Project/Prefabs/Gameplay`;
- `/Assets/_Project/Prefabs/UI`;
- `/Assets/_Project/Scripts/Bootstrap`;
- `/Assets/_Project/Scripts/Application`;
- `/Assets/_Project/Scripts/Infrastructure`;
- `/Assets/_Project/Scripts/Gameplay`;
- `/Assets/_Project/Scripts/UI`.

The following folders may stay minimal at project start:
- `/Assets/_Project/VFX`;
- `/Assets/_Project/Localization`;
- `/Assets/_Project/Materials`;
- `/Assets/_Project/Tests`.

## Rules for adding new content
1. Create the canonical name in `Docs/architecture/naming-convention.md` first.
2. Add config and runtime references next.
3. Create prefab and content asset after naming is fixed.
4. Keep folder depth meaningful but not excessive.
5. Do not create duplicate folders with overlapping responsibilities.

## Anti-patterns
The following patterns are forbidden:
- flat root-level dumping of all scripts into one folder;
- multiple folders for the same responsibility such as `/GameplayUI`, `/UIGameplay`, `/HUD` with overlapping meaning;
- mixed content folders where map art, UI art and bike art live together;
- temporary names like `New Folder`, `Test`, `FinalFinal`, `Scene1`, `Level1`.

## Minimum repo expectation for the next production step
The next production-ready baseline should include:
- all required docs in `/Docs`;
- Unity scene stubs with canonical names;
- config assets for game, map, bike and color;
- code folders aligned with service names from architecture baseline;
- UI prefab placeholders with canonical names.

This structure is the official baseline until replaced by a newer approved version.
