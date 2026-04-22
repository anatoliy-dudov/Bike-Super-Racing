# Bike Super Racing — MVP Acceptance Criteria & Go/No-Go Checklist

## Purpose
This document defines the formal acceptance criteria for the MVP / vertical slice and provides a clear Go / No-Go checklist for milestone review.

It is intended to help the team answer one practical question:

**Is the current build a valid MVP candidate that proves the intended game loop, or is it still not ready to move forward?**

This document is not a backlog.
It is a decision gate.

## Scope of this document
This acceptance gate applies to the current MVP boundary only:
- `map_01`;
- `bike_01`;
- `leaderboard_map_01`;
- one playable race loop;
- one language;
- local save;
- cloud save stub;
- countdown;
- timer;
- finish;
- result;
- restart;
- minimal menu flow.

This document does not evaluate:
- post-MVP content width;
- extra maps;
- extra bikes;
- deep shell systems;
- advanced retention systems;
- long-term monetization or live ops readiness.

## Core acceptance statement
The MVP can be accepted only if the team can honestly say:

**The player can launch the game, enter the race quickly, complete one readable short run, understand the result immediately, and naturally want one more attempt.**

If this statement is weak, the answer is `No-Go`.

## Decision model
Use three possible states:

### Go
The build satisfies the required MVP criteria and is valid for the next step.

### Conditional Go
The build satisfies the core loop criteria but still contains a small number of known non-critical issues that do not invalidate the MVP proof.

### No-Go
The build fails one or more core acceptance criteria and should not be treated as a valid MVP milestone candidate.

## Acceptance rule priority
When criteria conflict, use this priority order:
1. playable loop integrity;
2. readability and control feel;
3. result and restart conversion;
4. persistence correctness;
5. non-blocking leaderboard behavior;
6. shell completeness;
7. cosmetic polish.

This means a beautiful shell cannot compensate for a broken restart loop.

---

# Section 1 — Mandatory acceptance criteria

The following criteria are mandatory.
A failure in any of these can trigger `No-Go`.

## 1. Boot and entry
### Criterion 1.1 — App reaches playable entry state
The build must:
- launch successfully;
- complete bootstrap;
- reach `01_MainMenu` without manual editor intervention.

Pass condition:
- the tester reaches a usable main menu from a normal launch path.

No-Go if:
- the build does not boot into a valid menu state;
- the player cannot reach gameplay entry reliably.

### Criterion 1.2 — Race entry is obvious
The menu must make Race entry the primary action.

Pass condition:
- a first-time tester can identify the race-start path immediately.

No-Go if:
- starting the race is unclear enough to block first-use understanding.

---

## 2. Race loop existence
### Criterion 2.1 — `bike_01` is controllable
The player must be able to control `bike_01` in a stable way on `map_01`.

Pass condition:
- the bike can complete a usable run;
- control is stable enough for repeated testing.

No-Go if:
- the bike is functionally broken;
- the bike cannot support meaningful loop validation.

### Criterion 2.2 — `map_01` supports one complete readable run
The track must allow a full start-to-finish run and be readable enough for the player to understand the challenge.

Pass condition:
- the tester can complete a full run;
- the tester can identify terrain changes and major challenge moments.

No-Go if:
- the track is incompletable;
- the track is so unreadable that first-loop validation becomes unreliable.

### Criterion 2.3 — Countdown, timer and finish are synchronized
The start and finish logic must be coherent.

Pass condition:
- countdown is readable;
- timer starts with actual race start;
- finish stops the timer once;
- the race transitions correctly to result state.

No-Go if:
- timer is invalid;
- finish is invalid;
- countdown-to-start logic is broken enough to invalidate timing.

---

## 3. Result and restart
### Criterion 3.1 — Result screen is immediately understandable
The result state must clearly present:
- current time;
- best time;
- restart as the primary next action.

Pass condition:
- the tester understands the result without confusion;
- the tester can identify the next action instantly.

No-Go if:
- result state is missing;
- result state is broken;
- restart is unclear enough to break the post-race loop.

### Criterion 3.2 — Restart loop is stable across repeated runs
Restart must work not only once, but repeatedly.

Pass condition:
- the tester can complete and restart several runs in one session;
- timer, UI and control remain stable;
- no stale result state leaks into the next race.

No-Go if:
- repeated restart causes corruption;
- restart breaks the loop;
- restart becomes unreliable under repeated use.

### Criterion 3.3 — Result converts into replay desire
The build must support the intended product behavior: the player wants another run.

Pass condition:
- internal testers naturally use restart after finishing;
- the post-race flow does not feel like a detour.

No-Go if:
- the race can technically complete but the finish-to-restart loop feels weak enough that the core product promise is not proven.

Note:
This criterion includes informed design judgment, not only pure bug status.

---

## 4. Persistence and competition support
### Criterion 4.1 — Best local result persists correctly
The game must save and reload best result data for the MVP loop.

Pass condition:
- a better run updates best time;
- the best time survives relaunch.

No-Go if:
- best time logic is broken enough to invalidate the mastery loop.

### Criterion 4.2 — Leaderboard path is non-blocking
Leaderboard integration may succeed, fail or be stubbed.
The key rule is that it must not block result and restart.

Pass condition:
- result screen and restart remain available regardless of leaderboard path outcome.

No-Go if:
- leaderboard behavior blocks or corrupts the local race loop.

---

## 5. Browser and readability sanity
### Criterion 5.1 — Core UI remains usable in practical browser play
The MVP must remain readable enough in real browser conditions.

Pass condition:
- race CTA remains clear;
- timer remains readable;
- countdown remains readable;
- result screen remains readable;
- buttons are usable.

No-Go if:
- browser presentation prevents meaningful evaluation of the MVP loop.

### Criterion 5.2 — Art supports gameplay clarity
The current art level must support readable play.

Pass condition:
- `bike_01` reads clearly as the player object;
- `map_01` remains visually readable;
- VFX do not obscure the loop.

No-Go if:
- art currently destroys clarity enough to invalidate loop testing.

---

# Section 2 — Conditional Go criteria

A build may still receive `Conditional Go` if all mandatory criteria pass and the remaining issues meet all of the following conditions:
- they do not break the playable loop;
- they do not break result/restart behavior;
- they do not make first-minute experience misleading;
- they can be clearly tracked and fixed without redesigning the core loop.

Examples of issues compatible with `Conditional Go`:
- minor UI alignment problems;
- low-priority icon or shell placeholder issues;
- cosmetic VFX or polish deficiencies;
- non-blocking visual inconsistency;
- non-critical secondary popup roughness.

Examples of issues not compatible with `Conditional Go`:
- unstable restart;
- invalid timer;
- inconsistent finish state;
- broken best-time persistence;
- race CTA not obvious;
- bike or track not readable enough to validate the loop.

---

# Section 3 — Go / No-Go review checklist

Use the following checklist during milestone review.

## Build integrity
- [ ] Build launches and reaches main menu normally.
- [ ] No critical blocker prevents race entry.

## Race entry and first minute
- [ ] Race entry is the clearest main action.
- [ ] Countdown is readable.
- [ ] Timer starts in sync with control.
- [ ] The player can understand the beginning of the race quickly.

## Active race
- [ ] `bike_01` is controllable enough for repeated runs.
- [ ] `map_01` is readable enough for meaningful improvement.
- [ ] The player can finish a full run.

## Finish and result
- [ ] Finish triggers once and correctly.
- [ ] Current result is clearly displayed.
- [ ] Best result is clearly displayed.
- [ ] Restart is visually and interaction-wise the primary next action.

## Restart loop
- [ ] One restart works correctly.
- [ ] Several restarts in sequence work correctly.
- [ ] No stale UI, timer or state leakage appears after repeated restarts.

## Persistence
- [ ] Best local time updates correctly.
- [ ] Best local time survives relaunch.

## Leaderboard safety
- [ ] Leaderboard path does not block result.
- [ ] Leaderboard path does not block restart.

## Browser sanity
- [ ] Main menu is usable in practical browser size.
- [ ] HUD is readable in practical browser size.
- [ ] Result screen is readable in practical browser size.

## Product proof
- [ ] Internal testers naturally choose to retry after finishing.
- [ ] The build proves the intended short competitive retry loop.

## Final decision
- [ ] Go
- [ ] Conditional Go
- [ ] No-Go

---

# Section 4 — Automatic No-Go triggers

The build should automatically be considered `No-Go` if any of the following is true:
- the game does not reliably boot into a valid menu;
- the player cannot reliably enter the race;
- the bike cannot support a meaningful run;
- the track cannot support a meaningful full run;
- timer logic is invalid;
- finish logic is invalid;
- result screen is missing or functionally broken;
- restart is unstable across repeated use;
- best-time persistence is broken;
- leaderboard behavior blocks the local loop;
- browser presentation prevents readable MVP evaluation;
- the build does not create believable replay desire after the first run.

---

# Section 5 — Review procedure

## Step 1 — Smoke validation
Run the current QA smoke pack:
- `Docs/production/qa-smoke-pack-for-mvp.md`.

If critical blockers appear, the default result is `No-Go`.

## Step 2 — Cross-role review
Collect short review input from:
- Unity programmer;
- lead game designer;
- artist / pixel artist;
- UI/UX;
- QA;
- Documentation / PM.

Focus only on loop-critical issues.

## Step 3 — Product judgment
Ask the short product question:

**Does this build already prove the intended experience of short, readable, replay-driven racing?**

If the answer is weak, the build should not receive full `Go` even if many technical boxes are checked.

## Step 4 — Decide and record
Record one of:
- Go;
- Conditional Go;
- No-Go.

Also record:
- unresolved high-priority issues;
- exact reason for Conditional Go or No-Go;
- required next actions before the next review.

---

# Section 6 — What should not block Go

The following should not block a `Go` or `Conditional Go` if the playable loop is proven and stable:
- placeholder-grade low-priority shell visuals;
- minor icon polish issues;
- lack of deeper garage flow;
- lack of daily reward implementation;
- lack of extra maps or extra bikes;
- low-priority menu polish;
- non-critical decorative VFX gaps.

This section exists to stop the team from delaying milestone acceptance for issues outside the MVP proof.

---

# Section 7 — What must block Go

The following must block `Go`:
- control feel too weak to sustain replay desire;
- unreadable `map_01`;
- broken timer, finish or result;
- unstable restart loop;
- broken local mastery loop through save issues;
- broken first-minute readability;
- shell or service logic that blocks the core race loop.

This section exists to stop the team from accepting a milestone because the build “looks complete enough” while the actual product proof is still weak.

---

# Section 8 — Acceptance notes template

Use the following lightweight structure when recording the review outcome:

## Build / reference
- build or commit identifier:

## Decision
- Go / Conditional Go / No-Go:

## Reason
- short explanation focused on core loop validity:

## Remaining issues
- only unresolved issues relevant to milestone decision:

## Required next actions
- the smallest set of actions needed before the next review:

---

# Acceptance checklist for this document itself
This acceptance document is functioning correctly if the team can answer yes to the following:
1. can we tell whether the build is truly MVP-valid without subjective drift;
2. do we know which failures are automatic No-Go triggers;
3. can we separate loop-critical issues from non-blocking polish issues;
4. does the checklist help the team stop false-positive milestone acceptance.

---

# Final instruction for milestone decision
The first objective is not to approve a milestone quickly.
The first objective is to approve it honestly.

If the build does not yet prove:
- readable short racing;
- meaningful result;
- immediate replay desire;
then the correct decision is `No-Go`, even if many supporting systems already exist.
