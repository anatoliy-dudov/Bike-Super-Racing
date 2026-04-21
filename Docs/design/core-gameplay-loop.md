# Bike Super Racing — Core Gameplay Loop

## Purpose
This document fixes the central gameplay loop, the first minute expectation and the required race-phase logic for the MVP.

## Central player action
The central player action is:

**ride a short track cleanly and quickly, then retry to improve the time.**

This is the nucleus of the product.

## Core loop
### High-level loop
- enter the game;
- start a race;
- control the bike through a short challenge;
- finish and get a result;
- compare the result with expectation or best time;
- restart immediately.

### Race-phase loop
- `PreStart`;
- `Countdown`;
- `RaceActive`;
- `RaceFinished`;
- `ResultPresentation`;
- `RestartRequested`.

## Why this loop matters
The game is not built around collection, economy or long progression first.
It is built around:
- one good attempt;
- one understandable mistake;
- one meaningful result;
- one immediate retry.

## Phase breakdown
### 1. Entry to attempt
Player action:
- choose race;
- enter track scene;
- see the start position.

Player feeling target:
- I am about to race;
- the path into gameplay was short;
- the game respects my time.

### 2. Countdown
Player action:
- prepare for control opening.

Player feeling target:
- I understand when the attempt starts;
- the race is about to begin.

### 3. Active race
Player action:
- control the bike;
- read the track;
- keep rhythm;
- avoid mistakes;
- try to finish cleanly.

Player feeling target:
- the bike responds clearly;
- mistakes are understandable;
- I can already imagine doing better.

### 4. Finish
Player action:
- cross the finish line.

Player feeling target:
- the attempt is complete;
- the result is meaningful.

### 5. Result
Player action:
- read time;
- compare with best;
- decide what to do next.

Player feeling target:
- I know how well I did;
- retry is the natural next action.

### 6. Retry
Player action:
- start another attempt.

Player feeling target:
- the loop continues with very low friction.

## First minute experience
The first minute is critical because this is a browser-first arcade product.

The player should understand in the first minute:
1. this is a short race game;
2. the bike is controllable;
3. the track must be read, not just rushed blindly;
4. mistakes cost time;
5. another attempt can already be better.

## First minute target timeline
### 0–10 seconds
The player sees a clear way to start racing.

### 10–20 seconds
The player enters the race and reads the countdown.

### 20–45 seconds
The player takes control, reads the first track section and makes one understandable mistake or one clean move.

### 45–60 seconds
The player finishes or gets close to finishing and understands that the result can be improved.

## Core loop drivers
The loop depends on four drivers:
- control;
- readability;
- meaningful result;
- low-friction retry.

If one of these breaks, the loop weakens.

## What strengthens the loop
- responsive bike control;
- readable track geometry;
- short countdown;
- clear timer;
- quick result screen;
- highly visible restart action;
- understandable best-time comparison.

## What weakens the loop
- confusing control;
- unreadable obstacles;
- heavy overlays during race;
- long pause between finish and retry;
- result screens with low action clarity;
- extra shell steps between attempts.

## Design rule for new mechanics
Any new mechanic must answer yes to most of the following:
- does it make active riding more interesting;
- does it make failure more understandable;
- does it create replay desire;
- does it fit MVP cost and scope.

If not, it is not a near-term priority.

## Success test
The core loop works if, after one finished attempt, the player thinks:

**I know at least one place where I can do better, and I want another run now.**
