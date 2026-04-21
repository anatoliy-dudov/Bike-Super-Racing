# Bike Super Racing — Architecture Baseline

## Purpose
This document fixes the minimum architectural baseline for the MVP / vertical slice.

It is not a full engine architecture document. Its purpose is to define the minimum runtime model that supports:
- bootstrap;
- main menu flow;
- race flow;
- timer;
- countdown;
- finish and result;
- fast restart;
- local save;
- leaderboard integration point;
- growth without MVP overload.

## Product boundary
MVP includes:
- 1 map: `map_01`;
- 1 bike: `bike_01`;
- 1 leaderboard: `leaderboard_map_01`;
- 1 language;
- local save;
- cloud save stub;
- start → race → finish → result → restart loop.

Everything outside this boundary must not complicate the first implementation.

## Mandatory scenes
- `00_Bootstrap`;
- `01_MainMenu`;
- `02_Race`;
- `90_TestGameplay`;
- `91_TestUI`.

## Runtime entry model
### `00_Bootstrap`
Responsibilities:
- initialize core services;
- register config sources;
- initialize save layer;
- initialize localization layer;
- initialize audio settings layer;
- prepare app state;
- route player to `01_MainMenu`.

### `01_MainMenu`
Responsibilities:
- expose main menu entry points;
- allow entry into race flow;
- allow leaderboard/settings access;
- read player profile and display current available shell state.

### `02_Race`
Responsibilities:
- create race session;
- spawn bike and map for current selection;
- manage countdown, timer and finish;
- show result;
- allow restart or exit.

## Core architectural principle
The MVP implementation must follow this rule:

**state flow and gameplay flow are first-class citizens; decorative systems are not.**

This means:
- race state transitions must be explicit;
- timer and result must have one source of truth;
- restart must reset all required systems predictably;
- UI must react to state, not invent state.

## Domain layer
Mandatory domain entities:
- `MapDefinition`;
- `BikeDefinition`;
- `BikeColorDefinition`;
- `PlayerProfile`;
- `RaceSession`;
- `RaceResult`;
- `GameConfig`.

### Intent of each entity
- `MapDefinition` — static map metadata and references for one playable map;
- `BikeDefinition` — bike identity, references and basic gameplay parameters;
- `BikeColorDefinition` — player-facing bike color selection metadata;
- `PlayerProfile` — current player selections and best local results;
- `RaceSession` — runtime data for one active race attempt;
- `RaceResult` — immutable output of one completed attempt;
- `GameConfig` — root references and global settings used by the app.

## Service baseline
### Required service contracts
- `IAppStateService` — global app state routing;
- `ISceneLoader` — scene transitions;
- `IConfigService` — load and expose config assets;
- `IPlayerProfileService` — current player-facing data and selections;
- `ISaveService` — local persistence abstraction;
- `ILeaderboardService` — leaderboard write/read abstraction;
- `IRaceSessionService` — current race session orchestration;
- `IRaceTimerService` — race timer control and access;
- `ICountdownService` — countdown sequence orchestration;
- `IRaceResultService` — finish processing and result building;
- `IAudioSettingsService` — sound/music settings abstraction;
- `ILocalizationService` — text localization abstraction;
- `ITimeService` — general time provider.

### Required infrastructure implementations for MVP
- `SceneLoader`;
- `AppStateService`;
- `ConfigService`;
- `PlayerProfileService`;
- `LocalSaveService`;
- `CloudSaveStubService`;
- `TimeService`.

## Recommended state model
### App-level states
Minimum app flow:
- Bootstrap;
- MainMenu;
- Race;
- Pause;
- Result.

### Race-level states
Minimum race states:
- `EnterRaceScene`;
- `PreStart`;
- `Countdown`;
- `RaceActive`;
- `RaceFinished`;
- `ResultPresentation`;
- `RestartRequested`.

These states must be explicit. Avoid hidden state spread across unrelated MonoBehaviours.

## Race session baseline
A race session must minimally store:
- selected map ID;
- selected bike ID;
- selected color ID;
- session start marker;
- timer running state;
- finish state;
- final race time.

Recommended canonical selections for MVP default flow:
- map: `map_01`;
- bike: `bike_01`;
- color: `color_red`.

## Result model baseline
A race result must minimally contain:
- map ID;
- bike ID;
- color ID;
- total time;
- timestamp or save marker;
- `isNewBest` flag for local comparison.

The result model should be serializable without coupling to UI.

## Save baseline
Local save must persist at minimum:
- selected bike;
- selected color;
- best result for `map_01`;
- user settings needed for audio or minimal shell state.

Cloud save is a stub in MVP and must not block release.

## Leaderboard baseline
Leaderboard implementation must support:
- submitting result for `leaderboard_map_01`;
- reading leaderboard for `map_01`;
- failing gracefully when leaderboard backend is unavailable.

If platform integration is not finished, code must allow local development without hard dependency on the live leaderboard backend.

## UI architecture baseline
UI must stay thin.

Mandatory runtime UI classes:
- `MainMenuScreen`;
- `SettingsPopup`;
- `LeaderboardPopup`;
- `RaceHudView`;
- `CountdownWidget`;
- `ResultPanel`.

### UI rule
UI listens to state and displays data.
UI must not own gameplay truth.

This is especially important for:
- race timer;
- finish state;
- result generation;
- restart logic.

## Config baseline
The following config assets are mandatory:
- `CFG_Game_Main`;
- `CFG_Map_Map01`;
- `CFG_Bike_Bike01`;
- `CFG_Color_Red`.

### Expected config intent
- `CFG_Game_Main` — root references and global settings;
- `CFG_Map_Map01` — map data, scene/prefab references, leaderboard key;
- `CFG_Bike_Bike01` — bike references and baseline stats;
- `CFG_Color_Red` — visual selection data for bike presentation.

## Dependency rules
1. Domain must not depend on UI.
2. UI must not calculate gameplay truth.
3. Infrastructure may implement service contracts but must not rename them.
4. Restart flow must reset gameplay state through service orchestration, not through scattered ad hoc object mutations.
5. New services must be justified by clear responsibility, not created per screen or per temporary feature.

## Explicit non-goals for MVP architecture
The first implementation does not need:
- deep economy systems;
- inventory systems;
- live-ops framework;
- multi-mode architecture;
- generalized content pipeline for many tracks before MVP works;
- heavy abstraction for hypothetical future systems.

## Minimum technical checklist for first production pass
- scene bootstrap works;
- menu enters race;
- race session starts correctly;
- countdown is synchronized with control opening and timer start;
- finish event stops timer correctly;
- result object is created correctly;
- best local time comparison works;
- restart resets race deterministically;
- exit returns to menu cleanly.

## Baseline rule for future changes
If a new feature changes scene flow, naming, runtime state, save schema, leaderboard schema or config schema, this document and `Docs/architecture/naming-convention.md` must be updated first.

This file is the minimum architecture contract for the MVP phase.
