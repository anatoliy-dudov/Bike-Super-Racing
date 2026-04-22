# Bike Super Racing — First Tasks Pack for UI/UX

## Purpose
This document provides the first concrete implementation pack for the UI/UX role working on the MVP / vertical slice.

It is not a broad interface wishlist.
It is the ordered starting sequence for interface and flow work.

The document answers:
- what UI/UX to design first;
- what can stay minimal for MVP;
- how the interface should support the race loop;
- what layouts and states are mandatory;
- what counts as done before moving to the next UI task.

## Scope of this pack
This pack covers the first production-critical UI/UX slice only:
- main menu entry flow;
- race HUD;
- countdown presentation;
- result screen;
- restart-first post-race UX;
- minimal pause flow if included;
- minimal leaderboard and settings access points.

This pack does not attempt to complete:
- deep garage UX;
- daily reward UX;
- rich shell navigation;
- broad post-MVP menu systems;
- heavy transition polish;
- wide accessibility or customization layer beyond MVP minimum.

## Working rule
At every step, prefer:
- one extremely clear usable screen;
over
- many decorative but unfinished screens.

## Hard references
All UI/UX work must follow:
- `Docs/design/game-vision.md`;
- `Docs/design/core-gameplay-loop.md`;
- `Docs/design/race-flow-and-hud.md`;
- `Docs/design/result-screen-and-restart-loop.md`;
- `Docs/design/mvp-scope-and-feature-priority-matrix.md`;
- `Docs/art/art-direction-mvp.md`;
- `Docs/art/asset-list-mvp.md`;
- `Docs/architecture/naming-convention.md`.

## Global outcome target
At the end of this pack, the UI/UX role should have defined enough interface structure that the team can present a full MVP flow where:
- the player reaches the race quickly;
- the player understands countdown and timer immediately;
- the player reads the result instantly;
- restart is obviously the primary next action;
- the shell does not slow down the retry loop.

---

# Phase 1 — UI baseline and layout rules

## Goal
Lock the minimum layout logic so every later screen reinforces the same MVP priorities.

## Tasks
### 1.1 Define UI hierarchy for MVP
The hierarchy must be:
1. gameplay space;
2. countdown / finish signal when active;
3. timer;
4. result panel on post-race state;
5. secondary shell actions.

### 1.2 Define safe-area rules
The UI must support browser play and typical web aspect ratios.

Required rule set:
- no critical element too close to browser edges;
- no permanent HUD over the most important visible track band;
- clickable controls must remain comfortable on web layouts;
- top zone reserved for timer / system button;
- center zone reserved for countdown / finish signal;
- central-lower zone reserved for result panel.

### 1.3 Define typography / sizing logic
Even if final fonts are not selected yet, the following logic must be fixed:
- timer is compact but highly readable;
- countdown is large and dominant during countdown;
- current result is the largest item on the result screen;
- best result is clearly secondary;
- primary CTA is visually dominant over secondary CTA.

## Minimum output of Phase 1
After Phase 1, the project has a stable interaction and visual-priority baseline for all core MVP states.

## Definition of done for Phase 1
Phase 1 is done when any team member can explain where the player's eye should go in:
- main menu;
- active race;
- countdown;
- result screen.

---

# Phase 2 — Main menu race-first baseline

## Goal
Create the shortest possible clear menu entry into the race loop.

## Tasks
### 2.1 Define the first main menu layout
The first menu must support one main behavior:
- start race quickly.

Required visible actions for MVP:
- Race;
- Settings;
- Leaderboard.

Optional lower-priority placeholders only if cheap:
- Garage;
- Daily.

### 2.2 Define action hierarchy
Required hierarchy:
- Race is the primary CTA and must read first;
- Settings and Leaderboard are secondary;
- Garage and Daily, if shown, must not compete with Race.

### 2.3 Define browser-friendly menu behavior
The menu should feel:
- immediate;
- low-friction;
- readable with minimal text;
- not like a deep shell hub.

Prompt-style UX note:
- the player should think “start the race” before thinking “explore the shell”.

## Minimum output of Phase 2
A menu wireframe or production-ready layout exists that clearly routes the player into the race flow.

## Definition of done for Phase 2
A first-time tester can identify the Race entry point immediately without guidance.

---

# Phase 3 — Race HUD baseline

## Goal
Define the minimum HUD needed for gameplay without covering track readability.

## Tasks
### 3.1 Timer placement and behavior
Required decision:
- timer in the top-center zone.

UX requirements:
- readable at a glance;
- not too large;
- stable width behavior;
- readable against varying race background.

### 3.2 Pause access placement
Required decision:
- pause access in a top corner, preferably top-left if timer is centered.

UX requirements:
- visible when needed;
- not visually competing with timer or track.

### 3.3 HUD clutter control
The first HUD must show only what is needed:
- timer;
- optional pause;
- countdown when active.

The HUD must not include extra noise in MVP.

### 3.4 Define active race readability test
In a static review and during gameplay review, verify:
- timer is readable in under one second;
- HUD does not cover critical terrain;
- the player's gaze stays on the track, not on the UI.

## Minimum output of Phase 3
The active race HUD is defined as a minimal readable layer rather than a generic game overlay.

## Definition of done for Phase 3
A teammate looking at the race screen understands what matters immediately and does not feel that the HUD fights the gameplay layer.

---

# Phase 4 — Countdown presentation

## Goal
Make race start clear, focused and short.

## Tasks
### 4.1 Define countdown layout
Countdown should appear in the center.

Required states:
- 3;
- 2;
- 1;
- Go / Start equivalent.

### 4.2 Define animation / transition intent
Allowed behavior:
- short pop or fade emphasis;
- very quick timing;
- strong readability.

Forbidden behavior for MVP:
- long flashy countdown sequence;
- animation that hides bike and start position too long;
- visual complexity that slows repeated restarts.

### 4.3 Define repeated-use behavior
Countdown must remain tolerable after many restarts.

UX requirements:
- no irritating delay;
- no excessive anticipation;
- still clear on the tenth attempt, not only the first.

## Minimum output of Phase 4
Countdown is defined as a focused start ritual, not a showpiece.

## Definition of done for Phase 4
The countdown helps the player prepare, but does not feel like it is wasting session time.

---

# Phase 5 — Result screen and restart-first hierarchy

## Goal
Define the post-race screen so it converts a completed run into another attempt.

## Tasks
### 5.1 Define result panel layout
Required information order:
1. current time;
2. best time;
3. new best state if applicable;
4. primary restart button;
5. secondary exit/back button.

### 5.2 Define CTA hierarchy
Required visual priority:
- restart must be visually dominant;
- exit must be readable but clearly secondary.

### 5.3 Define first-run behavior
The UI must support a clean first-run state where:
- the current time may become the first best time;
- the panel does not look empty or confusing;
- the player does not question whether the result saved.

### 5.4 Define new-best state
The new-best state should feel rewarding, but:
- must not slow down restart;
- must not add a long forced celebration;
- must not re-layout the whole panel awkwardly.

### 5.5 Define optional leaderboard bridge
A very lightweight leaderboard bridge is allowed only if:
- it does not compete with restart;
- it stays visually tertiary.

## Minimum output of Phase 5
The result screen is fully defined as a functional conversion screen for the retry loop.

## Definition of done for Phase 5
A tester looking at the result state knows in under one second:
- how they did;
- whether they improved;
- what to press next.

---

# Phase 6 — Restart experience and transition behavior

## Goal
Ensure the UI side of restart preserves session momentum.

## Tasks
### 6.1 Define result-to-restart transition behavior
Restart should feel:
- immediate;
- safe;
- continuous.

The UI should not create a sensation of leaving the session and re-entering it from scratch.

### 6.2 Define button states and input clarity
Required behaviors:
- primary button clearly interactive;
- no ambiguous disabled state without reason;
- no possibility of confusing restart and exit.

### 6.3 Define motion budget for post-race UI
Allowed:
- short panel reveal;
- fast button hover / press response;
- light new-best emphasis.

Forbidden:
- long delayed CTA availability;
- slow dissolves that postpone interaction;
- bulky panel choreography.

## Minimum output of Phase 6
The UI side of restart supports the game's main behavioral loop instead of interrupting it.

## Definition of done for Phase 6
Repeated races do not make the UI feel slow or menu-heavy.

---

# Phase 7 — Settings and leaderboard minimal overlays

## Goal
Support required shell functions without turning them into blockers or visual detours.

## Tasks
### 7.1 Define minimal settings popup
Settings popup must support only what MVP truly needs:
- music volume;
- SFX volume;
- simple close / back action.

UX rule:
- settings must be easy to leave;
- settings must not become a deep subflow.

### 7.2 Define minimal leaderboard popup
Leaderboard popup must support:
- readable leaderboard list or placeholder-ready structure;
- clear return action;
- map-specific association with `leaderboard_map_01`.

UX rule:
- leaderboard is useful, but not the primary route during first playable validation;
- it must not compete with the race entry CTA on the main menu.

## Minimum output of Phase 7
The shell is minimally complete for MVP without creating extra complexity.

## Definition of done for Phase 7
The player can access settings and leaderboard, understand them, and return to the main flow without friction.

---

# Phase 8 — Browser polish and responsive sanity pass

## Goal
Make sure the UI remains readable and usable in realistic browser play conditions.

## Tasks
### 8.1 Review key layouts across browser sizes
At minimum review:
- main menu;
- active HUD;
- countdown;
- result panel.

### 8.2 Validate click target comfort
Buttons must not become too small or too close together on practical browser sizes.

### 8.3 Validate result readability
The result panel must remain readable even when the browser window is not ideal.

## Minimum output of Phase 8
The core UI flow holds up under likely MVP play conditions.

## Definition of done for Phase 8
The UI remains readable, actionable and restart-friendly across the main target browser layouts.

---

# Immediate task order summary
For convenience, here is the strict first-order sequence:
1. define hierarchy and safe-area rules;
2. define the race-first main menu;
3. define the minimal race HUD;
4. define countdown presentation;
5. define result screen hierarchy;
6. define restart transition behavior;
7. define minimal settings and leaderboard overlays;
8. validate browser readability and interaction comfort.

If priorities conflict, follow this list.

---

# What can stay low-priority or placeholder in this pack
The UI/UX role may keep these minimal or deferred:
- garage UX;
- daily rewards UX;
- extended leaderboard navigation;
- secondary menu states;
- heavy transition polish;
- decorative panel variants;
- non-essential animation flourishes.

These must not block the core race loop.

---

# What must not be postponed in this pack
Do not postpone:
- Race CTA clarity in the main menu;
- timer readability;
- countdown readability;
- result screen hierarchy;
- restart-first post-race action design;
- responsive browser sanity.

These are foundational and expensive to fix late if ignored.

---

# Hand-off expectations to Unity and Art
## Needed from Art
- clean low-noise assets for timer support, countdown, buttons and result panel;
- readable icons and panel backings;
- no text-heavy baked graphics unless justified.

## Needed from Unity programmer
- stable race-state hooks;
- predictable state transitions for countdown, finish and result;
- restart event that can be reflected cleanly in UI.

## Needed from Design
- confirmation of interaction hierarchy;
- confirmation of MVP-cut decisions when scope pressure appears.

---

# Acceptance checklist for UI/UX
This pack is complete when all statements below are true:
1. the main menu clearly prioritizes starting the race;
2. the race HUD is readable and low-noise;
3. the countdown is instantly understandable;
4. the result screen clearly prioritizes current result and restart;
5. exit is visibly secondary to restart;
6. settings and leaderboard do not overcomplicate the shell;
7. the UI remains usable in browser-scale play;
8. the overall interface feels like it serves the retry loop, not competes with it.

---

# Final instruction to the UI/UX role
The first objective is not to make the interface look feature-rich.
The first objective is to make the player reach the race quickly, understand the result instantly and restart naturally.

If a UI element does not help validate:
- race entry clarity;
- active race readability;
- post-race restart behavior;
then it is probably not the next UI task.
