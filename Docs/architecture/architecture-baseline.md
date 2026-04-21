# Bike Super Racing — Architecture Baseline

## 1. Purpose

This document fixes the mandatory architecture baseline for Bike Super Racing.

It defines:
- the first playable vertical MVP boundary;
- the target runtime model;
- mandatory project invariants;
- growth rules from MVP to the wider game scope;
- the production critical path.

This document is mandatory for programmer and artist.

---

## 2. Project Identity

### 2.1. Name
- display name: `Bike Super Racing`;
- technical name: `BikeSuperRacing`.

### 2.2. Genre
2D arcade competitive bike racing game.

### 2.3. Core Reference
Main reference: `Excite Bike`.

### 2.4. Platform
- Unity;
- browser runtime;
- target publishing platform: Yandex Games.

---

## 3. Product Baseline

### 3.1. Core Fantasy
The player enters a race quickly, feels control over the bike, clears a short readable track, sees a result immediately, and wants one more attempt to improve time.

### 3.2. Main Product Bet
The project is built around:
- control feel;
- readable track;
- short retry loop;
- fast restart;
- competition through time improvement.

### 3.3. Player Motivations
- mastery;
- competition;
- short-session replayability.

---

## 4. Vertical MVP Boundary

### 4.1. Must Have
The nearest milestone is a vertical MVP containing:
- 1 map: `map_01`;
- 1 bike: `bike_01`;
- 1 bike color: `color_red`;
- 1 leaderboard: `leaderboard_map_01`;
- 1 language;
- local save;
- cloud save stub;
- bootstrap;
- basic menu flow;
- countdown;
- timer;
- finish and result;
- fast restart;
- minimal HUD.

### 4.2. Should Have
Allowed only after the full Must Have loop is stable:
- minor UI polish;
- slightly richer result presentation;
- extra visual polish that does not affect readability or schedule.

### 4.3. Later
Outside the current milestone:
- full 3-map implementation;
- second bike;
- full 5-color selection in UI;
- multi-language support;
- full cloud save integration;
- daily rewards implementation;
- monetization;
- multiplayer;
- backend systems.

Everything outside Must Have must not complicate the first implementation.

---

## 5. Full Target Product Growth

The architecture must support future growth to:
- 3 maps;
- 2 bikes;
- 5 bike colors:
  - `color_red`
  - `color_yellow`
  - `color_black`
  - `color_purple`
  - `color_pink`;
- one leaderboard per map;
- audio settings;
- language switching;
- daily reward system;
- future platform integration.

This growth must happen without rewriting the base architecture.

---

## 6. Mandatory Invariants

### 6.1. Data-Driven Core
Even with one map, one bike, and one color, runtime entities must come from configs, not hardcoded ad hoc logic.

### 6.2. One Naming Baseline
All names must stay synchronized across:
- code;
- assets;
- scenes;
- configs;
- prefabs;
- documentation.

### 6.3. Platform Isolation
Gameplay must not depend directly on platform SDK calls.

### 6.4. Save Isolation
UI and gameplay must not know the concrete persistence implementation.

### 6.5. UI Isolation
UI presents state and data. UI does not own gameplay truth.

### 6.6. Growth Without Rebuild
Adding a second map, second bike, extra colors, or extra leaderboard IDs must not require a redesign of the runtime core.

---

## 7. Canonical MVP Registry

### 7.1. Scene Names
- `00_Bootstrap`
- `01_MainMenu`
- `02_Race`
- `90_TestGameplay`
- `91_TestUI`

### 7.2. IDs
- `map_01`
- `bike_01`
- `color_red`
- `leaderboard_map_01`

### 7.3. Config Names
- `CFG_Game_Main`
- `CFG_Map_Map01`
- `CFG_Bike_Bike01`
- `CFG_Color_Red`

### 7.4. Domain Entities
- `MapDefinition`
- `BikeDefinition`
- `BikeColorDefinition`
- `PlayerProfile`
- `RaceSession`
- `RaceResult`
- `GameConfig`

### 7.5. Service Contracts
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

### 7.6. Base Runtime Implementations
- `Bootstrapper`
- `SceneLoader`
- `AppStateService`
- `ConfigService`
- `PlayerProfileService`
- `LocalSaveService`
- `CloudSaveStubService`
- `TimeService`

### 7.7. Base UI Components
- `MainMenuScreen`
- `SettingsPopup`
- `LeaderboardPopup`
- `RaceHudView`
- `CountdownWidget`
- `ResultPanel`

---

## 8. Layered Architecture

The project uses layered modular architecture.

### 8.1. `Bootstrap`
Responsibilities:
- application entry;
- service initialization;
- config registration;
- startup routing.

### 8.2. `Core`
Responsibilities:
- interfaces;
- shared abstractions;
- common primitives;
- state machine helpers.

### 8.3. `Domain`
Responsibilities:
- game entities;
- config models;
- player profile model;
- race session and race result model.

### 8.4. `Application`
Responsibilities:
- use cases;
- orchestration;
- facades;
- coordination between layers.

### 8.5. `Infrastructure`
Responsibilities:
- local save;
- cloud save stub;
- leaderboard implementation;
- audio;
- localization;
- time provider;
- future platform bridge.

### 8.6. `Gameplay`
Responsibilities:
- bike runtime;
- map runtime;
- countdown;
- timer;
- finish;
- race flow;
- restart flow.

### 8.7. `UI`
Responsibilities:
- screens;
- popups;
- widgets;
- HUD;
- result presentation.

---

## 9. Dependency Rules

Allowed dependencies:
- `Application` depends on `Core` and `Domain`;
- `Infrastructure` depends on `Core` and `Domain`;
- `Gameplay` depends on `Core`, `Domain`, `Application`;
- `UI` depends on `Core` and `Application`;
- `Bootstrap` depends on `Application`, `Infrastructure`, `UI`.

Forbidden dependencies:
- `Domain` -> `Infrastructure`;
- `Domain` -> `UI`;
- `UI` -> concrete save implementations;
- `Gameplay` -> platform SDK directly;
- `UI` -> platform SDK directly.

---

## 10. Scene Baseline

### 10.1. `00_Bootstrap`
Responsibilities:
- initialize runtime context;
- initialize services;
- load config references;
- load player profile;
- route to `01_MainMenu`.

### 10.2. `01_MainMenu`
Responsibilities:
- main entry point;
- start race flow;
- show settings access;
- show leaderboard access;
- keep visible placeholders for Garage and Daily Rewards without implementing full systems in MVP.

### 10.3. `02_Race`
Responsibilities:
- create race session;
- load `map_01`;
- spawn `bike_01`;
- apply `color_red`;
- run countdown;
- run timer;
- detect finish;
- create result;
- allow restart or exit.

### 10.4. `90_TestGameplay`
Responsibilities:
- isolated gameplay validation.

### 10.5. `91_TestUI`
Responsibilities:
- isolated UI validation.

---

## 11. User Flow Model

The first playable version must support this flow:
1. start game;
2. load `00_Bootstrap`;
3. route to `01_MainMenu`;
4. press race start;
5. auto-select `map_01`;
6. auto-select `bike_01`;
7. auto-apply `color_red`;
8. load `02_Race`;
9. run 5-second countdown;
10. open control and timer together;
11. finish race;
12. show time;
13. save result;
14. show best local result and leaderboard entry point;
15. allow fast restart.

---

## 12. Save, Leaderboard, and Localization Contracts

### 12.1. Save Baseline
Mandatory implementations:
- `LocalSaveService`;
- `CloudSaveStubService`.

`CloudSaveStubService` exists as a future extension point and must not block MVP.

Local save must persist at minimum:
- selected bike;
- selected color;
- best local time for `map_01`;
- audio settings.

### 12.2. Leaderboard Baseline
The architecture must support a dedicated map leaderboard key:
- `leaderboard_map_01`.

For MVP, a local-first implementation is acceptable as long as the project keeps `ILeaderboardService` as the integration point.

### 12.3. Localization Baseline
MVP supports one language.
Even with one language, strings must go through `ILocalizationService` and localization keys.

### 12.4. Audio Baseline
Mandatory settings:
- music volume;
- SFX volume.

They must be stored through the player profile and save layer.

---

## 13. Minimal Config Baseline

Mandatory config assets:
- `CFG_Game_Main`
- `CFG_Map_Map01`
- `CFG_Bike_Bike01`
- `CFG_Color_Red`

### 13.1. Required `MapDefinition` Fields
- `Id`
- `DisplayName`
- `SceneName`
- `LeaderboardId`
- `IsEnabled`

### 13.2. Required `BikeDefinition` Fields
- `Id`
- `DisplayName`
- `Acceleration`
- `MaxSpeed`
- `Handling`
- `IsEnabled`

### 13.3. Required `BikeColorDefinition` Fields
- `Id`
- `DisplayName`
- `ColorHex`
- `IsEnabled`

---

## 14. Critical Path for Production

The current production critical path is:
1. project baseline and bootstrap;
2. menu flow;
3. race flow;
4. countdown;
5. timer;
6. finish and result;
7. restart;
8. local save;
9. minimal HUD;
10. QA validation of the full vertical loop.

Anything outside this path must not delay MVP.

---

## 15. First Vertical MVP Acceptance Criteria

The first playable vertical MVP is accepted when:
- project starts from `00_Bootstrap`;
- routes cleanly to `01_MainMenu`;
- race starts from menu;
- `RaceSession` is created correctly;
- countdown and timer are synchronized with control opening;
- finish stops the timer once;
- `RaceResult` is created correctly;
- best local time is saved;
- audio settings are saved;
- restart resets race state deterministically;
- all names follow canonical naming baseline.

---

## 16. Implementation Order

Implementation must follow this order:
1. repository and Unity structure;
2. scenes;
3. asmdef;
4. naming baseline;
5. domain models;
6. service interfaces;
7. bootstrap;
8. configs;
9. profile and save;
10. main menu;
11. race;
12. countdown and timer;
13. finish and result;
14. local leaderboard;
15. polish inside MVP scope only.

Skipping to content expansion or post-MVP systems before this order is complete is not allowed.

---

## 17. Mandatory Baseline Documents

The following files are mandatory and authoritative:
- `Docs/architecture/naming-convention.md`
- `Docs/architecture/project-structure.md`
- `Docs/architecture/architecture-baseline.md`
- `Docs/art/art-direction-mvp.md`
- `Docs/art/asset-list-mvp.md`

If implementation conflicts with these documents, the documents are considered correct until they are explicitly updated.

---

## 18. Change Rule

If a new feature changes naming, scene flow, runtime state, save schema, leaderboard schema, or config schema, the baseline documents must be updated first.

Breaking this rule is an architectural error.
