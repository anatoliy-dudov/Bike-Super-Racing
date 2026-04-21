# Bike Super Racing — Game Vision

## Purpose
This document fixes the core product vision for Bike Super Racing and serves as the source of truth for gameplay, UX, content scope and feature prioritization.

## Game definition
Bike Super Racing is a 2D arcade competitive motorcycle racing game inspired by Excite Bike and targeted at Yandex Games / WebGL.

The product is built around:
- short playable sessions;
- readable race challenge;
- strong control feel;
- fast retry loop;
- skill-based result improvement.

## Product goal
The first release must prove one thing clearly:

**riding the bike feels good, the track is readable, the result matters and the player wants one more attempt immediately after finishing.**

## Player fantasy
The player fantasy is:

**I jump into a short race, feel in control, make mistakes, understand them, improve my time and want to retry immediately.**

This fantasy is more important than content width in MVP.

## Target player motivation
The core target motivations are:
- `mastery` — improve driving skill and clean execution;
- `competition` — compare times and chase a better result;
- `short-session replayability` — play again quickly without heavy preparation.

## Design pillars
### 1. Instantly readable control and bike behavior
The bike must react clearly and predictably.

### 2. Short competitive retry loop
The path from finish to the next attempt must stay short and low-friction.

### 3. Skill first, systems second
The player must improve mainly through better play, not through heavy external systems.

### 4. Minimal UX friction
Menus and overlays must support the race, not compete with it.

### 5. Foundation for growth without MVP overload
The project must be expandable, but the first version must stay narrow and focused.

## Core loop
High-level loop:
- enter the game;
- choose the race;
- start the attempt;
- drive the track;
- finish;
- see the result;
- restart immediately to improve.

## Core product promise
The product promise is not wide content or deep meta.
The product promise is:
- good control feel;
- readable challenge;
- meaningful race result;
- immediate replay desire.

## MVP boundary
The MVP / vertical slice includes:
- 1 track: `map_01`;
- 1 bike: `bike_01`;
- 1 leaderboard: `leaderboard_map_01`;
- 1 language;
- local save;
- cloud save stub;
- minimal menu flow;
- race flow with countdown, timer, finish, result and restart.

## What MVP must prove
The first playable version must prove:
1. the first race is understandable;
2. control feel is pleasant enough to replay;
3. the track is readable enough to learn from mistakes;
4. the result screen strengthens the desire to retry;
5. the leaderboard supports the competition motivation.

## What MVP is not trying to prove
The MVP is not trying to prove:
- deep progression;
- wide content library;
- complex economy;
- heavy monetization;
- multiple game modes;
- advanced live ops.

## UX intent
The game should feel fast to enter and fast to repeat.

The player should not spend more energy on navigation than on racing.

The UI must therefore be:
- simple;
- clear;
- low-noise;
- action-oriented.

## Track design intent
The first track must function as both:
- a real challenge;
- an onboarding experience.

It must teach through play, not through long explanations.

## Result screen intent
The result screen is not just a reporting screen.
It is a replay driver.

It must make the next action obvious:
- retry first;
- leave second.

## Growth direction after MVP
After the first strong vertical slice is validated, the project may grow through:
- more tracks;
- more bikes;
- more cosmetic options;
- light retention systems;
- wider progression shell.

Growth must never weaken the central loop.

## Anti-vision list
The project should not drift toward:
- content-first development before the core loop works;
- UI-heavy flow that slows down retries;
- progression systems that compensate for weak gameplay;
- decorative complexity that reduces readability;
- feature accumulation without product proof.

## Core success sentence
If the team needs one sentence to evaluate a new idea, use this:

**Does this make the player want to press restart after finishing the race?**

If the answer is weak or unclear, the idea is not near-MVP priority.
