# Bike Super Racing — MVP Scope & Feature Priority Matrix

## Purpose
This document fixes the product boundary for the MVP / vertical slice and protects the first release from scope drift.

## Main rule
A feature belongs in MVP only if it helps prove the core product promise:
- good control feel;
- readable short race;
- meaningful result;
- immediate retry desire.

If it does not strengthen one of these, it is not a near-MVP feature.

## MVP scope
The MVP includes:
- 1 track: `map_01`;
- 1 bike: `bike_01`;
- 1 leaderboard: `leaderboard_map_01`;
- 1 language;
- local save;
- cloud save stub;
- main menu entry to race;
- countdown;
- timer;
- finish;
- result screen;
- quick restart;
- minimal HUD.

## Priority categories
### Must have
Without this, the vertical slice fails to prove the game.

### Should have
This strengthens the product, but the MVP can still exist without it if needed.

### Could have
Useful later or only if very cheap. Must not compete with must-have work.

### Out of scope
Not for the MVP production phase.

## Feature matrix
| Feature | Priority | Why |
|---|---|---|
| `map_01` playable race track | Must have | the vertical slice needs one real track |
| `bike_01` playable bike | Must have | the game needs one complete controllable vehicle |
| timer | Must have | race result has no meaning without it |
| countdown | Must have | supports start clarity and rhythm |
| finish detection | Must have | required for complete run loop |
| result screen | Must have | required for evaluation and replay desire |
| quick restart | Must have | required for retry loop |
| local best time | Must have | supports immediate mastery loop |
| `leaderboard_map_01` | Must have | supports competition motivation |
| local save | Must have | persists best result and minimal player state |
| minimal HUD | Must have | supports active race readability |
| pause | Must have | expected session control in MVP |
| best-time display in result flow | Should have | strong replay support at modest cost |
| settings for music and SFX | Should have | improves player comfort with limited scope |
| simple color selection | Should have | cheap personalization if pipeline exists |
| lightweight garage shell | Should have | can support product shell without becoming meta |
| daily quest shell | Could have | retention value exists but not core-proof critical |
| second bike | Could have | useful after first bike feel is proven |
| additional maps | Could have | content width after vertical slice proof |
| advanced stat differentiation | Could have | not required for MVP proof |
| deep progression systems | Out of scope | risks masking weak core loop |
| complex economy | Out of scope | high cost, low MVP proof value |
| heavy monetization | Out of scope | premature and potentially harmful to first experience |
| multiple race modes | Out of scope | dilutes focus from the main loop |
| seasonal/live-ops systems | Out of scope | not needed before core proof |
| deep customization suite | Out of scope | shell-first feature, not loop-first |

## Core blocks by category
### Core gameplay
Must have:
- responsive bike control;
- readable track;
- one complete start-to-finish loop;
- understandable penalties through time and rhythm loss.

Should have:
- basic polish for feel and result readability.

Could have:
- expanded race feedback systems.

### UX and race flow
Must have:
- short path into race;
- clear start;
- clear finish;
- result-to-restart priority.

Should have:
- minor transition polish.

Could have:
- extra presentation layers.

### Shell systems
Must have:
- menu entry and exit;
- save and best result persistence.

Should have:
- lightweight settings;
- lightweight shell framing.

Could have:
- daily hooks;
- wider shell loops.

## Decision filter for new ideas
For every new idea, answer:
1. does it strengthen active racing;
2. does it strengthen first-minute understanding;
3. does it strengthen replay desire;
4. is it cheap enough for MVP;
5. does it avoid scope drift.

If the answer is weak on multiple points, the idea should not enter current production priority.

## Scope drift warning signs
Scope is drifting if:
- new shell systems appear faster than race polish;
- the team discusses content quantity more than control feel;
- retry loop polish is delayed for secondary features;
- more than one map or bike starts competing with finishing `map_01` and `bike_01`;
- heavy future-oriented systems become blockers for the first playable build.

## Enforcement rule
When a new task is proposed, it should be labeled explicitly as:
- Must have;
- Should have;
- Could have;
- Out of scope.

This document is the default source of truth for that label during MVP development.
