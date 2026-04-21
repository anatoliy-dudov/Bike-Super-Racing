# Bike Super Racing — Race Flow & HUD

## Purpose
This document fixes the required race flow, HUD composition, UI behavior and implementation expectations for the MVP.

It is written to be usable by:
- gameplay programmers;
- UI programmers;
- UI/UX designers;
- artists creating race HUD assets.

## Product goal of race flow
The race flow must support one central behavior:

**finish a run, understand the result and restart with minimal friction.**

If the flow slows this behavior, it weakens the product.

## Race state model
Use the following explicit race states:
- `EnterRaceScene`;
- `PreStart`;
- `Countdown`;
- `RaceActive`;
- `RaceFinished`;
- `ResultPresentation`;
- `RestartRequested`;
- `Pause`.

The UI should react to these states.
The UI must not invent its own gameplay truth.

## High-level player flow
- player enters the race scene from main menu;
- player sees the bike at the start line;
- short countdown begins;
- control opens and timer starts;
- player races;
- finish trigger stops the timer;
- result overlay appears;
- player retries or exits.

## Detailed flow requirements
### EnterRaceScene
What the player should feel:
- I am already almost in gameplay.

Programmer requirements:
- load track and required references;
- spawn or activate `PREF_Bike_Bike01` at start point;
- prepare `RaceHudView`;
- timer is initialized but not running;
- control is still blocked.

### PreStart
What the player should feel:
- the attempt is about to begin.

Programmer requirements:
- the bike is visible at start;
- HUD is present in low-noise state;
- timer is visible but idle;
- countdown is ready to begin.

### Countdown
What the player should feel:
- focus and readiness.

Programmer requirements:
- `CountdownWidget` displays the countdown sequence;
- opening player control and starting the timer must be synchronized with countdown completion;
- the state transition to `RaceActive` must happen only once.

### RaceActive
What the player should feel:
- the bike is responsive;
- the HUD does not distract from the track.

Programmer requirements:
- timer runs continuously;
- HUD updates are stable and non-flickering;
- finish trigger is armed;
- pause access is available.

### RaceFinished
What the player should feel:
- my result is locked in.

Programmer requirements:
- stop timer exactly once;
- block or safely damp gameplay control;
- build `RaceResult` data object;
- compare current result with local best result;
- prepare result overlay data.

### ResultPresentation
What the player should feel:
- retry is the natural next action.

Programmer requirements:
- show `ResultPanel`;
- display current result;
- display best result if available;
- show record state when applicable;
- make restart the primary action.

### RestartRequested
What the player should feel:
- I am continuing the session, not relaunching the level from scratch.

Programmer requirements:
- reset bike transform and runtime state;
- reset velocities and temporary effects;
- reset finish flag;
- reset timer;
- reset HUD state;
- return flow to `PreStart` or straight into `Countdown` depending on chosen implementation.

## HUD philosophy
The HUD must be minimal and race-supportive.

The player's visual priority during a race should be:
1. track geometry and hazards;
2. bike behavior;
3. countdown or finish signal in key moments;
4. timer;
5. all secondary UI.

## Mandatory HUD elements
### 1. Race timer
Purpose:
- show the current attempt time.

Recommended placement:
- top center.

Visual description for UI/art:
- compact digital timer block;
- clean typography;
- strong readability on bright and dark backgrounds;
- light or semi-transparent backing plate;
- no heavy decorative frame;
- should feel competitive, modern and lightweight.

Programmer requirements:
- timer display must use one source of truth;
- visual text update must not flicker or jump;
- timer starts exactly at race start;
- timer freezes exactly at finish.

Prompt-style description:
- minimal arcade racing timer, top-center, highly readable numeric display, lightweight semi-transparent backing, clean geometry, no heavy decoration, quick readability during motion, competitive feel.

### 2. Countdown widget
Purpose:
- clearly mark race start rhythm.

Recommended placement:
- screen center.

Visual description for UI/art:
- large numbers or short start text;
- very high readability;
- strong contrast against the track;
- energetic but brief;
- should feel like a race start signal, not a long cinematic.

Programmer requirements:
- countdown controlled by state machine;
- must support repeated fast restarts cleanly;
- must not drift out of sync with control opening and timer start.

Prompt-style description:
- large center-screen countdown for arcade race start, bold readable numerals, fast transition rhythm, clean shapes, energetic but minimal, strong focus, low visual noise.

### 3. Pause access
Purpose:
- give player safe session control.

Recommended placement:
- top-left or top-right;
- for MVP prefer top-left if timer is centered.

Visual description for UI/art:
- small, clearly recognizable system button;
- secondary emphasis;
- not visually louder than timer.

Programmer requirements:
- pause must stop active race safely;
- timer must freeze correctly;
- pause overlay must offer continue, restart and exit.

### 4. Finish signal
Purpose:
- confirm race completion.

Visual description for UI/art:
- brief center emphasis;
- may use a short `Finish` text or equivalent localized label;
- should feel clear and slightly celebratory without delaying the loop.

Programmer requirements:
- trigger once only;
- hand off quickly to result presentation.

### 5. Result panel
Purpose:
- show current result and drive replay.

Required content:
- current race time;
- best race time;
- new record label if applicable;
- primary restart action;
- secondary exit/back action.

Visual description for UI/art:
- centered or slightly lower-than-center result card;
- large current time as primary visual item;
- best time below or adjacent in lower emphasis;
- restart button clearly dominant;
- exit/back button visually secondary;
- should feel like a clean competitive summary, not a bloated menu.

Programmer requirements:
- panel must support two modes: normal finish and new best finish;
- panel data must come from `RaceResult` and local best comparison, not from hard-coded UI logic;
- restart action must be available immediately after safe presentation delay, if any.

Prompt-style description:
- clean result overlay for short competitive 2D racing game, large current time, smaller best time, clear new-record state, primary retry button, secondary exit button, low clutter, fast post-race readability, immediate replay motivation.

## Layout guidance
### Top zone
Use for:
- timer;
- pause access.

### Center zone
Use for:
- countdown;
- finish signal.

### Lower center zone
Use for:
- result overlay actions.

Do not place heavy permanent HUD over the most critical visible track region.

## Motion and transition rules
Allowed:
- short fade-in of HUD on scene start;
- short punch or pulse for countdown;
- quick finish confirmation;
- fast result overlay reveal.

Forbidden for MVP:
- long celebration sequences;
- exaggerated bounce animations;
- slow modal transitions that delay retry;
- decorative motion with no state readability value.

## Programmer implementation checklist
### Race state and services
- implement explicit race states;
- connect HUD visibility and behavior to state changes;
- ensure timer, finish and result use single sources of truth.

### Restart pipeline
On restart, reset at minimum:
- bike transform;
- rigidbody velocity or equivalent motion state;
- race timer state;
- finish state;
- countdown widget state;
- result panel state;
- temporary gameplay flags.

### Result pipeline
At finish:
- build `RaceResult`;
- compare against saved best for `map_01`;
- update save if `isNewBest`;
- optionally submit to `leaderboard_map_01` if integration is available;
- present overlay.

### Pause pipeline
Pause must:
- freeze race action safely;
- preserve resume state;
- allow restart and exit.

## HUD success criteria
The HUD and flow are successful if:
1. the player reaches active control quickly;
2. countdown is understandable and non-irritating;
3. timer is readable at a glance;
4. finish is unambiguous;
5. result screen clearly prioritizes retry;
6. restart feels faster than re-entering from menu.

## Failure signs
Rework is needed if:
- countdown feels longer than useful;
- timer is hard to read;
- overlays cover track-critical space;
- result screen feels like a full menu instead of a quick post-race state;
- restart causes state bugs or noticeable friction.
