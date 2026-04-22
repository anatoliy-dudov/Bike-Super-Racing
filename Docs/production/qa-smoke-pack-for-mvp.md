# Bike Super Racing — QA Smoke Pack for MVP

## Purpose
This document provides the first QA smoke pack for the MVP / vertical slice.

It is designed to help QA validate the real playable loop quickly and repeatedly.

The document answers:
- what to test first;
- what counts as a critical blocker;
- what smoke scenarios must pass before the build can be considered a valid MVP candidate;
- how to structure repeated loop testing around the game's real core risk areas.

## Scope of this pack
This smoke pack covers only the MVP-critical slice:
- bootstrap;
- main menu entry;
- race start;
- countdown;
- active race;
- timer;
- finish;
- result screen;
- restart loop;
- local best result persistence;
- leaderboard hook or safe non-blocking behavior if available.

This pack does not attempt to fully cover:
- deep garage behavior;
- daily rewards systems;
- post-MVP content;
- wide compatibility matrix beyond a practical MVP sanity pass.

## Working rule
The goal of smoke testing is not to prove the build is perfect.
The goal is to prove the core loop is real, stable and repeatable.

## Hard references
QA validation must follow:
- `Docs/design/game-vision.md`;
- `Docs/design/core-gameplay-loop.md`;
- `Docs/design/race-flow-and-hud.md`;
- `Docs/design/result-screen-and-restart-loop.md`;
- `Docs/design/mvp-scope-and-feature-priority-matrix.md`;
- `Docs/production/task-breakdown-for-mvp-milestone.md`.

## MVP truth statement for QA
The MVP is behaving correctly when the tester can:
- launch the game;
- enter the race quickly;
- control the bike on `map_01`;
- complete a full run;
- see a clear result;
- restart and repeat the loop several times without state corruption.

## Severity baseline for this pack
### Critical blocker
A defect is critical if it breaks the playable race loop or makes the build not valid for MVP verification.

Examples:
- cannot reach main menu;
- cannot enter race;
- bike is uncontrollable;
- timer does not start or stop correctly;
- finish does not trigger;
- result screen fails to appear;
- restart breaks the scene or locks the game;
- best time persistence corrupts core result logic.

### Major
A defect is major if the loop still exists but quality or clarity is damaged enough that core MVP validation becomes unreliable.

Examples:
- countdown timing is wrong but race still runs;
- result hierarchy is confusing;
- restart works but leaves frequent stale UI or motion artifacts;
- timer is readable only with effort.

### Minor
A defect is minor if the core loop remains valid and the issue can be postponed without invalidating MVP proof.

Examples:
- low-priority icon misalignment;
- placeholder art mismatch that does not affect readability;
- secondary popup polish issues.

## Recommended smoke order
Run tests in this order:
1. application boot;
2. menu entry and menu clarity;
3. race entry;
4. countdown and control opening;
5. active race and timer;
6. finish and result;
7. restart loop repetition;
8. local best persistence;
9. leaderboard non-blocking behavior;
10. browser-size sanity pass.

If a critical blocker appears early, stop broad smoke and return the issue immediately.

---

# Smoke block 1 — Boot and menu entry

## Goal
Verify that the player can reach a valid starting point for the loop.

## Test 1.1 — Launch to main menu
### Preconditions
- build launches from a clean state.

### Steps
1. launch the game;
2. wait for bootstrap;
3. observe landing state.

### Expected result
- bootstrap completes without blocking the user;
- `01_MainMenu` appears;
- no manual editor actions are required;
- the build does not hang or show broken transition state.

### Severity if failed
- critical.

## Test 1.2 — Race CTA visibility
### Steps
1. observe the main menu;
2. identify the primary action.

### Expected result
- Race entry is the clearest main action;
- the tester can identify how to start the race immediately;
- shell actions do not visually overpower race start.

### Severity if failed
- major if playable but confusing;
- critical if race cannot be entered.

---

# Smoke block 2 — Entering the race

## Goal
Verify that the menu-to-race transition works reliably.

## Test 2.1 — Start race from menu
### Steps
1. open main menu;
2. press the Race action.

### Expected result
- the build enters `02_Race` cleanly;
- the player reaches the race scene without broken transition state;
- no dead-end menu or extra blocking shell steps appear.

### Severity if failed
- critical.

## Test 2.2 — Race scene baseline readiness
### Steps
1. enter race;
2. observe the pre-race setup.

### Expected result
- the bike is visible at the start;
- the track is visible enough to understand the scene;
- the HUD is not in a broken or overlapping state.

### Severity if failed
- major if scene is messy but playable;
- critical if scene cannot progress.

---

# Smoke block 3 — Countdown and race start

## Goal
Verify that the player understands when the race begins and that control opening matches race start logic.

## Test 3.1 — Countdown readability
### Steps
1. enter race;
2. observe the countdown.

### Expected result
- countdown is readable immediately;
- sequence is clear;
- countdown does not visually break the start view.

### Severity if failed
- major.

## Test 3.2 — Countdown-to-control sync
### Steps
1. observe countdown;
2. note when control becomes active;
3. note when timer starts.

### Expected result
- control opening matches countdown completion;
- timer starts in sync with actual race start;
- no obvious delay or desync is present.

### Severity if failed
- critical if severe enough to invalidate the race;
- major otherwise.

---

# Smoke block 4 — Active race and timer

## Goal
Verify that the playable loop exists during actual riding.

## Test 4.1 — Bike control baseline
### Steps
1. start the race;
2. attempt to drive across the first sections of `map_01`.

### Expected result
- the bike responds in a stable way;
- the tester can progress through the track;
- movement is not broken enough to invalidate the loop.

### Severity if failed
- critical.

## Test 4.2 — Timer during race
### Steps
1. begin race;
2. observe timer during active movement.

### Expected result
- timer runs continuously during the race;
- timer is readable;
- timer does not freeze, jump or remain at zero.

### Severity if failed
- critical if timer does not function;
- major if function exists but readability is poor.

## Test 4.3 — Track readability sanity
### Steps
1. drive through the main sections of `map_01`;
2. note whether the terrain can be read while moving.

### Expected result
- the tester can tell where flat, slope, ramp and finish-relevant areas are;
- the track is not visually confusing enough to invalidate first-loop testing.

### Severity if failed
- major.

---

# Smoke block 5 — Finish and result screen

## Goal
Verify that a completed run transitions cleanly into a readable result state.

## Test 5.1 — Finish trigger
### Steps
1. complete a full run;
2. cross the finish area.

### Expected result
- finish triggers once;
- timer stops once;
- race transitions into result presentation.

### Severity if failed
- critical.

## Test 5.2 — Result panel readability
### Steps
1. finish the race;
2. observe the result screen.

### Expected result
- current result is clearly visible;
- best result is visible and secondary;
- restart is visibly the main action;
- exit/back is present and secondary.

### Severity if failed
- major if readable with effort;
- critical if result state is broken or missing.

## Test 5.3 — First-run result behavior
### Preconditions
- use a clean save if possible.

### Steps
1. launch fresh build state;
2. complete first race;
3. observe result panel.

### Expected result
- the panel behaves cleanly even without previous best data;
- no placeholder junk values or confusing empty state appears;
- if first run becomes best run, the state remains understandable.

### Severity if failed
- major.

---

# Smoke block 6 — Restart loop repetition

## Goal
Verify that restart is stable over repeated use.

## Test 6.1 — Single restart
### Steps
1. finish a run;
2. press restart.

### Expected result
- race resets cleanly;
- countdown and timer return correctly;
- bike returns to valid start state;
- result panel disappears properly.

### Severity if failed
- critical.

## Test 6.2 — Repeated restart stress
### Steps
1. complete one run;
2. restart;
3. repeat the race and restart cycle at least 5 times.

### Expected result
- no state corruption accumulates;
- no stale UI remains;
- timer remains correct;
- control remains stable;
- finish and result remain correct each cycle.

### Severity if failed
- critical.

## Test 6.3 — Rapid restart interaction safety
### Steps
1. finish race;
2. press restart rapidly or multiple times if possible.

### Expected result
- duplicate restart input does not break flow;
- the game processes one safe restart path.

### Severity if failed
- major or critical depending on severity.

---

# Smoke block 7 — Best-time persistence

## Goal
Verify that local best result supports the mastery loop.

## Test 7.1 — First best-time save
### Steps
1. finish a valid race;
2. record displayed result;
3. observe whether it becomes best time when appropriate.

### Expected result
- best time data updates correctly;
- result and best result do not contradict each other.

### Severity if failed
- critical if persistence is broken enough to invalidate result progression;
- major otherwise.

## Test 7.2 — Better second result
### Steps
1. set an initial best time;
2. complete a better run;
3. observe result screen.

### Expected result
- new best state appears when appropriate;
- best time updates correctly;
- current and best result remain logically consistent.

### Severity if failed
- major.

## Test 7.3 — Persistence after relaunch
### Steps
1. set a best time;
2. close the application;
3. relaunch;
4. return to the relevant result or best-time display path.

### Expected result
- best result persists across app relaunch;
- no save corruption is visible.

### Severity if failed
- critical.

---

# Smoke block 8 — Leaderboard safe behavior

## Goal
Verify that leaderboard presence or absence does not break the MVP loop.

## Test 8.1 — Submission does not block result
### Preconditions
- leaderboard hook is enabled or stubbed.

### Steps
1. finish race;
2. allow leaderboard submission attempt or stub path to run.

### Expected result
- result screen appears regardless of leaderboard outcome;
- restart remains available regardless of leaderboard outcome.

### Severity if failed
- critical.

## Test 8.2 — Graceful failure path
### Preconditions
- use a state where leaderboard integration is unavailable or fails.

### Steps
1. finish race;
2. observe post-finish flow.

### Expected result
- no hard block occurs;
- no crash occurs;
- retry loop remains intact.

### Severity if failed
- critical.

---

# Smoke block 9 — Browser and layout sanity

## Goal
Verify that the MVP loop remains understandable under basic real-use browser conditions.

## Test 9.1 — Main menu sanity at practical browser sizes
### Steps
1. open the build in a practical browser window;
2. review the menu layout.

### Expected result
- race CTA remains obvious;
- menu remains readable;
- critical buttons are not clipped.

### Severity if failed
- major.

## Test 9.2 — HUD sanity at practical browser sizes
### Steps
1. run a race;
2. inspect timer, countdown and result panel readability.

### Expected result
- timer remains readable;
- countdown remains readable;
- result panel fits and remains clear;
- critical UI does not overlap in a destructive way.

### Severity if failed
- major.

---

# Recommended smoke cadence
Use this cadence during active MVP work:
- run Smoke blocks 1–6 on every build that changes race flow;
- run Smoke block 7 on every build that changes result or save logic;
- run Smoke block 8 on builds that touch leaderboard path;
- run Smoke block 9 on milestone candidate builds and browser-facing UI changes.

---

# Exit rule for smoke session
End the smoke session immediately and return a blocker if any of the following occurs:
- cannot enter race;
- bike cannot complete a usable run;
- timer is invalid;
- finish does not trigger correctly;
- result state is missing or broken;
- restart corrupts the scene;
- best time persistence is invalid;
- leaderboard flow blocks retry.

These issues invalidate MVP verification.

---

# Reporting format recommendation
For each found issue, QA should log at minimum:
- title;
- severity;
- exact build or commit reference if available;
- reproduction steps;
- expected result;
- actual result;
- loop impact category:
  - Entry;
  - Race;
  - Result;
  - Restart;
  - Persistence;
  - Layout.

This helps the team triage against the real MVP loop.

---

# Acceptance checklist for QA smoke pack
This smoke pack is successful when the QA role can reliably answer yes to the following:
1. can the build boot into the menu;
2. can the player enter the race quickly;
3. can the player complete a valid run on `map_01`;
4. do countdown and timer behave correctly;
5. does finish produce a correct result state;
6. is restart clearly usable and stable across repeated loops;
7. does best-time persistence work;
8. does leaderboard behavior remain non-blocking;
9. does the browser-visible UI remain readable enough for MVP evaluation.

---

# Final instruction to QA
The first objective is not to find every cosmetic flaw.
The first objective is to prove whether the playable race loop is stable, readable and repeatable.

If a bug prevents the team from validating:
- entering the race;
- completing a run;
- understanding the result;
- restarting immediately;
then it is the right place to spend attention first.
