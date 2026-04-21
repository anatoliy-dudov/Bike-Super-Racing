# Bike Super Racing — Result Screen & Restart Loop

## Purpose
This document fixes the design, UX intent, UI structure and implementation expectations for the post-race result state and the immediate restart loop in the MVP.

It is written to be usable by:
- gameplay programmers;
- UI programmers;
- UI/UX designers;
- artists creating result screen assets and UI states;
- production planning chats that need a shared baseline.

## Product role of the result screen
The result screen is not a passive summary screen.
For Bike Super Racing it is one of the most important conversion points in the entire product.

Its job is to turn:
- one finished race;
into
- one more attempt.

If the result screen fails to do this, the core retry loop weakens even if the race itself is good.

## Product role of restart
Restart is not a convenience option.
It is a core product action.

The game promise is strongly tied to this behavior:
- the player finishes;
- the player understands the result;
- the player wants to try again immediately;
- the game lets the player do so with minimal friction.

## Core success sentence
The result phase is successful if the player thinks:

**I see exactly how I did, and pressing restart is the most natural next action.**

## Scope and assumptions
This document is written for the MVP / vertical slice where the game includes:
- `map_01`;
- `bike_01`;
- `leaderboard_map_01`;
- local save;
- cloud save stub;
- one short competitive race loop.

The result screen in MVP must stay compact and focused.
It must not grow into a large meta hub.

## Result state goals
The result state must do five things well:
1. confirm that the race is finished;
2. show the final time clearly;
3. compare the result against the best known result;
4. make restart the primary next action;
5. optionally connect the player mentally to leaderboard competition.

## Restart loop goals
The restart loop must do four things well:
1. preserve session momentum;
2. avoid unnecessary menu friction;
3. reset the race reliably and quickly;
4. encourage another mastery attempt instead of breaking flow.

## High-level flow
Recommended post-finish flow:
- race finishes;
- finish signal confirms completion;
- result data is built;
- result overlay appears;
- player reads current result and best result;
- restart is visually dominant;
- player presses restart;
- race state resets cleanly;
- player returns to `PreStart` or `Countdown`.

## State relationship
This document assumes the race-state baseline from `Docs/design/race-flow-and-hud.md`.

Relevant states here:
- `RaceFinished`;
- `ResultPresentation`;
- `RestartRequested`.

The result screen must be driven by these states.
The restart loop must not be built from scattered UI-only hacks.

## Result screen design principles
### 1. Time first
The result screen must visually prioritize the final race time above every other data point.

### 2. Comparison second
The next most important information is whether the player improved relative to the best result.

### 3. Action third
The most important action is restart, and it must be obvious.

### 4. Exit is secondary
Leaving the loop must stay available but must not compete visually with retry.

### 5. No clutter
Any information that does not directly support understanding or replay should be excluded from MVP.

## Required information hierarchy
The result screen should present information in this priority order:
1. current race result;
2. best race result;
3. new record state if applicable;
4. primary restart CTA;
5. secondary exit/back CTA;
6. optional lightweight leaderboard hint.

## Result screen modes
The result screen must support at least two core modes.

### Mode A — normal finish
Used when the player finishes the race but does not beat the best known local result.

Player feeling target:
- I completed the attempt;
- I can see the number to beat;
- I want another try.

### Mode B — new best result
Used when the player beats the best known local result.

Player feeling target:
- I improved;
- this run mattered;
- I still want another run to push even further.

Important rule:
A new best state should feel rewarding, but it must not slow restart so much that it damages the retry loop.

## Result screen composition
Recommended composition for MVP:
- one centered result container or panel;
- one large current time block;
- one smaller best-time block;
- one optional short `New Best` label or badge;
- one primary restart button;
- one secondary back / menu button.

## Detailed visual specification
### Result container / panel
Role:
- organize all post-race information in a stable readable area.

Visual description for UI/art:
- centered or slightly lower-than-center panel;
- simple shape language;
- clear silhouette;
- minimal decorative frame;
- high readability on top of race background;
- should feel competitive and clean, not casual-mobile noisy.

Prompt-style description:
- minimal result overlay panel for a 2D competitive arcade racing game, centered, clean silhouette, readable on bright and dark backgrounds, light semi-transparent backing, simple frame, low clutter, modern arcade sport feeling.

Programmer requirements:
- panel visibility should be controlled by result state;
- panel show/hide must be deterministic and reusable after every restart;
- panel must support normal and record variants without duplicating separate UI scenes.

### Current time block
Role:
- display the just-finished result as the primary piece of information.

Visual description for UI/art:
- largest text element on the screen;
- strong contrast;
- centered or near-centered alignment inside the result panel;
- must dominate visually over all secondary information;
- should feel like a competitive result, not generic body text.

Prompt-style description:
- large competitive race time display, bold readable numerals, strong hierarchy, clean typography, immediate scan readability, esports-like clarity without heavy ornament.

Programmer requirements:
- value comes directly from the authoritative `RaceResult`;
- formatting must be consistent with the in-race timer;
- text width changes must not cause visible layout jumps.

### Best time block
Role:
- frame the new result against prior performance.

Visual description for UI/art:
- clearly visible but smaller than current time;
- placed directly below or adjacent with lower emphasis;
- label + value pattern recommended;
- should never overpower the current result.

Prompt-style description:
- secondary best-time info row, smaller than main result, supportive hierarchy, clean label-value structure, competitive context, subtle but readable.

Programmer requirements:
- source of truth must be local best data from save or profile service;
- when no best result exists yet, define one stable first-run behavior;
- avoid null-state UI bugs or placeholder junk text.

### New Best label / badge
Role:
- highlight improvement when the player beats their previous best.

Visual description for UI/art:
- small but clear celebratory accent;
- can be a badge, ribbon or short line of text;
- should feel rewarding but not oversized;
- use motion lightly if any.

Prompt-style description:
- compact new-best indicator for a racing result screen, confident and rewarding, small celebratory accent, clean modern arcade styling, not flashy enough to delay replay.

Programmer requirements:
- show only when `RaceResult.isNewBest == true`;
- must not reserve awkward empty space when absent unless layout intentionally supports it;
- should integrate cleanly with both first-run and repeat-run states.

### Restart CTA
Role:
- make the next attempt the dominant post-race action.

Visual description for UI/art:
- largest actionable element;
- easy to scan and easy to click/tap;
- visually more important than exit;
- should communicate speed, immediacy and continuation.

Recommended label options:
- `Restart`;
- `Try Again`;
- equivalent concise localized label.

Prompt-style description:
- primary retry button for arcade race result screen, large, confident, clean, highly clickable, visually dominant, immediate next-action energy, competitive but not flashy, low friction.

Programmer requirements:
- button becomes interactable as soon as result presentation reaches safe actionable state;
- button must not require a confirmation dialog;
- repeated rapid clicks must not break state machine;
- input handling must debounce or gate duplicate restart requests safely.

### Exit / Back CTA
Role:
- allow leaving the result loop without competing with restart.

Visual description for UI/art:
- secondary button style;
- clearly readable but less visually weighted;
- smaller or less saturated treatment than restart.

Prompt-style description:
- secondary back-to-menu button for racing result screen, readable, clean, clearly lower emphasis than primary retry, quiet but accessible.

Programmer requirements:
- cleanly route back to menu or track selection according to current flow baseline;
- must not visually steal focus from restart;
- must remain safe to trigger after repeated race sessions.

## Optional leaderboard bridge for MVP
A full leaderboard screen is not part of the result panel itself.
However, the result screen may include a lightweight leaderboard bridge such as:
- a small line hinting that time is recorded;
- a compact `View Leaderboard` secondary or tertiary action;
- a simple status note when leaderboard submission succeeded.

Rule:
This must never overshadow restart.

## First-run behavior
The system must handle the first completed race gracefully.

Expected behavior options:
- current time displayed as the first best time;
- `New Best` state shown because there was no prior best;
- best-time block presented in a stable way without confusing empty placeholders.

The player should not need to infer whether the run saved correctly.

## Post-finish emotional sequence
The intended emotional sequence is:
1. completion — I finished;
2. evaluation — I see my time;
3. comparison — I see how good it is;
4. motivation — I know whether I can improve;
5. continuation — I restart immediately.

If the player instead feels:
- uncertainty;
- menu fatigue;
- too much waiting;
- result overload;
then the result phase has failed its product role.

## Restart loop rules
### Rule 1. Restart must be faster than re-entering from menu
This is non-negotiable for the MVP.

### Rule 2. Restart must feel safe and deterministic
No partial reset states, no physics leftovers, no timer drift.

### Rule 3. Restart must preserve the sense of session continuity
The player should feel like they are still in the same competitive session.

### Rule 4. Restart must not be visually or technically noisy
No large scene transition theatrics if they slow down retry.

## Recommended restart pipeline
### Step 1 — request restart
Player presses primary restart CTA.

### Step 2 — lock duplicate input
System prevents duplicate restart submissions.

### Step 3 — reset gameplay truth
The system resets:
- race state;
- bike position;
- bike velocity and temporary runtime values;
- timer state;
- finish flags;
- result UI state;
- countdown state;
- temporary VFX or camera effects if any.

### Step 4 — re-enter race start flow
Return to `PreStart` or directly into `Countdown` depending on chosen race-flow implementation.

### Step 5 — resume active race loop
The player quickly regains readiness for the next attempt.

## Programmer implementation checklist
### Data and state
- `RaceResult` must be created once at finish;
- local best comparison must happen before result UI is finalized;
- result UI must read data, not calculate gameplay truth;
- restart must be handled by explicit race-state transition.

### Save behavior
At finish:
- compare current time against local best for `map_01`;
- if improved, update local save;
- keep data schema stable for future growth.

### Leaderboard behavior
If integration is active:
- submit result through `ILeaderboardService`;
- failure should not block result presentation or restart.

### Input safety
- prevent double-trigger restart bugs;
- prevent restart and exit firing in same frame;
- restore clean input state after reset.

### UI safety
- no stale result text after restart;
- no record badge remaining visible on the next normal run;
- no disabled buttons carrying into the next race cycle;
- panel animations must not stack after repeated races.

## Layout guidance
### Central area
Use for:
- main result container;
- current time block;
- new best indicator.

### Lower area of result panel
Use for:
- primary restart CTA;
- secondary exit/back CTA.

### Safe-area rule
Buttons must remain comfortably accessible on browser layouts and typical web aspect ratios.

## Motion guidance
Allowed:
- short result panel fade or rise-in;
- light emphasis on current time;
- small accent on new best state;
- fast responsive button hover/press states.

Forbidden for MVP:
- long celebratory sequences;
- full-screen fireworks-style overpresentation;
- forced delay before restart becomes available;
- over-animated button choreography.

## Result screen copy guidance
Text should stay short and functional.

Recommended labels:
- `Result` or equivalent;
- `Best` or `Best Time`;
- `New Best`;
- `Restart`;
- `Back to Menu`.

Avoid verbose copy that slows scanning.

## Success metrics for internal evaluation
The result screen and restart loop are working well if internal testers report:
1. the final time is instantly readable;
2. the restart button is obviously the main action;
3. the result state feels short and satisfying;
4. the next run starts quickly;
5. there are no confusing post-race dead moments.

## Failure signs
The result phase needs rework if:
- players hesitate after finishing because the next action is unclear;
- exit competes visually with restart;
- new best state feels underwhelming or confusing;
- restart causes inconsistent timer or control bugs;
- the result overlay feels like a menu detour instead of a race-loop continuation.

## MVP must-have checklist
- current race time display;
- best time display;
- new-best state support;
- primary restart CTA;
- secondary exit/back CTA;
- stable first-run behavior;
- safe restart pipeline;
- no leaderboard submission hard-blocking the loop.

## Should-have checklist
- lightweight leaderboard bridge;
- small UI polish for record state;
- stable button focus / hover polish for browser play.

## Could-have checklist
- richer leaderboard entry action;
- nuanced celebratory animation;
- comparative delta versus best time.

## Final design rule
When in doubt, choose the option that makes the player restart faster while still understanding the result clearly.

That rule is more valuable for MVP than any extra decoration or extra menu option.
