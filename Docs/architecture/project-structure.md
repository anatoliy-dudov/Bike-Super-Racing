# Bike Super Racing — Project Structure

## 1. Purpose

This document fixes the repository structure and Unity project structure for Bike Super Racing.

It is mandatory for:
- programmer;
- artist;
- technical designer;
- any contributor creating folders, files, scenes, assets, or documents.

New folders and files must be created only inside this structure.

---

## 2. Repository Structure

```text
Bike-Super-Racing/
├── .github/
│   └── workflows/
├── Docs/
│   ├── architecture/
│   ├── art/
│   ├── design/
│   └── release/
├── GameClient/
│   ├── Assets/
│   ├── Packages/
│   ├── ProjectSettings/
│   └── UserSettings/
├── Tools/
│   ├── scripts/
│   └── packaging/
├── .gitattributes
├── .gitignore
├── LICENSE
└── README.md
```

### 2.1. Root Folder Intent
- `.github/` — CI/CD and automation;
- `Docs/` — project documentation;
- `GameClient/` — Unity project;
- `Tools/` — helper scripts and packaging.

---

## 3. Documentation Structure

```text
Docs/
├── architecture/
├── art/
├── design/
└── release/
```

### 3.1. `Docs/architecture/`
Contains:
- baseline architecture documents;
- naming convention;
- repository and Unity structure;
- runtime architecture rules.

Mandatory files:
- `naming-convention.md`
- `project-structure.md`
- `architecture-baseline.md`

### 3.2. `Docs/art/`
Contains:
- art direction baseline;
- MVP asset list;
- future visual production documents.

Current mandatory files:
- `art-direction-mvp.md`
- `asset-list-mvp.md`

### 3.3. `Docs/design/`
Contains design and UX documents used by the project.

Examples:
- `game-vision.md`
- `core-gameplay-loop.md`
- `race-flow-and-hud.md`
- `mvp-scope-and-feature-priority-matrix.md`

### 3.4. `Docs/release/`
Contains release checklist, build notes, and publication instructions.

---

## 4. Unity Project Structure

The Unity project lives in `GameClient/`.

Main `Assets/` structure:

```text
Assets/
├── _Project/
│   ├── Bootstrap/
│   ├── Core/
│   ├── Domain/
│   ├── Application/
│   ├── Infrastructure/
│   ├── Gameplay/
│   ├── UI/
│   ├── Configs/
│   ├── Content/
│   ├── Scenes/
│   ├── Tests/
│   └── Editor/
├── Plugins/
├── StreamingAssets/
└── TextMesh Pro/
```

`_Project/` is the only root for custom runtime code and content.

---

## 5. Layer Responsibilities

### 5.1. `Bootstrap/`
Responsibilities:
- application entry;
- service initialization;
- config initialization;
- runtime context creation;
- first scene routing.

### 5.2. `Core/`
Responsibilities:
- interfaces;
- shared abstractions;
- common primitives;
- state machine helpers;
- constants.

### 5.3. `Domain/`
Responsibilities:
- game entities;
- config models;
- player profile model;
- race session and race result models.

### 5.4. `Application/`
Responsibilities:
- use cases;
- orchestration;
- facades;
- coordination between domain and infrastructure.

### 5.5. `Infrastructure/`
Responsibilities:
- concrete service implementations;
- local save;
- cloud save stub;
- leaderboard implementation;
- audio;
- localization;
- time service;
- future platform integration.

### 5.6. `Gameplay/`
Responsibilities:
- bike controller;
- map runtime;
- countdown;
- timer;
- finish;
- race flow.

### 5.7. `UI/`
Responsibilities:
- screens;
- popups;
- widgets;
- HUD;
- visual representation of runtime state.

### 5.8. `Configs/`
Responsibilities:
- ScriptableObject configs;
- map configs;
- bike configs;
- color configs;
- global game config.

### 5.9. `Content/`
Responsibilities:
- art;
- prefabs;
- materials;
- audio;
- fonts;
- animations.

### 5.10. `Scenes/`
Responsibilities:
- playable scenes;
- technical test scenes.

### 5.11. `Tests/`
Responsibilities:
- EditMode tests;
- PlayMode tests.

### 5.12. `Editor/`
Responsibilities:
- validation tools;
- build helpers;
- editor-only utilities.

---

## 6. Detailed `Assets/_Project/` Structure

### 6.1. `Bootstrap/`
```text
Bootstrap/
├── Installers/
├── EntryPoint/
├── Startup/
└── Runtime/
```

### 6.2. `Core/`
```text
Core/
├── Interfaces/
├── Common/
├── Events/
├── StateMachine/
├── Constants/
└── Extensions/
```

### 6.3. `Domain/`
```text
Domain/
├── Bikes/
├── Maps/
├── Race/
├── Profile/
├── Settings/
├── Rewards/
└── Leaderboards/
```

### 6.4. `Application/`
```text
Application/
├── UseCases/
│   ├── App/
│   ├── Menu/
│   ├── Garage/
│   ├── Race/
│   ├── Save/
│   └── Leaderboards/
├── Commands/
├── Queries/
├── DTO/
└── Facades/
```

### 6.5. `Infrastructure/`
```text
Infrastructure/
├── Save/
│   ├── Local/
│   ├── CloudStub/
│   └── Serialization/
├── Platform/
│   ├── Yandex/
│   └── Stubs/
├── Leaderboards/
├── Audio/
├── Localization/
├── Logging/
└── Time/
```

### 6.6. `Gameplay/`
```text
Gameplay/
├── Bike/
│   ├── Controllers/
│   ├── Physics/
│   ├── View/
│   └── Input/
├── RaceFlow/
├── Countdown/
├── Timer/
├── Finish/
├── Map/
└── Spawn/
```

### 6.7. `UI/`
```text
UI/
├── Screens/
│   ├── Bootstrap/
│   ├── MainMenu/
│   ├── Race/
│   ├── Result/
│   ├── Settings/
│   └── Leaderboard/
├── Popups/
├── Widgets/
├── HUD/
└── ViewModels/
```

### 6.8. `Configs/`
```text
Configs/
├── Game/
├── Bikes/
├── Maps/
├── UI/
├── Audio/
├── Rewards/
└── Localization/
```

### 6.9. `Content/`
```text
Content/
├── Art/
│   ├── Sprites/
│   ├── Backgrounds/
│   ├── UI/
│   └── VFX/
├── Prefabs/
│   ├── Bikes/
│   ├── Maps/
│   ├── UI/
│   └── Common/
├── Materials/
├── Audio/
│   ├── Music/
│   ├── SFX/
│   └── Mixer/
├── Fonts/
└── Animations/
```

### 6.10. `Scenes/`
```text
Scenes/
├── 00_Bootstrap.unity
├── 01_MainMenu.unity
├── 02_Race.unity
├── 90_TestGameplay.unity
└── 91_TestUI.unity
```

### 6.11. `Tests/`
```text
Tests/
├── EditMode/
└── PlayMode/
```

### 6.12. `Editor/`
```text
Editor/
├── Build/
├── Validation/
└── Tools/
```

---

## 7. File Placement Rules

### 7.1. Domain Models
All domain models live in `Domain/`.

Examples:
- `Assets/_Project/Domain/Maps/MapDefinition.cs`
- `Assets/_Project/Domain/Bikes/BikeDefinition.cs`
- `Assets/_Project/Domain/Profile/PlayerProfile.cs`

### 7.2. Interfaces
All base service interfaces live in `Core/Interfaces/`.

Examples:
- `Assets/_Project/Core/Interfaces/ISaveService.cs`
- `Assets/_Project/Core/Interfaces/IRaceTimerService.cs`

### 7.3. Concrete Implementations
Concrete implementations live in `Infrastructure/` or `Application/Facades/` when the responsibility is application orchestration.

Examples:
- `Assets/_Project/Infrastructure/Save/Local/LocalSaveService.cs`
- `Assets/_Project/Infrastructure/Time/TimeService.cs`
- `Assets/_Project/Application/Facades/SceneLoader.cs`

### 7.4. UI Scripts
UI scripts live in `UI/` by screen type.

Examples:
- `Assets/_Project/UI/Screens/MainMenu/MainMenuScreen.cs`
- `Assets/_Project/UI/Popups/Settings/SettingsPopup.cs`

### 7.5. Content
Content lives in `Content/`.

Examples:
- `Assets/_Project/Content/Art/Sprites/Bikes/SPR_Bike_Bike01_Body.png`
- `Assets/_Project/Content/Prefabs/UI/PREF_UI_ResultPanel.prefab`

---

## 8. Scene Structure

### 8.1. Canonical Scenes for MVP
- `00_Bootstrap`
- `01_MainMenu`
- `02_Race`
- `90_TestGameplay`
- `91_TestUI`

### 8.2. Scene Intent
#### `00_Bootstrap`
- technical entry scene;
- service initialization;
- config loading;
- profile loading;
- route to main menu.

#### `01_MainMenu`
- player entry point;
- race start;
- settings access;
- leaderboard access;
- placeholders for Garage and Daily Rewards.

#### `02_Race`
- single playable race;
- countdown;
- timer;
- spawn;
- finish;
- result;
- restart.

#### `90_TestGameplay`
- isolated gameplay validation.

#### `91_TestUI`
- isolated UI validation.

---

## 9. Structure Baseline for First Playable Version

The first playable version uses only:
- 1 map;
- 1 bike;
- 1 color;
- 1 leaderboard;
- 1 language;
- local save;
- cloud save stub;
- bootstrap;
- main menu;
- race scene;
- result flow;
- local leaderboard baseline.

Even with one element, the structure must support growth to:
- 3 maps;
- 2 bikes;
- 5 colors;
- multiple leaderboard IDs;
- future platform integration.

---

## 10. Assembly Definition Strategy

The project uses the following `.asmdef` files:
- `Project.Core`
- `Project.Domain`
- `Project.Application`
- `Project.Infrastructure`
- `Project.Gameplay`
- `Project.UI`
- `Project.Tests.EditMode`
- `Project.Tests.PlayMode`

### 10.1. Dependency Rules
- `Project.Domain` depends only on `Project.Core`;
- `Project.Application` depends on `Project.Core` and `Project.Domain`;
- `Project.Infrastructure` depends on `Project.Core` and `Project.Domain`;
- `Project.Gameplay` depends on `Project.Core`, `Project.Domain`, `Project.Application`;
- `Project.UI` depends on `Project.Core`, `Project.Application`;
- `Project.Domain` must not depend on `Infrastructure`, `UI`, or `Gameplay`.

---

## 11. Forbidden Practices

The following are forbidden:
- folders like `Misc`, `Temp`, `NewFolder`, `Other`, `Stuff`;
- mixing different responsibilities in one flat folder;
- placing UI code in `Gameplay/`;
- placing domain models in `Infrastructure/`;
- storing temporary assets outside project structure;
- creating duplicate root folders inside `_Project/`.

---

## 12. Structure Change Order

Any structure change must follow this order:
1. update this document;
2. agree the new folder or rule;
3. create the structure in repository and Unity;
4. use the new structure in code and content.

Changing structure without updating this document is an architectural error.

---

## 13. Status

This document is mandatory for all contributors.

If a file or folder does not fit this structure, it must not be created before this document is updated.
