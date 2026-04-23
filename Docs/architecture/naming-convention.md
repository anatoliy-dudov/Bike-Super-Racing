# Bike Super Racing — Naming Convention

## 1. Purpose

This document defines the mandatory naming baseline for Bike Super Racing.

It is the single source of truth for naming in:
- code;
- scenes;
- ScriptableObject configs;
- prefabs;
- sprites;
- audio assets;
- materials;
- animations;
- UI assets;
- documentation.

If a name is not fixed in this document, it must not be introduced into the project before this document is updated.

---

## 2. Global Rules

### 2.1. General Rules
- all technical names use English only;
- Cyrillic is forbidden in technical names;
- spaces are forbidden in technical names;
- one entity must have one canonical name;
- the same entity must use the same name in code, content, and documentation;
- a new entity is fixed in this document first, then created in the project.

### 2.2. Technical Names Include
- class names;
- interface names;
- method names;
- property names;
- scene names;
- prefab names;
- sprite names;
- config names;
- entity IDs;
- folder names;
- localization keys;
- ScriptableObject names.

---

## 3. Code Style

### 3.1. C# Naming Rules
- classes: PascalCase;
- interfaces: PascalCase with `I` prefix;
- methods: PascalCase;
- public properties: PascalCase;
- private fields: `_camelCase`;
- local variables: `camelCase`;
- enums: PascalCase;
- enum values: PascalCase.

### 3.2. ID Rules
- lowercase only;
- words separated by `_`;
- no spaces;
- no dashes;
- short and predictable format.

Examples:
- `map_01`;
- `bike_01`;
- `color_red`;
- `leaderboard_map_01`.

---

## 4. Canonical Project Names

### 4.1. Project Name
- display name: `Bike Super Racing`;
- technical name: `BikeSuperRacing`.

### 4.2. Canonical Scene Names
- `00_Bootstrap`
- `01_MainMenu`
- `02_Race`
- `90_TestGameplay`
- `91_TestUI`

### 4.3. Canonical MVP IDs
- `map_01`
- `bike_01`
- `color_red`
- `leaderboard_map_01`

### 4.4. Reserved Future IDs
- maps: `map_02`, `map_03`, ...;
- bikes: `bike_02`, `bike_03`, ...;
- colors: `color_yellow`, `color_black`, `color_purple`, `color_pink`, ...;
- leaderboards: `leaderboard_map_02`, `leaderboard_map_03`, ... .

---

## 5. Canonical Domain Entities

The project uses the following canonical domain names:
- `MapDefinition`
- `BikeDefinition`
- `BikeColorDefinition`
- `PlayerProfile`
- `RaceSession`
- `RaceResult`
- `GameConfig`
- `RaceState`

Forbidden alternatives:
- `TrackDefinition` instead of `MapDefinition`;
- `MotorcycleDefinition` instead of `BikeDefinition`;
- `UserProfile` instead of `PlayerProfile`;
- `RaceData` instead of `RaceSession` or `RaceResult`;
- `RacePhase` instead of `RaceState`.

---

## 6. Canonical Services

The project uses the following canonical service names:
- `IAppStateService`
- `ISceneLoader`
- `IConfigService`
- `IPlayerProfileService`
- `ISaveService`
- `ILeaderboardService`
- `IRaceSessionService`
- `IRaceTimerService`
- `ICountdownService`
- `IRaceResultService`
- `IAudioSettingsService`
- `ILocalizationService`
- `ITimeService`

### 6.1. Canonical Runtime Implementations
- `Bootstrapper`
- `SceneLoader`
- `AppStateService`
- `ConfigService`
- `PlayerProfileService`
- `LocalSaveService`
- `CloudSaveStubService`
- `TimeService`
- `RaceSessionService`
- `RaceTimerService`
- `CountdownService`
- `RaceResultService`
- `RaceFlowController`
- `FinishTrigger`

Additional implementations are allowed only if the name clearly reflects real responsibility.

Examples:
- `LocalLeaderboardService`;
- `YandexLeaderboardService`;
- `JsonLocalSaveService`.

---

## 7. Canonical UI Classes

The project uses the following canonical UI classes:
- `MainMenuScreen`
- `SettingsPopup`
- `LeaderboardPopup`
- `RaceHudView`
- `CountdownWidget`
- `ResultPanel`

Forbidden alternatives without updating this document:
- `MainScreen` instead of `MainMenuScreen`;
- `OptionsPopup` instead of `SettingsPopup`;
- `HudView` instead of `RaceHudView`;
- `ResultScreen` instead of `ResultPanel`.

---

## 8. Canonical Config Names

The following configs are fixed for MVP:
- `CFG_Game_Main`
- `CFG_Map_Map01`
- `CFG_Bike_Bike01`
- `CFG_Color_Red`

### 8.1. Future Config Patterns
- maps: `CFG_Map_Map02`, `CFG_Map_Map03`, ...;
- bikes: `CFG_Bike_Bike02`, ...;
- colors: `CFG_Color_Yellow`, `CFG_Color_Black`, `CFG_Color_Purple`, `CFG_Color_Pink`, ...;
- leaderboard configs if needed: `CFG_Leaderboard_Map01`, ...;
- UI configs: `CFG_UI_MainMenu`, ...;
- audio configs: `CFG_Audio_Main`.

---

## 9. Asset Naming Rules

### 9.1. Mandatory Prefixes
- `PREF_` — prefab;
- `SPR_` — sprite;
- `MUS_` — music;
- `SFX_` — sound effect;
- `MAT_` — material;
- `AN_` — animation;
- `CFG_` — config.

### 9.2. Prefab Pattern
Format:
`PREF_[Category]_[Name]`

Examples:
- `PREF_Bike_Bike01`
- `PREF_UI_MainMenuScreen`
- `PREF_UI_ResultPanel`
- `PREF_UI_RaceHudView`
- `PREF_UI_CountdownWidget`

### 9.3. Sprite Pattern
Format:
`SPR_[Category]_[Name]`

Examples:
- `SPR_Bike_Bike01_Body`
- `SPR_Bike_Bike01_WheelFront`
- `SPR_Bike_Bike01_WheelRear`
- `SPR_Rider_Bike01_Base`
- `SPR_Map_Map01_Tile_Ground_A`
- `SPR_Map_Map01_BG_Sky`
- `SPR_Map_Map01_FinishBanner`
- `SPR_UI_Icon_Settings`
- `SPR_UI_Button_Primary`
- `SPR_UI_Icon_DailyReward`

### 9.4. Music Pattern
Format:
`MUS_[Name]`

Examples:
- `MUS_MainMenu`
- `MUS_RaceLoop`

### 9.5. SFX Pattern
Format:
`SFX_[Name]`

Examples:
- `SFX_ButtonClick`
- `SFX_CountdownTick`
- `SFX_RaceFinish`

### 9.6. Material Pattern
Format:
`MAT_[Name]`

Examples:
- `MAT_Bike_Default`
- `MAT_UI_Default`

### 9.7. Animation Pattern
Format:
`AN_[Name]`

Examples:
- `AN_Bike_Bike01_Idle`
- `AN_Bike_Bike01_Drive`
- `AN_UI_ResultPanel_Show`

---

## 10. Folder Names

### 10.1. Root Project Folders
Inside `Assets/_Project/`, only the following root folders are allowed:
- `Bootstrap`
- `Core`
- `Domain`
- `Application`
- `Infrastructure`
- `Gameplay`
- `UI`
- `Configs`
- `Content`
- `Scenes`
- `Tests`
- `Editor`

### 10.2. Nested Folders
Nested folders use PascalCase.

Examples:
- `Assets/_Project/Domain/Maps`
- `Assets/_Project/Infrastructure/Save/Local`
- `Assets/_Project/UI/Screens/MainMenu`
- `Assets/_Project/Gameplay/RaceFlow`
- `Assets/_Project/Gameplay/Finish`

Forbidden examples:
- `main menu`
- `bike_scripts`
- `new folder`
- `misc`

---

## 11. Localization Key Rules

Even with one language in MVP, strings must use a unified key pattern.

Format:
`[section].[screen_or_group].[name]`

Examples:
- `menu.main.play`
- `menu.main.leaderboards`
- `settings.audio.music_volume`
- `settings.audio.sfx_volume`
- `result.title.finish`
- `result.button.retry`
- `countdown.value.three`

---

## 12. Canonical Config Field Names

### 12.1. `MapDefinition`
- `Id`
- `DisplayName`
- `SceneName`
- `LeaderboardId`
- `IsEnabled`

### 12.2. `BikeDefinition`
- `Id`
- `DisplayName`
- `Acceleration`
- `MaxSpeed`
- `Handling`
- `IsEnabled`

### 12.3. `BikeColorDefinition`
- `Id`
- `DisplayName`
- `ColorHex`
- `IsEnabled`

### 12.4. `PlayerProfile`
- `SelectedBikeId`
- `SelectedColorId`
- `BestTimesByMap`
- `MusicVolume`
- `SfxVolume`

### 12.5. `RaceState`
- `EnterRaceScene`
- `PreStart`
- `Countdown`
- `RaceActive`
- `RaceFinished`
- `ResultPresentation`
- `RestartRequested`
- `Pause`

---

## 13. Forbidden Practices

The following are forbidden:
- different names for the same entity;
- local asset renaming without documentation update;
- shortcuts not fixed in this document;
- names such as:
  - `bike_new`;
  - `bike_final`;
  - `bike_final2`;
  - `new_button`;
  - `test_map_real`;
- Russian names for technical entities;
- mixing `Map` and `Track` for the same domain entity.

---

## 14. New Entity Introduction Order

When a new entity is added, the following order is mandatory:
1. define entity type;
2. define canonical name;
3. define ID and naming pattern;
4. update this document;
5. create the entity in code, content, and documentation;
6. use only the fixed name.

Breaking this order is an architectural error.

---

## 15. MVP Registry

### 15.1. Scenes
- `00_Bootstrap`
- `01_MainMenu`
- `02_Race`
- `90_TestGameplay`
- `91_TestUI`

### 15.2. Configs
- `CFG_Game_Main`
- `CFG_Map_Map01`
- `CFG_Bike_Bike01`
- `CFG_Color_Red`

### 15.3. IDs
- `map_01`
- `bike_01`
- `color_red`
- `leaderboard_map_01`

### 15.4. Base Art Assets for MVP
- `SPR_Bike_Bike01_Body`
- `SPR_Bike_Bike01_WheelFront`
- `SPR_Bike_Bike01_WheelRear`
- `SPR_Rider_Bike01_Base`
- `SPR_Map_Map01_Tile_Ground_A`
- `SPR_Map_Map01_BG_Sky`
- `SPR_Map_Map01_FinishBanner`
- `SPR_UI_Button_Primary`
- `SPR_UI_Button_Secondary`
- `SPR_UI_Panel_Base`
- `SPR_UI_Icon_Settings`
- `SPR_UI_Icon_Leaderboard`
- `SPR_UI_Icon_DailyReward`
- `SPR_Brand_GameIcon`

---

## 16. Status

This document is mandatory for:
- programmer;
- artist;
- technical designer;
- any contributor creating code, content, or documentation.

Any deviation is allowed only after this document is explicitly updated.
