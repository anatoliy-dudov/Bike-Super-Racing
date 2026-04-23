# Bike Super Racing — MVP Progress Dashboard

## Purpose
This document provides a working dashboard template for the current MVP / vertical slice milestone.

It is not a historical report.
It is a live production status view designed to answer, at any moment:
- what already works in the playable loop;
- what is still missing;
- what is currently blocking the milestone;
- whether the build is in a `Go`, `At Risk` or `No-Go` state;
- which risks require immediate attention.

## Main use
This dashboard should be used in milestone syncs, status updates and cross-role check-ins.

The main goal is simple:

**allow the team to evaluate the real state of the MVP based on the playable race loop, not on vague impressions or raw task count.**

## Scope
This dashboard is for the current MVP only.

Current MVP scope:
- `map_01`;
- `bike_01`;
- `leaderboard_map_01`;
- one language;
- local save;
- cloud save stub;
- main menu entry;
- countdown;
- timer;
- finish;
- result screen;
- fast restart loop;
- minimal HUD.

Anything outside this set must be treated as:
- future scope;
- optional shell;
- or explicitly out of current milestone.

## Status legend
Use only these three states for milestone health:

### Go
The playable loop works, remaining issues are not serious enough to invalidate MVP proof.

### At Risk
The playable loop exists, but one or more serious weaknesses or blockers may still prevent MVP acceptance.

### No-Go
The playable loop is currently not valid for MVP proof because one or more core conditions fail.

## Recommended update cadence
Update this dashboard:
- after any meaningful loop-affecting milestone;
- after major QA smoke findings;
- before or after milestone review;
- when a previously assumed working system becomes unstable.

---

# Current milestone status template

## 1. Snapshot
### Current build / branch / reference
- Build / commit:
- Date:
- Owner updating status:

### Current milestone state
- Overall state: `Go / At Risk / No-Go`

### Short summary
- one-line status summary;
- one-line biggest blocker;
- one-line next most important action.

Example:
- overall state: `At Risk`;
- summary: playable loop exists but restart stability still blocks reliable MVP proof;
- next action: fix repeated restart state corruption in `02_Race`.

---

## 2. Go / No-Go gate
Fill every line with one of:
- `Yes`;
- `Partial`;
- `No`.

### Core gate questions
| Gate item | Status | Notes |
|---|---|---|
| App boots into `01_MainMenu` without manual intervention |  |  |
| Player can enter race quickly from main menu |  |  |
| `bike_01` is controllable enough for repeated testing |  |  |
| `map_01` supports a full start-to-finish run |  |  |
| Countdown and timer start correctly |  |  |
| Finish stops the timer correctly |  |  |
| Result screen appears and is readable |  |  |
| Restart works repeatedly without broken state |  |  |
| Best local time persists correctly |  |  |
| Leaderboard path is non-blocking |  |  |

### Go / No-Go interpretation rule
- if any core race-loop item is `No`, the build is normally `No-Go`;
- if most items are `Yes` but restart, feel, readability or persistence are unstable, the build is normally `At Risk`;
- the build should be `Go` only when the playable loop is real, stable and repeatable.

---

## 3. What already works
List only things that are verifiably working in the build.

Recommended structure:
- bootstrap and menu;
- race entry;
- active race;
- result;
- restart;
- save;
- leaderboard behavior.

Template:
- `00_Bootstrap` → `01_MainMenu` works;
- Race CTA opens `02_Race`;
- timer works;
- finish trigger works;
- result panel shows current time;
- restart works once / works repeatedly / still unstable;
- best time save works / partial / broken;
- leaderboard hook works / stubbed / blocking / non-blocking.

Important rule:
Do not list assumptions here.
Only list observed working behavior.

---

## 4. What is partially working
Use this section for systems that exist but are not yet stable enough to count as solved.

Template examples:
- `bike_01` is controllable but feel tuning is weak;
- `map_01` is playable but readability is inconsistent;
- result screen appears but hierarchy is still confusing;
- restart works but stale UI appears after repeated attempts.

This section is often the most useful for MVP work because it shows where “it exists” is not yet the same as “it is accepted”.

---

## 5. What is not working yet
List only current gaps that directly affect MVP validation.

Recommended categories:
- loop blockers;
- stability blockers;
- clarity blockers;
- persistence blockers.

Template examples:
- repeated restart still breaks timer state;
- finish sometimes fires twice;
- first-run best-result state is inconsistent;
- countdown is not synchronized with control opening.

Important rule:
If this list contains a core loop blocker, overall state is likely `No-Go` or `At Risk`.

---

## 6. Critical path status
Track the real critical path only.

Use one of:
- `Done`;
- `In Progress`;
- `Blocked`;
- `Not Started`.

| Critical path item | Status | Owner | Notes |
|---|---|---|---|
| Playable `02_Race` scene |  |  |  |
| Controllable `bike_01` |  |  |  |
| Playable `map_01` |  |  |  |
| Countdown / timer / finish chain |  |  |  |
| Result screen |  |  |  |
| Safe restart loop |  |  |  |
| Best local time save |  |  |  |
| Leaderboard non-blocking path |  |  |  |
| QA smoke validation of full loop |  |  |  |

Interpretation rule:
- if a critical path item is `Blocked`, the dashboard must explain the blocker explicitly in the next section;
- if several critical path items are `In Progress` but none are close to loop completion, milestone confidence should stay conservative.

---

## 7. Active blockers
List only real blockers, not inconveniences.

Required fields:
- blocker;
- blocked task or role;
- owner;
- expected unblock action;
- urgency.

Table template:
| Blocker | Blocks what | Owner | Unblock action | Urgency |
|---|---|---|---|---|
|  |  |  |  |  |

Example:
| Restart leaves stale race state | repeated loop validation | Unity programmer | centralize reset of timer/UI/finish flags | High |

Rule:
If a blocker affects the playable loop, it belongs here even if only one role currently feels its pain.

---

## 8. Active risk watchlist
This section is not the full risk register.
It is the small current watchlist for what is hottest right now.

Use the biggest 3–5 active risks from:
- `Docs/production/milestone-risk-register-for-mvp.md`.

Template:
| Risk | Probability | Impact | Current signal | Owner |
|---|---|---|---|---|
| Weak control feel in `bike_01` |  |  |  |  |
| `map_01` readability weakness |  |  |  |  |
| Restart loop instability |  |  |  |  |
| Scope drift into shell systems |  |  |  |  |
| Leaderboard blocking result/restart |  |  |  |  |

Rule:
This watchlist must stay short.
If everything is listed, nothing is prioritized.

---

## 9. QA smoke status
Use this block to summarize the current QA signal without copying full QA reports.

Template:
- last smoke run date:
- overall smoke result: `Pass / Partial / Fail`;
- most important failed smoke block:
- most important new regression:
- confidence in repeated race loop: `Low / Medium / High`.

Recommended sub-table:
| Smoke block | Status | Notes |
|---|---|---|
| Boot and menu |  |  |
| Race entry |  |  |
| Countdown and start |  |  |
| Active race and timer |  |  |
| Finish and result |  |  |
| Restart repetition |  |  |
| Best-time persistence |  |  |
| Leaderboard safe behavior |  |  |
| Browser layout sanity |  |  |

---

## 10. Scope control status
This block exists to protect the milestone from silent widening.

Template questions:
- Did any new feature enter current production this period? `Yes / No`
- If yes, was it classified against the MVP matrix? `Yes / No`
- Did any shell or future feature begin competing with the core loop? `Yes / No`
- Does current work still match first playable path with auto-selection of `map_01`, `bike_01`, `color_red`? `Yes / No`

If any answer creates concern, note it explicitly.

---

## 11. Cross-role status notes
Use this section to capture the most important coordination points.

Recommended categories:
- programmer ↔ design;
- design ↔ art;
- UI/UX ↔ programmer;
- QA ↔ implementation;
- PM/docs ↔ all roles.

Template examples:
- art waiting on final sprite pivot guidance for `bike_01`;
- UI/UX waiting on stable result-state hook;
- QA needs a build with stable repeated restart before next smoke pass.

This section is for coordination clarity, not for vague discussion logs.

---

## 12. Next 3 most important actions
Keep this section brutally short.

Format:
1. action;
2. owner;
3. expected direct effect on playable loop.

Template:
1. Fix repeated restart state reset — Unity programmer — enables reliable repeated loop testing.
2. Validate `map_01` readability in motion — design + art — reduces first-run confusion.
3. Re-run smoke on result / persistence — QA — confirms whether build is still `At Risk` or moves toward `Go`.

Rule:
These should be loop-critical actions, not generic activity fillers.

---

## 13. Dashboard summary decision rule
Use this simple decision logic:

### Mark `No-Go` when
- the player cannot complete the core loop reliably;
- result or restart are broken enough to invalidate retry behavior;
- persistence or finish logic breaks milestone proof.

### Mark `At Risk` when
- the loop exists but feel, readability, restart stability or persistence are still unstable enough to threaten acceptance.

### Mark `Go` when
- the loop is real, stable and repeatable;
- remaining issues are polish or low-severity risks, not proof-of-MVP failures.

---

## 14. Working update template
Copy and fill this for actual status updates.

```text
Date:
Build / commit:
Owner:
Overall state: Go / At Risk / No-Go

What already works:
- 
- 
- 

What is partially working:
- 
- 

What is not working yet:
- 
- 

Top blockers:
- 
- 

Top risks:
- 
- 

Next 3 actions:
1. 
2. 
3. 
```

---

## Acceptance checklist for the dashboard
This dashboard is functioning correctly if the team can answer yes to the following:
1. can we tell whether the build is Go / At Risk / No-Go quickly;
2. can we see what already works in the playable loop;
3. can we see what is still blocking acceptance;
4. can we see the current critical path state;
5. can we see whether scope drift is happening;
6. can we see the next most important actions without reading multiple chats.

---

## Final instruction
The first objective of this dashboard is not to look comprehensive.
The first objective is to make MVP truth visible.

If a status block does not help answer:
- does the playable race loop work;
- what still blocks acceptance;
- what should the team do next;
then it is probably not needed in this document.
