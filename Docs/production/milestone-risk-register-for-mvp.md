# Bike Super Racing — Milestone Risk Register for MVP

## Purpose
This document fixes the active risk register for the MVP / vertical slice milestone.

It is intended to keep the team focused on risks that can invalidate the first real playable loop.

The document answers:
- what the main milestone risks are;
- why they matter;
- how likely and how damaging they are;
- what mitigation is expected;
- who should be watching each risk.

## Scope of this register
This risk register covers MVP-critical risks only.
It does not attempt to forecast every long-term production issue.

Priority is given to risks that threaten:
- the playable race loop;
- the MVP boundary;
- the critical path;
- first-minute experience;
- result / restart behavior;
- production alignment between roles.

## Risk scoring model
Use a practical 3-level model.

### Probability
- Low;
- Medium;
- High.

### Impact
- Low;
- Medium;
- High.

### Response priority
A risk should be treated as high-priority when:
- probability is High, or
- impact is High, or
- it directly threatens the core playable loop.

## Risk ownership rule
Every risk should have a watching owner.
The owner is responsible for surfacing the risk early, not necessarily for solving it alone.

---

# Active MVP risk register

## Risk 1 — Weak control feel in `bike_01`
### Description
The bike may become technically functional but not enjoyable or readable enough to support repeated attempts.

### Why it matters
The whole product is built around retry desire.
If control feel is weak, UI, art and shell systems will not rescue the MVP.

### Probability
- High.

### Impact
- High.

### Signals
- testers can complete a run but do not want another;
- complaints focus on “it feels wrong”, “slippery”, “unclear”, or “not fun”; 
- design discussions keep shifting toward shell features instead of feel fixes.

### Mitigation
- prioritize a controllable, tunable first bike baseline early;
- test repeatedly before expanding scope;
- keep feel iteration above shell work.

### Owner
- Unity programmer + lead game designer.

---

## Risk 2 — `map_01` is completable but not readable
### Description
The first track may exist physically but fail to teach, fail to communicate terrain clearly, or fail to create meaningful improvement opportunities.

### Why it matters
The track must serve onboarding, challenge and replayability at the same time.
Unreadable track design damages first-minute experience and mastery loop.

### Probability
- High.

### Impact
- High.

### Signals
- players cannot explain where they lost time;
- first runs feel chaotic rather than instructive;
- design feedback repeatedly references confusion rather than challenge.

### Mitigation
- build the first track as a teaching race, not a random obstacle strip;
- validate readability before decoration;
- keep level design aligned with onboarding and difficulty docs.

### Owner
- lead game designer + Unity programmer + artist.

---

## Risk 3 — Result screen does not convert into restart
### Description
The result phase may become informative but not motivating, or may bury restart behind low-priority actions.

### Why it matters
The result screen is one of the most important conversion points in the game.
If it does not push replay, the core loop weakens.

### Probability
- Medium.

### Impact
- High.

### Signals
- testers hesitate after finishing;
- exit competes visually with restart;
- result screen feels like a menu detour;
- post-race flow feels slow.

### Mitigation
- maintain current result-first, restart-first hierarchy;
- keep new-best reward light and fast;
- test result readability under browser conditions.

### Owner
- UI/UX + lead game designer + Unity programmer.

---

## Risk 4 — Restart loop accumulates broken state
### Description
Restart may appear to work once but degrade after repeated use because timer, bike state, finish flags or UI state are not fully reset.

### Why it matters
The game relies on repeated attempts in one session.
Broken restart behavior directly invalidates the MVP proof.

### Probability
- High.

### Impact
- High.

### Signals
- second or third restart behaves differently from the first;
- stale UI remains visible;
- timer drift appears;
- result state leaks into the next race;
- physics state feels inconsistent after restart.

### Mitigation
- implement explicit restart pipeline;
- run repeated restart smoke tests early;
- keep race-state ownership centralized.

### Owner
- Unity programmer + QA.

---

## Risk 5 — Scope drift toward shell systems
### Description
The team may spend energy on Garage, Daily, extra shell flow, extra content or broad polish before the playable race loop is stable.

### Why it matters
MVP success depends on one strong loop, not on broad coverage.
Scope drift can delay proof of fun and fragment team effort.

### Probability
- High.

### Impact
- High.

### Signals
- growing task lists for non-race systems;
- secondary features discussed more often than bike feel and result/restart;
- must-have and should-have work getting mixed together.

### Mitigation
- enforce MVP classification on every new task;
- protect the critical path;
- cut shell work first when schedule pressure appears.

### Owner
- lead game designer + Documentation / PM.

---

## Risk 6 — Naming drift between docs, code and art
### Description
Different roles may begin using different names for the same entity, scene, prefab or config.

### Why it matters
Naming drift slows integration, creates hidden bugs and makes cross-chat collaboration unreliable.

### Probability
- Medium.

### Impact
- High.

### Signals
- one entity appears under multiple names in repo or chat;
- code, art and docs refer to the same object differently;
- new assets arrive without canonical prefixes.

### Mitigation
- enforce `Docs/architecture/naming-convention.md` as source of truth;
- require updates there before new canonical entities are added;
- review new docs and assets for naming consistency.

### Owner
- Documentation / PM + all leads.

---

## Risk 7 — UI and art polish outrun gameplay validation
### Description
The project may start looking more complete while the actual race loop remains unstable or unproven.

### Why it matters
Visual progress can create false confidence if control feel, finish logic or restart are still weak.

### Probability
- Medium.

### Impact
- Medium to High.

### Signals
- many new UI or art assets arrive, but the loop still breaks in smoke tests;
- discussions focus on appearance while core bugs remain;
- polished menu screens exist before stable restart.

### Mitigation
- sequence work around the playable loop;
- tie polish work to loop validation milestones;
- maintain “readability before decoration” as art/UI rule.

### Owner
- producer / PM + lead game designer.

---

## Risk 8 — Browser readability issues late in development
### Description
UI, track readability or scaling may work in editor-like conditions but become unclear in practical browser windows.

### Why it matters
The target environment is browser play.
Late discovery of readability issues can cause expensive rework in UI, scale and composition.

### Probability
- Medium.

### Impact
- Medium to High.

### Signals
- timer becomes hard to read in browser;
- result panel feels cramped;
- race CTA loses clarity on real window sizes;
- track or bike readability drops at intended display scale.

### Mitigation
- run browser-size sanity passes early;
- keep UI simple and high-contrast;
- validate in representative play conditions, not only in ideal editor view.

### Owner
- UI/UX + QA + artist.

---

## Risk 9 — Leaderboard integration blocks local MVP loop
### Description
Platform or service integration may fail or remain unfinished and accidentally block result presentation or restart.

### Why it matters
The leaderboard is valuable, but the local replay loop must remain functional without it.

### Probability
- Medium.

### Impact
- High.

### Signals
- result screen waits on leaderboard path;
- leaderboard errors interrupt finish flow;
- restart is delayed or blocked by service behavior.

### Mitigation
- keep leaderboard path non-blocking;
- support safe stub behavior;
- treat result/restart as higher priority than service success.

### Owner
- Unity programmer + QA.

---

## Risk 10 — Incomplete blocker visibility across roles
### Description
A role may be blocked but the rest of the team does not see it early enough, causing idle time or duplicate work.

### Why it matters
The MVP has a narrow critical path.
Hidden blockers waste time and create false schedule confidence.

### Probability
- Medium.

### Impact
- High.

### Signals
- work stalls quietly;
- repeated clarifications appear late;
- tasks stay “in progress” without movement;
- dependent roles wait without explicit blocker status.

### Mitigation
- track blockers explicitly with owners;
- use lightweight milestone status updates;
- raise blocker state immediately instead of waiting for the next large sync.

### Owner
- Documentation / PM.

---

## Risk 11 — QA starts too late for repeated-loop issues
### Description
If QA only enters after the build appears visually complete, repeated restart and persistence problems may be discovered too late.

### Why it matters
Restart reliability and save stability are central MVP risks that benefit from early repeated testing.

### Probability
- Medium.

### Impact
- Medium to High.

### Signals
- first repeated restart stress happens very late;
- result/persistence bugs cluster near milestone close;
- the team relies on casual ad hoc self-testing instead of repeatable smoke checks.

### Mitigation
- start smoke testing as soon as the first full loop exists;
- run restart and persistence checks often;
- use QA smoke pack continuously, not only at the end.

### Owner
- QA + PM.

---

## Risk 12 — Documentation baseline becomes stale while production moves
### Description
Repo docs may stop reflecting production reality if changes continue only in chat or code.

### Why it matters
This project depends heavily on repo docs as cross-chat alignment tools.
Stale docs undermine all role packs and future decisions.

### Probability
- Medium.

### Impact
- High.

### Signals
- repeated phrases like “docs are outdated”; 
- new role assumptions appear without matching repo updates;
- README index no longer reflects current files.

### Mitigation
- update docs when decisions become official;
- treat repo docs as source of truth;
- keep README in sync with new production docs.

### Owner
- Documentation / PM.

---

# Top-priority watchlist
For the current MVP phase, the following risks should stay under the strongest attention:
1. weak control feel in `bike_01`;
2. unreadable or poorly teaching `map_01`;
3. broken or slow restart loop;
4. scope drift into shell or extra content;
5. leaderboard or service logic blocking result/restart.

These should be reviewed first whenever milestone confidence is questioned.

---

# Risk review cadence
Recommended cadence:
- quick review whenever a major loop-affecting change lands;
- dedicated review on milestone candidate builds;
- immediate update when a previously hypothetical risk becomes active reality.

## Minimum review questions
1. does this risk threaten the playable race loop now;
2. has probability increased;
3. has impact increased;
4. do we have a clear owner and mitigation;
5. does the repo documentation need an update because of this risk.

---

# Risk response rule
When schedule pressure rises, the team should protect:
- playable loop stability;
- control feel;
- readable track;
- result and restart integrity;
- local persistence.

And cut first:
- decorative shell expansion;
- extra content width;
- non-critical polish;
- non-essential UI richness.

This rule should guide risk response decisions.

---

# Acceptance checklist for the risk register
The risk register is functioning if the team can answer yes to the following:
1. do we know the highest risks to the MVP loop;
2. does each major risk have an owner;
3. are mitigations visible before failure happens;
4. can the team distinguish loop-threatening risks from low-priority polish issues;
5. does the register help cut the right things under pressure.

---

# Final instruction for risk handling
The first objective is not to eliminate all uncertainty.
The first objective is to spot the risks that can destroy the MVP proof early enough to act on them.

If a risk threatens:
- race readability;
- retry loop integrity;
- MVP boundary;
- alignment between roles;
then it deserves earlier attention than cosmetic or post-MVP concerns.
