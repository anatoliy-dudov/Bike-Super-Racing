# Bike Super Racing — Naming Convention

## Purpose
This document fixes the canonical naming baseline for code, content, scenes, configs, IDs, prefabs, UI and documentation.

The goal is to avoid parallel names for the same entity and to ensure that design, code, content and documentation use one shared vocabulary.

## Core rules
1. One gameplay entity must have one canonical name.
2. Documentation names, config names, code names, prefab names and UI labels must describe the same entity without alternative synonyms.
3. New entities must be added to this document before they are created in code or content.
4. IDs use `snake_case`.
5. Class names use `PascalCase`.
6. Interfaces use `I` prefix and `PascalCase`.
7. Scene names use numeric prefix plus `PascalCase` name.
8. Config assets use `CFG_` prefix.
9. Prefabs use `PREF_` prefix.
10. Sprites use `SPR_` prefix.
11. Music clips use `MUS_` prefix.
12. Sound effects use `SFX_` prefix.
13. Materials use `MAT_` prefix.
14. Animation clips and controllers use `AN_` prefix.
15. Alternative names for the same entity are forbidden in code, UI, assets and documentation.

## Canonical scene names
- `00_Bootstrap` — service bootstrap and app initialization scene;
- `01_MainMenu` — main menu, entry flow, garage entry point, leaderboard entry point, settings entry point;
- `02_Race` — active race scene for playable track session;
- `90_TestGameplay` — isolated gameplay test scene;
- `91_TestUI` — isolated UI test scene.

## Canonical IDs for MVP
- `map_01` — first playable track for MVP;
- `bike_01` — first playable bike for MVP;
- `color_red` — first canonical bike color for MVP;
- `leaderboard_map_01` — leaderboard key for the first playable track.

## Canonical config names
- `CFG_Game_Main` — root game configuration;
- `CFG_Map_Map01` — config for `map_01`;
- `CFG_Bike_Bike01` — config for `bike_01`;
- `CFG_Color_Red` — config for `color_red`.

## Canonical domain entities
- `MapDefinition`;
- `BikeDefinition`;
- `BikeColorDefinition`;
- `PlayerProfile`;
- `RaceSession`;
- `RaceResult`;
- `GameConfig`.

## Canonical services
- `IAppStateService`;
- `ISceneLoader`;
- `IConfigService`;
- `IPlayerProfileService`;
- `ISaveService`;
- `ILeaderboardService`;
- `IRaceSessionService`;
- `IRaceTimerService`;
- `ICountdownService`;
- `IRaceResultService`;
- `IAudioSettingsService`;
- `ILocalizationService`;
- `ITimeService`.

## Canonical runtime classes
- `Bootstrapper`;
- `SceneLoader`;
- `AppStateService`;
- `ConfigService`;
- `PlayerProfileService`;
- `LocalSaveService`;
- `CloudSaveStubService`;
- `TimeService`.

## Canonical UI classes
- `MainMenuScreen`;
- `SettingsPopup`;
- `LeaderboardPopup`;
- `RaceHudView`;
- `CountdownWidget`;
- `ResultPanel`.

## Asset naming rules
### Scenes
- `00_Bootstrap.unity`;
- `01_MainMenu.unity`;
- `02_Race.unity`;
- `90_TestGameplay.unity`;
- `91_TestUI.unity`.

### Prefabs
- `PREF_MainMenuScreen`;
- `PREF_RaceHudView`;
- `PREF_CountdownWidget`;
- `PREF_ResultPanel`;
- `PREF_Bike_Bike01`;
- `PREF_Map_Map01`.

### Sprites
- `SPR_UI_Button_Primary`;
- `SPR_UI_Panel_Result`;
- `SPR_Bike_Bike01_Idle`;
- `SPR_Map_Map01_Tile_01`.

### Audio
- `MUS_Menu_MainLoop`;
- `MUS_Race_Loop_01`;
- `SFX_Countdown_Beep`;
- `SFX_Race_Finish`;
- `SFX_UI_Click`.

### Animation
- `AN_Bike_Bike01_Idle`;
- `AN_Countdown_Pulse`;
- `AN_ResultPanel_Show`.

## UI text vs internal names
Player-facing labels may be localized and readable for players.
Internal names must remain canonical and stable.

Example:
- internal map ID: `map_01`;
- internal config: `CFG_Map_Map01`;
- internal prefab: `PREF_Map_Map01`;
- player-facing label: `Map 1` or localized equivalent.

## Forbidden patterns
- using `Track01`, `Level1`, `RaceMap1` and `map_01` for the same entity;
- using `PlayerBike`, `Bike01`, `Moto01` and `bike_01` in parallel;
- naming one service by domain and another by screen-specific wording for the same responsibility;
- changing labels in documentation without changing code references and configs.

## Change management
Any new map, bike, color, service, UI screen, config or leaderboard key must be added here first, then created in code and content.

This file is the source of truth for naming across the project.
