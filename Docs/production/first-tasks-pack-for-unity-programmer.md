# Bike Super Racing — First Tasks Pack for Unity Programmer

## Purpose
This document provides the first concrete implementation pack for the Unity programmer working on the MVP / vertical slice.

It is not a broad wishlist.
It is the ordered starting sequence for implementation.

The document answers:
- what to build first;
- in what order to build it;
- what can be stubbed;
- what each step must produce;
- what classes, scenes, configs and runtime pieces should exist after each step;
- what is considered done before moving to the next task.

## Scope of this pack
This pack covers only the first production-critical implementation slice:
- bootstrap;
- main menu entry flow;
- race scene skeleton;
- controllable `bike_01` baseline;
- playable `map_01` baseline;
- countdown;
- timer;
- finish;
- result;
- restart;
- local best result save.

This pack does not attempt to complete:
- deep garage logic;
- advanced leaderboard UI;
- extra bikes;
- extra maps;
- complex settings;
- post-MVP shell systems.

## Working rule
At every step, prefer:
- one testable working loop fragment;
over
- multiple unfinished systems.

## Hard references
All implementation must follow:
- `Docs/architecture/naming-convention.md`;
- `Docs/architecture/project-structure.md`;
- `Docs/architecture/architecture-baseline.md`;
- `Docs/design/game-vision.md`;
- `Docs/design/race-flow-and-hud.md`;
- `Docs/design/result-screen-and-restart-loop.md`;
- `Docs/design/mvp-scope-and-feature-priority-matrix.md`.

## Global outcome target
At the end of this pack, the programmer should have a build where:
- the app boots;
- main menu opens;
- player can enter race;
- one controllable bike exists;
- one playable track exists;
- countdown starts;
- timer runs;
- finish stops the timer;
- result screen shows the final time and best time;
- restart works repeatedly without broken state.

---

# Phase 1 — Project skeleton and scene baseline

## Goal
Create the minimum project structure and scene chain required to begin real gameplay implementation without naming drift.

## Tasks
### 1.1 Create required scenes
Create the following scenes in the canonical path:
- `/Assets/_Project/Scenes/00_Bootstrap.unity`;
- `/Assets/_Project/Scenes/01_MainMenu.unity`;
- `/Assets/_Project/Scenes/02_Race.unity`;
- `/Assets/_Project/Scenes/90_TestGameplay.unity`;
- `/Assets/_Project/Scenes/91_TestUI.unity`.

### 1.2 Create required folders if missing
Ensure the following minimal folders exist:
- `/Assets/_Project/Config/Game`;
- `/Assets/_Project/Config/Maps`;
- `/Assets/_Project/Config/Bikes`;
- `/Assets/_Project/Config/Colors`;
- `/Assets/_Project/Prefabs/Gameplay`;
- `/Assets/_Project/Prefabs/UI`;
- `/Assets/_Project/Scripts/Bootstrap`;
- `/Assets/_Project/Scripts/Domain`;
- `/Assets/_Project/Scripts/Application/Services`;
- `/Assets/_Project/Scripts/Infrastructure`;
- `/Assets/_Project/Scripts/Gameplay`;
- `/Assets/_Project/Scripts/UI`.

### 1.3 Create config asset stubs
Create these config assets, even if they are mostly empty at first:
- `CFG_Game_Main`;
- `CFG_Map_Map01`;
- `CFG_Bike_Bike01`;
- `CFG_Color_Red`.

### 1.4 Create script stubs for required runtime contracts
Create stubs or minimal implementations for:
- `Bootstrapper.cs`;
- `IAppStateService.cs`;
- `ISceneLoader.cs`;
- `IConfigService.cs`;
- `IPlayerProfileService.cs`;
- `ISaveService.cs`;
- `IRaceSessionService.cs`;
- `IRaceTimerService.cs`;
- `ICountdownService.cs`;
- `IRaceResultService.cs`;
- `SceneLoader.cs`;
- `AppStateService.cs`;
- `ConfigService.cs`;
- `PlayerProfileService.cs`;
- `LocalSaveService.cs`.

## Minimum output of Phase 1
After Phase 1, the project must have:
- canonical scenes created;
- canonical folders created;
- config asset stubs created;
- script skeleton consistent with architecture docs.

## Definition of done for Phase 1
Phase 1 is done when the project can be opened and no core baseline element still exists only in documentation but not in the Unity project structure.

---

# Phase 2 — Bootstrap and main menu entry

## Goal
Get the application into a clean boot → menu flow.

## Tasks
### 2.1 Implement `00_Bootstrap`
The bootstrap scene should:
- create or initialize core services;
- load `CFG_Game_Main`;
- initialize save access;
- prepare player profile access;
- route to `01_MainMenu`.

### 2.2 Implement `SceneLoader`
Required behavior:
- load scene by canonical scene name;
- expose simple async or callback-safe usage;
- keep implementation minimal and stable.

### 2.3 Implement `ConfigService`
Required behavior:
- load root config references;
- expose `CFG_Game_Main`;
- provide access to `CFG_Map_Map01`, `CFG_Bike_Bike01`, `CFG_Color_Red`.

### 2.4 Implement `LocalSaveService`
Required MVP behavior:
- read best time for `map_01`;
- write best time for `map_01`;
- optionally read/write selected color / basic player shell selection.

### 2.5 Implement `PlayerProfileService`
Required behavior:
- hold selected `bike_01` and `color_red` as defaults;
- expose player-facing best result data;
- wrap save reads and writes instead of scattering them in UI.

### 2.6 Create minimal `01_MainMenu`
The first version of main menu can be simple.
Required elements:
- one clear entry action to start race;
- optional placeholder buttons for settings / leaderboard if needed;
- no heavy shell logic yet.

## UI implementation note for programmer
The first menu should not be pretty-first.
It should be clear-first.

Practical visual expectation:
- one main action button, large and obvious;
- low UI clutter;
- fast path into race;
- no deep navigation.

## Minimum output of Phase 2
After Phase 2, the app must:
- boot into main menu;
- allow entering `02_Race` from menu;
- keep default selections stable.

## Definition of done for Phase 2
A tester can launch the game and consistently reach the race scene without manual editor intervention.

---

# Phase 3 — Race scene skeleton

## Goal
Create the first end-to-end race scene structure without full polish.

## Tasks
### 3.1 Build `02_Race` scene layout
Required scene content:
- one race root object;
- one spawn point for the player bike;
- one finish trigger zone;
- one camera setup sufficient for 2D racing readability;
- one placeholder or early `map_01` geometry setup;
- one Canvas or UI root for race HUD.

### 3.2 Create `RaceSession` and `RaceResult` domain objects
Required fields for `RaceSession` minimum:
- selected map ID;
- selected bike ID;
- selected color ID;
- race state;
- timer running state;
- finish flag.

Required fields for `RaceResult` minimum:
- map ID;
- bike ID;
- color ID;
- total time;
- `isNewBest` flag.

### 3.3 Implement race-state flow skeleton
Create a single orchestration path for:
- `EnterRaceScene`;
- `PreStart`;
- `Countdown`;
- `RaceActive`;
- `RaceFinished`;
- `ResultPresentation`;
- `RestartRequested`.

Important implementation rule:
Do not spread race truth across unrelated UI components.
The scene must have a clear owner of race state.

### 3.4 Create `RaceHudView`, `CountdownWidget`, `ResultPanel` stubs
The first version may be simple.
Each must exist as a dedicated UI component with a clear responsibility.

## Minimum output of Phase 3
After Phase 3, the race scene has a stable structural skeleton that can host a real playable loop.

## Definition of done for Phase 3
The project has a race scene with explicit state flow, even if bike feel and art are still placeholder-grade.

---

# Phase 4 — Bike controller baseline for `bike_01`

## Goal
Get one controllable bike working well enough for first feel tests.

## Tasks
### 4.1 Implement first controllable bike baseline
The first version of `bike_01` must support:
- forward movement;
- baseline speed behavior;
- stable interaction with the track;
- enough predictability for first readability and feel testing.

Do not overbuild at this stage.
The target is a testable baseline, not the final controller.

### 4.2 Expose tuning parameters
Expose at least a minimal tunable set for quick iteration, for example:
- acceleration;
- max speed;
- deceleration or drag;
- ground handling response;
- jump / bump / air behavior only if already relevant in the prototype.

### 4.3 Create or bind `PREF_Bike_Bike01`
The race scene must instantiate or use the canonical bike prefab.

### 4.4 Support placeholder-safe visual integration
Even before final art is ready, the bike object must be visually readable enough that design can judge:
- location;
- orientation;
- interaction with the track.

## Gameplay feel note for programmer
The early controller must prioritize:
- readability;
- stability;
- easy tuning;
- repeatable testing.

It does not need advanced polish yet.

## Minimum output of Phase 4
A tester can control the bike on the track and start feeling the first version of the game loop.

## Definition of done for Phase 4
The bike can move through a testable race scene without major control-breaking instability.

---

# Phase 5 — `map_01` playable baseline

## Goal
Create the first playable version of `map_01` that supports one real start-to-finish run.

## Tasks
### 5.1 Assemble first playable track geometry
Use placeholder or early production tiles/modules to assemble `map_01` with:
- clear start region;
- readable mid-track sections;
- finish region;
- no impossible geometry;
- no visual dependence on final art polish.

### 5.2 Prioritize track readability in geometry placement
The first version of `map_01` should support design goals from onboarding and difficulty docs:
- early readable adaptation section;
- one first understandable challenge;
- one first likely time-loss section;
- finish that completes the learning loop.

### 5.3 Ensure finish trigger reliability
The finish trigger should:
- fire once;
- stop the timer;
- move the race to result state.

## Map integration note for programmer
Even if art is incomplete, collision and traversable shape must already express the intended race logic.

## Minimum output of Phase 5
A tester can complete one full run from start to finish on `map_01`.

## Definition of done for Phase 5
The first full playable loop exists physically in the race scene.

---

# Phase 6 — Countdown, timer and finish

## Goal
Make the race measurable and state-correct.

## Tasks
### 6.1 Implement countdown
Required behavior:
- visible pre-race countdown;
- synchronized with opening control;
- repeatable after restart.

### 6.2 Implement timer
Required behavior:
- starts exactly when the race begins;
- updates cleanly in UI;
- stops exactly on finish;
- uses one source of truth.

### 6.3 Implement finish processing
Required behavior:
- finish event occurs once;
- timer stops;
- `RaceResult` is built;
- current result is passed to result presentation.

### 6.4 Bind `RaceHudView`
Required MVP HUD behavior:
- timer visible;
- countdown visible;
- no heavy extra UI.

## UI visual guidance for programmer
Use low-noise layout even with temporary visuals.

Practical expectation:
- timer readable at a glance;
- countdown large and centered;
- no oversized debug text covering the track in production-facing prototype builds.

## Minimum output of Phase 6
A tester can run the track, see time, finish, and transition into result state.

## Definition of done for Phase 6
The race loop is now measurable and no longer only a raw movement prototype.

---

# Phase 7 — Result panel and restart loop

## Goal
Convert one completed run into one more attempt.

## Tasks
### 7.1 Implement `ResultPanel`
Required displayed data:
- current race time;
- best race time;
- optional `New Best` state if improved;
- restart action;
- exit/back action.

### 7.2 Compare current result to saved best
Required behavior:
- read local best time for `map_01`;
- compare current run;
- set `isNewBest`;
- save new best if improved.

### 7.3 Implement safe restart pipeline
Restart must reset at minimum:
- race state;
- bike position;
- bike velocity and transient movement state;
- timer state;
- finish flag;
- countdown widget state;
- result panel state;
- any temporary effects or values that can leak between attempts.

### 7.4 Make restart primary
In the first result version, restart must be the most obvious next action.

## UX note for programmer
Even with programmer UI, the result screen must communicate hierarchy clearly:
- current result biggest;
- best result secondary;
- restart primary;
- exit secondary.

## Minimum output of Phase 7
The app now supports repeated full race attempts in one session.

## Definition of done for Phase 7
A tester can complete multiple sequential runs without scene corruption, stale UI or timer bugs.

---

# Phase 8 — Save stability and leaderboard hook

## Goal
Ensure the loop has persistence and a non-blocking competition integration point.

## Tasks
### 8.1 Stabilize local save behavior
Required:
- best time persists after app restart;
- first-run behavior is clean;
- no invalid placeholder result state appears.

### 8.2 Add leaderboard hook or safe stub
Required behavior:
- submission path exists for `leaderboard_map_01` if platform integration is ready;
- if not ready, the game still works fully locally;
- leaderboard failure never blocks result and restart.

### 8.3 Test sequence integrity
Test the following sequence repeatedly:
- launch app;
- go to menu;
- start race;
- finish;
- set best time;
- restart;
- finish again;
- close app;
- relaunch;
- confirm best time still exists.

## Minimum output of Phase 8
The core loop survives both runtime repetition and basic persistence checks.

## Definition of done for Phase 8
The programmer has produced a stable MVP loop candidate, not only a local prototype fragment.

---

# Immediate task order summary
For convenience, here is the strict first-order sequence:
1. create canonical scenes and folders;
2. create config stubs;
3. create baseline service and domain stubs;
4. make bootstrap load main menu;
5. make main menu enter race;
6. create race scene root and race-state skeleton;
7. get one controllable bike moving;
8. get one playable map assembled;
9. add countdown;
10. add timer;
11. add finish;
12. add result screen;
13. add restart;
14. add local best save;
15. add leaderboard hook or stub.

If priorities conflict, follow this list.

---

# What can be stubbed safely in this pack
The programmer may stub or simplify:
- settings menu internals;
- full leaderboard screen UI;
- full garage logic;
- color selection UX beyond default value;
- advanced animation systems;
- advanced audio behavior;
- secondary overlays;
- broad platform shell logic.

These must not block the first playable loop.

---

# What must not be postponed in this pack
Do not postpone:
- race-state ownership;
- timer truth source;
- finish correctness;
- restart correctness;
- best local result persistence;
- naming correctness.

These are foundational and expensive to “clean up later”.

---

# Recommended first code ownership map
A reasonable first ownership split inside code could look like this:
- `Bootstrapper` — scene startup and root initialization;
- `SceneLoader` — scene transitions;
- `ConfigService` — config access;
- `PlayerProfileService` — current selections and best result exposure;
- `LocalSaveService` — persistence backend;
- one race orchestration class under gameplay — race-state owner;
- one timer service or timer controller — timing truth;
- `RaceHudView` — UI display only;
- `CountdownWidget` — countdown display only;
- `ResultPanel` — post-race UI display only.

Keep UI display separate from gameplay truth.

---

# Hand-off expectations from other roles
## Needed from design
- immediate clarification on control-feel issues;
- validation of track readability;
- validation of result/restart priorities.

## Needed from art
- readable bike presentation for `bike_01`;
- readable map modules for `map_01`;
- low-noise UI support assets when available.

## Needed from QA
- early smoke validation as soon as a full loop exists;
- repeated restart stress checks.

---

# Acceptance checklist for the programmer
This pack is complete when all statements below are true:
1. bootstrap opens menu without manual editor setup;
2. menu enters race scene;
3. `bike_01` is controllable;
4. `map_01` is completable from start to finish;
5. countdown and timer work in sync;
6. finish stops the timer exactly once;
7. result panel shows current time and best time;
8. restart works multiple times in a row;
9. best local time persists across app restart;
10. the implementation uses canonical names from project docs.

---

# Final instruction to the Unity programmer
The first objective is not to make the game look complete.
The first objective is to make the race loop real, stable and repeatable.

If a task does not help the team test:
- control feel;
- track readability;
- finish-to-restart loop;
then it is probably not the next task.
