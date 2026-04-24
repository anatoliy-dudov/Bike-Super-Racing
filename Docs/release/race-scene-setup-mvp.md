# Bike Super Racing — Race Scene Setup MVP

## Purpose
This document describes the minimal setup required to make `02_Race` playable with the current runtime baseline.

## Scene
Use scene name:
- `02_Race`

## Required objects

### 1. `RaceRoot`
Create an empty root object and add:
- `RaceFlowController`

Assign references:
- `Bike Transform` -> player bike root transform;
- `Bike Rigidbody2D` -> player bike rigidbody;
- `Bike Controller2D` -> `BikeController2D` on the bike root;
- `Bike Color Applier` -> `BikeColorApplier` on the bike root or child;
- `Control Behaviours` -> at minimum `BikeController2D`;
- `Start Point` -> start marker transform;
- `Finish Trigger` -> finish object with `FinishTrigger`;
- `RaceHudView` -> HUD object with `RaceHudView`;
- `CountdownWidget` -> countdown object with `CountdownWidget`;
- `ResultPanel` -> result overlay object with `ResultPanel`.

Recommended defaults:
- `Countdown Duration Seconds` = `5`;
- `Auto Start Countdown On Start` = enabled.

### 2. `BikeRoot`
Create the playable bike object and add:
- `Rigidbody2D`;
- at least one `Collider2D`;
- `BikeController2D`;
- `BikeColorApplier`.

Recommended Rigidbody2D baseline:
- `Body Type` = Dynamic;
- `Gravity Scale` > `0`;
- `Freeze Rotation` = disabled if the prototype needs physical rotation, enabled if the prototype uses only horizontal motion.

For MVP prototype, assign the bike sprite renderers to `BikeColorApplier`.

### 3. `StartPoint`
Create an empty transform where the bike should restart.

### 4. `FinishTrigger`
Create a finish-line object and add:
- `Collider2D` with `Is Trigger` enabled;
- `FinishTrigger`.

Assign:
- `Race Flow Controller` -> `RaceFlowController` on `RaceRoot`.

### 5. `RaceHudView`
Create a HUD object and add:
- `RaceHudView`.

Assign:
- timer text;
- optional pause button;
- optional root object.

### 6. `CountdownWidget`
Create a countdown object and add:
- `CountdownWidget`.

Assign:
- value text;
- optional root object.

### 7. `ResultPanel`
Create a result UI object and add:
- `ResultPanel`.

Assign:
- current time text;
- best time text;
- new-best root object;
- restart button;
- back button;
- optional root object.

## Config assets
Open Unity Editor and run:
- `Bike Super Racing/Setup/Create MVP Config Assets`

This creates or updates:
- `CFG_Game_Main`;
- `CFG_Map_Map01`;
- `CFG_Bike_Bike01`;
- `CFG_Color_Red`.

## Bootstrap dependency
Ensure `00_Bootstrap` contains a `Bootstrapper` with `CFG_Game_Main` assigned.

## Minimal playable check
The setup is considered valid when:
1. game starts through `00_Bootstrap`;
2. project can load `01_MainMenu`;
3. `02_Race` opens with `RaceFlowController` active;
4. countdown appears;
5. control opens after countdown;
6. timer starts with control opening;
7. crossing finish opens `ResultPanel`;
8. restart starts a new attempt without re-entering the menu.
