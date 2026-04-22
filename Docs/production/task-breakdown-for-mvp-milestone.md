# Bike Super Racing — Task Breakdown for MVP Milestone

## Purpose
This document fixes the production task breakdown for the MVP / vertical slice milestone.

It is intended to be used by:
- Unity programmer / gameplay programmer;
- lead game designer;
- artist / animator / pixel artist;
- UI/UX;
- QA;
- documentation / PM.

The goal is to make the next production step explicit:
- what must be done now;
- what is on the critical path;
- what can be done in parallel;
- what must not expand scope;
- what counts as done for the MVP milestone.

## Milestone definition
The MVP milestone is complete when the project has a stable vertical slice with:
- `map_01`;
- `bike_01`;
- `leaderboard_map_01`;
- one playable short race session;
- countdown;
- timer;
- finish;
- result screen;
- safe restart loop;
- local save for best time and basic user selections;
- minimal main menu flow.

## Main milestone objective
The milestone must prove the following product statement:

**The player can launch the game, enter a race quickly, complete one readable short run, understand the result, and immediately want one more attempt.**

## Hard production rules
1. The team is building one strong vertical slice, not a broad feature set.
2. `map_01`, `bike_01`, `leaderboard_map_01` are the only mandatory gameplay entities for this milestone.
3. Any feature that does not strengthen the playable race loop is secondary.
4. No task should introduce naming that conflicts with `Docs/architecture/naming-convention.md`.
5. No task should widen scope beyond MVP without explicit reclassification.

## Critical path summary
The critical path for the milestone is:
1. naming and architecture baseline fixed;
2. playable race scene created;
3. bike controller working enough for first feel tests;
4. `map_01` playable enough for one full start-to-finish loop;
5. countdown, timer and finish events working;
6. result screen and restart loop working;
7. best time save working;
8. leaderboard connection point working or safely stubbed;
9. first full internal playtest of the complete loop;
10. MVP bug fixing and polish on the core loop only.

If any of these items slip, the milestone slips.

## Parallel work summary
The following can run in parallel after naming and architecture are fixed:
- programmer builds gameplay flow and race-state systems;
- artist builds `bike_01`, `map_01` visual assets and UI-support assets;
- UI/UX builds HUD and result layout;
- design validates feel, readability and retry loop behavior;
- QA prepares smoke checklist and begins iterative testing as soon as the first playable loop exists;
- documentation / PM keeps docs synchronized and tracks blockers.

## Role breakdown

# 1. Unity programmer / gameplay programmer

## Main responsibility
Build the MVP playable loop from scene entry to result and restart.

## Must-have tasks
### 1. Scene and flow setup
- create and wire `00_Bootstrap`;
- create and wire `01_MainMenu`;
- create and wire `02_Race`;
- ensure scene flow matches architecture baseline;
- ensure canonical names are used in scenes, objects and references.

### 2. Core services and runtime baseline
- implement or scaffold required core services from `architecture-baseline.md`;
- initialize config loading;
- initialize local save;
- prepare leaderboard abstraction or stub;
- ensure app flow can move from bootstrap to menu to race.

### 3. Bike gameplay baseline
- implement the first controllable version of `bike_01`;
- ensure the controller is stable enough for repeated feel testing;
- expose minimal tunable parameters required for quick iteration;
- avoid premature overengineering before the first feel pass.

### 4. Race scene implementation
- spawn or initialize `map_01`;
- place start point and finish trigger;
- create race state flow:
  - `EnterRaceScene`;
  - `PreStart`;
  - `Countdown`;
  - `RaceActive`;
  - `RaceFinished`;
  - `ResultPresentation`;
  - `RestartRequested`;
  - `Pause` if implemented in MVP pass;
- connect control gating to state changes.

### 5. Countdown, timer and finish
- countdown starts correctly;
- timer starts exactly when control opens;
- finish stops the timer exactly once;
- result data is produced from authoritative runtime state.

### 6. Result and restart
- show result panel;
- compare current time with local best;
- update local best if improved;
- implement safe restart pipeline;
- ensure repeated restarts do not create stale runtime state.

### 7. Save and leaderboard baseline
- save best result locally;
- save minimal player-facing state if required for MVP shell;
- submit to `leaderboard_map_01` if integration is ready;
- ensure leaderboard failure never blocks result presentation or restart.

## Should-have tasks
- simple settings persistence for audio;
- lightweight hooks for color selection;
- basic pause overlay.

## Could-have tasks
- extra editor tooling;
- deeper config abstractions;
- expanded debug utilities.

## Programmer dependencies
Needs from design:
- fixed core loop and race flow docs;
- result and restart behavior baseline;
- MVP scope boundary.

Needs from art:
- at least placeholder or early production assets for bike, map and UI;
- readable collision / visual structure for `map_01`.

## Programmer definition of done for milestone
- a player can launch, race, finish, see result, restart and repeat;
- the loop is stable over multiple attempts;
- best local time works;
- race flow matches design docs;
- no critical naming drift.

# 2. Lead game designer

## Main responsibility
Own gameplay intent, product scope, race readability, retry loop quality and feature priority.

## Must-have tasks
### 1. Baseline documentation
- maintain current design baseline documents;
- keep design decisions synchronized with architecture and production reality;
- prevent naming drift or logic drift across chats and docs.

### 2. Core gameplay validation
- define what counts as acceptable control feel for MVP;
- define what the first track must teach;
- define acceptable first-minute experience;
- define result screen and restart priorities.

### 3. Difficulty and readability validation
- validate that `map_01` teaches through play;
- validate that challenge rises in a readable sequence;
- validate that first mistakes are understandable;
- validate that the finish encourages another run.

### 4. Scope control
- reject out-of-scope features during MVP production;
- classify new ideas as must / should / could / out of scope;
- maintain focus on one strong loop over broad content.

### 5. Cross-role clarification
- provide concrete answers to programmer, art and UI when ambiguity appears;
- convert vague feature ideas into small production-safe decisions.

## Should-have tasks
- define short internal playtest questions;
- define tuning targets for track readability and restart speed.

## Could-have tasks
- prepare post-MVP content growth notes;
- prepare early meta / retention options for later milestone.

## Designer dependencies
Needs from programmer:
- playable builds for feel and loop validation.

Needs from art/UI:
- readable visuals sufficient to judge gameplay clarity.

## Designer definition of done for milestone
- the first playable loop is validated against Game Vision;
- MVP scope remained controlled;
- core gameplay problems are identified quickly and clearly;
- no major design ambiguity blocks other roles.

# 3. Artist / animator / pixel artist

## Main responsibility
Create the minimum visual content required for a readable and production-usable MVP race loop.

## Must-have tasks
### 1. Bike production for `bike_01`
- produce `bike_01` visual baseline according to the existing art docs;
- ensure silhouette readability at race speed;
- support the feel of control and motion;
- provide at least the minimum sprite states required for the programmer to test and present the bike properly.

Detailed execution intent:
- the bike must read instantly as the player-controlled object;
- body, wheels and rider silhouette must not merge into a noisy cluster;
- contrast must support visibility on `map_01` background;
- animation, if minimal, must reinforce movement rather than distract.

### 2. Map production for `map_01`
- create the minimum tiles / modules required to assemble a readable `map_01`;
- separate safe ground, hazardous ground and track edges clearly;
- maintain readability over decoration density;
- use the existing tileset spec as baseline.

Detailed execution intent:
- the player must understand the track shape at speed;
- collision-relevant surfaces must be visually legible;
- decorative clutter must stay below gameplay readability priority;
- foreground, ground and background layers must not visually compete for the same attention band.

### 3. Core race UI support assets
- create the minimum visual assets needed for timer backing, countdown presentation, result panel and buttons if not already covered;
- keep UI visuals clean and low-noise;
- support browser readability.

Detailed execution intent:
- result panel must feel competitive and clean, not overloaded;
- restart button must visually support immediate action;
- countdown must be readable at a glance;
- timer container must not overpower the screen.

## Should-have tasks
- lightweight motion accents for countdown or result states;
- extra polish for finish feedback;
- additional color variant support if pipeline is already prepared.

## Could-have tasks
- richer cosmetic polish;
- secondary decorative track details;
- expanded animation passes beyond MVP readability needs.

## Art dependencies
Needs from design:
- readability priorities;
- result screen hierarchy;
- track difficulty intent.

Needs from programmer:
- sprite sizing, anchor points, scene usage constraints and integration cadence.

## Artist definition of done for milestone
- `bike_01` is readable and production-usable in the race scene;
- `map_01` is readable enough for gameplay evaluation;
- UI-support assets do not obstruct the retry loop;
- the art supports clarity before decoration.

# 4. UI/UX

## Main responsibility
Shape the playable clarity of HUD, countdown, result screen and navigation around the race loop.

## Must-have tasks
### 1. Main menu baseline
- ensure the route from main menu to race is short and obvious;
- keep entry into race clearer than shell exploration;
- avoid MVP overcomplication.

### 2. HUD baseline
- layout timer with high readability;
- place pause access without competing with the track;
- ensure countdown reads instantly;
- ensure HUD does not cover critical race space.

### 3. Result screen baseline
- implement hierarchy from `result-screen-and-restart-loop.md`;
- make current result largest;
- make best result secondary;
- make restart primary;
- make exit secondary.

### 4. Restart experience
- ensure result-to-restart is visually fast;
- avoid slow modal behavior;
- ensure input affordances are obvious for browser play.

## Should-have tasks
- subtle hover / focus behavior;
- lightweight transition polish;
- settings and leaderboard overlay consistency.

## Could-have tasks
- richer visual state polish;
- additional non-critical visual feedback layers.

## UI/UX dependencies
Needs from design:
- race flow and result priorities;
- first-minute constraints;
- MVP scope guardrails.

Needs from art:
- required UI assets and visual style baseline.

Needs from programmer:
- stable event/state hooks for HUD and result states.

## UI/UX definition of done for milestone
- player can read timer, countdown and result without effort;
- restart is clearly the main post-race action;
- entry and exit paths are understandable;
- UI does not slow the retry loop.

# 5. QA

## Main responsibility
Protect the vertical slice from regressions, broken flow and false-positive “playable” states.

## Must-have tasks
### 1. Smoke checklist creation
Create an MVP smoke checklist that covers:
- bootstrap to menu;
- menu to race;
- countdown;
- active race;
- finish;
- result;
- restart;
- repeated restart stability;
- save of best result;
- leaderboard safe behavior if present.

### 2. Loop stability testing
- test repeated restarts in sequence;
- test finish reliability;
- test timer correctness;
- test result panel states;
- test first-run behavior and new-best behavior.

### 3. Usability observation
- test whether the player can understand the result state quickly;
- test whether the player can find restart immediately;
- test whether `map_01` feels readable enough for first attempts.

## Should-have tasks
- test multiple browser resolutions;
- test pause/resume path if included;
- test basic settings persistence.

## Could-have tasks
- extended exploratory testing of could-have shell elements.

## QA dependencies
Needs from programmer:
- stable enough build to loop through the full race cycle.

Needs from design:
- explicit pass/fail expectations for MVP.

## QA definition of done for milestone
- no critical blocker remains in the main race loop;
- known issues are classified clearly;
- the team has evidence that the playable loop works across repeated attempts.

# 6. Documentation / PM

## Main responsibility
Keep production aligned, keep blockers visible and protect the project from silent drift.

## Must-have tasks
### 1. Documentation synchronization
- keep `Docs/architecture`, `Docs/design`, `Docs/art` and `Docs/production` aligned;
- update README index when new baseline docs appear;
- ensure naming consistency across docs.

### 2. Milestone tracking
- track the critical path items;
- track blocked tasks and blockers’ owners;
- separate must-have tasks from should / could tasks.

### 3. Scope protection
- surface scope drift early;
- flag tasks that are entering production without MVP classification;
- keep the team aligned on milestone definition.

### 4. Communication support
- summarize decisions that affect multiple roles;
- ensure other project chats reference the current baseline rather than stale assumptions.

## Should-have tasks
- lightweight risk log;
- explicit change log for baseline docs.

## Could-have tasks
- early post-MVP planning notes;
- future milestone shell planning.

## Documentation / PM dependencies
Needs from all roles:
- timely communication of changed assumptions;
- visibility on blockers and done criteria.

## Documentation / PM definition of done for milestone
- baseline docs match production reality;
- the team can answer what is in MVP and what is not;
- blocker ownership is visible;
- other chats can rely on the repo docs safely.

## Phase-by-phase production plan

# Phase 0 — Baseline lock
Goal:
- freeze naming, architecture, core design and art baselines.

Required outputs:
- docs baseline in repo;
- README index;
- canonical scene names and IDs fixed.

Status intent:
- largely in progress / partially established already.

# Phase 1 — First playable race skeleton
Goal:
- get a race scene running end-to-end with placeholder-safe assets.

Required outputs:
- controllable bike baseline;
- simple playable `map_01`;
- countdown;
- timer;
- finish event;
- result placeholder;
- restart placeholder.

Critical owner:
- Unity programmer.

Parallel support:
- art provides first usable visuals;
- design validates structure.

# Phase 2 — Readable vertical slice
Goal:
- replace rough placeholder behavior with readable MVP-quality loop.

Required outputs:
- better `bike_01` readability;
- better `map_01` readability;
- working HUD;
- working result screen hierarchy;
- stable best-time save.

Critical owners:
- programmer + artist + UI/UX.

# Phase 3 — Stable retry loop
Goal:
- ensure repeatability, reliability and short session rhythm.

Required outputs:
- safe restart pipeline;
- no stale UI state;
- no timer drift;
- clean first-run and repeat-run behavior;
- first pass QA validation.

Critical owners:
- programmer + QA.

# Phase 4 — MVP acceptance pass
Goal:
- verify that the product statement is true in internal testing.

Required outputs:
- stable full loop;
- no critical blockers;
- clear MVP candidate build;
- known should-have items either resolved or consciously deferred.

## Dependency matrix
### Blockers for programmer
- missing baseline naming;
- no map modules or placeholder geometry;
- undefined result behavior.

### Blockers for art
- no size / anchor / usage guidance from implementation;
- no clarity on what assets are must-have for the first playable loop.

### Blockers for UI/UX
- no race-state hooks;
- no hierarchy decision for result flow.

### Blockers for QA
- no stable build path for repeated testing;
- unclear pass/fail definition.

### Blockers for PM/docs
- undocumented decisions;
- inconsistent naming or undocumented scope changes.

## What can be cut first if schedule is threatened
Cut first:
- extra polish animations;
- expanded garage shell;
- daily-quest shell;
- non-critical menu depth;
- extra decorative UI states;
- additional content variants.

Protect at all costs:
- playable race loop;
- control feel iteration;
- readable `map_01`;
- timer / finish / result / restart;
- local best result save;
- stable MVP build.

## Acceptance checklist for the milestone
The MVP milestone can be considered reached when all of the following are true:
1. the player can enter a race quickly from menu;
2. `bike_01` is controllable and readable enough for repeated play;
3. `map_01` supports one full readable race attempt;
4. countdown, timer and finish work correctly;
5. result screen shows the current result and best result clearly;
6. restart is the primary next action and works repeatedly;
7. best local time persists;
8. no critical blocker prevents repeating the full loop several times in one session.

## Final production rule
For this milestone, the team should prefer:
- one strong solved loop;
over
- many partially solved systems.

That preference must decide disputed priorities whenever schedule, time or scope is under pressure.
