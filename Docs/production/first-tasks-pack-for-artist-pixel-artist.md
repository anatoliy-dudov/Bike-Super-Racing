# Bike Super Racing — First Tasks Pack for Artist / Pixel Artist

## Purpose
This document provides the first concrete production pack for the artist / pixel artist working on the MVP / vertical slice.

It is not a broad art wishlist.
It is the ordered starting sequence for art production.

The document answers:
- what to draw first;
- what level of finish is required at each step;
- what must be readable in motion and in the browser;
- what can stay placeholder-grade for now;
- what naming to use;
- what counts as done before moving to the next art step.

## Scope of this pack
This pack covers the first production-critical art slice only:
- `bike_01`;
- `map_01` playable track visuals;
- minimum background for `map_01`;
- minimum race HUD support assets;
- countdown assets;
- result screen support assets;
- minimum VFX needed for one complete race loop.

This pack does not attempt to complete:
- `bike_02`;
- additional maps;
- wide shell art for Garage or Daily;
- rich menu polish;
- expensive cosmetic animation;
- broad post-MVP decorative content.

## Working rule
At every step, prefer:
- one clearly readable usable asset set;
over
- a large pile of half-finished decorative assets.

## Hard references
All art production must follow:
- `Docs/art/art-direction-mvp.md`;
- `Docs/art/asset-list-mvp.md`;
- `Docs/architecture/naming-convention.md`;
- `Docs/design/game-vision.md`;
- `Docs/design/race-flow-and-hud.md`;
- `Docs/design/result-screen-and-restart-loop.md`;
- `Docs/design/mvp-scope-and-feature-priority-matrix.md`.

## Global outcome target
At the end of this pack, the artist should have produced enough art that the team can run a complete MVP loop where:
- the bike is readable;
- the track is readable;
- countdown is readable;
- timer support is readable;
- result screen hierarchy is readable;
- basic VFX support motion without noise.

The result does not need final post-MVP polish.
It must be integration-ready and product-useful.

---

# Phase 1 — Visual baseline lock and canvas setup

## Goal
Prepare the minimum technical and visual baseline so all later sprites follow one grid, one silhouette logic and one naming system.

## Tasks
### 1.1 Confirm pixel grid and working sizes
Work with the already fixed baseline:
- base grid: `16x16 px`;
- bike + rider working canvas: `64x40 px`;
- wheel diameter: `12–16 px`;
- track tile baseline: `16x16 px`;
- small VFX: `8x8`, `16x16` or `32x16 px`;
- UI elements aligned to `8 px` rhythm where practical.

### 1.2 Prepare palette baseline
Prepare a clean limited MVP palette grouped by:
- sky / far background;
- track / ground;
- track edge / risky zones;
- bike / rider;
- VFX;
- UI.

Required output:
- one working palette sheet or clearly grouped production reference file.

### 1.3 Confirm naming-ready export structure
Prepare export folders or PSD / Aseprite structure so that output names can map directly to canonical asset names such as:
- `SPR_Bike_Bike01_Body`;
- `SPR_Bike_Bike01_WheelFront`;
- `SPR_Bike_Bike01_WheelRear`;
- `SPR_Rider_Bike01_Base`;
- `SPR_Map_Map01_Tile_Ground_A`;
- `SPR_UI_ResultPanel_Background`.

## Minimum output of Phase 1
After Phase 1, production can begin without drifting into random size, palette or naming decisions.

## Definition of done for Phase 1
Phase 1 is done when the artist can start creating final-named production sprites immediately, without later re-baselining the whole set.

---

# Phase 2 — `bike_01` silhouette and main readable body set

## Goal
Create the single most important visual object in the MVP: the readable playable bike.

## Tasks
### 2.1 Create `SPR_Bike_Bike01_Body`
This is the anchor asset for the whole race.

Detailed visual target:
- side-view sporty arcade motorcycle silhouette;
- lightweight, fast-feeling shape;
- readable separation between front and rear body mass;
- clear seat / body / front section split;
- medium-low detail only;
- no tiny mechanical clutter that disappears at speed.

The body must feel:
- sporty;
- compact;
- quick;
- stable in profile.

It must not feel:
- too heavy;
- too realistic and technical;
- too toy-like;
- too noisy.

Prompt-style execution note:
- pixel art side-view arcade sport bike, clean silhouette, compact fast profile, low noise, medium-low detail, readable at speed, built for 2D racing game, no tiny engine clutter, strong shape clarity.

### 2.2 Create wheel sprites
Create:
- `SPR_Bike_Bike01_WheelFront`;
- `SPR_Bike_Bike01_WheelRear`.

Detailed visual target:
- wheels must remain readable against ground color;
- wheel interior must not become a black hole that merges with the track;
- outer tire shape must stay crisp;
- avoid visually overcomplicated spokes unless they still read at speed.

Prompt-style execution note:
- pixel art motorcycle wheel for side-view racing game, clean readable circular silhouette, strong contrast against dirt track, low noise, supports fast motion and rotation readability.

### 2.3 Create rider base sprite
Create:
- `SPR_Rider_Bike01_Base`.

Detailed visual target:
- rider should read as part of the same vehicle silhouette, not as separate visual noise;
- helmet must read clearly;
- torso lean should support movement feeling;
- details must stay broad and functional.

Prompt-style execution note:
- pixel art motorcycle rider for side-view arcade racer, compact readable silhouette, helmet clearly visible, forward-leaning sporty posture, minimal noise, integrated with bike profile.

### 2.4 Optional readability helper
If needed for integration readability, create:
- `SPR_Bike_Bike01_Shadow`.

Use only if it truly improves readability in Unity.

## Minimum output of Phase 2
After Phase 2, Unity should be able to show a readable static `bike_01` object in scene.

## Definition of done for Phase 2
The artist and designer can look at the bike in scene and immediately say:
- this is the player object;
- it reads clearly at gameplay scale;
- it does not dissolve into the track.

---

# Phase 3 — `bike_01` minimum animation-ready state set

## Goal
Create only the minimum motion states needed for MVP readability and basic feel.

## Tasks
### 3.1 Prepare idle / pre-start state
Create or support:
- `AN_Bike_Bike01_Idle`.

Recommended baseline:
- `2` frames;
- very small motion;
- should communicate readiness, not exaggerated bouncing.

### 3.2 Prepare drive state
Create or support:
- `AN_Bike_Bike01_Drive`.

Recommended baseline:
- `4` key frames maximum for the first pass;
- animation must suggest motion and suspension response;
- avoid frame count growth before in-engine validation.

### 3.3 Prepare jump and landing states
Create or support:
- `AN_Bike_Bike01_Jump`;
- `AN_Bike_Bike01_Landing`.

Recommended baseline:
- jump: `2` key poses;
- landing: `2` frames;
- clarity more important than richness.

### 3.4 Prepare finish state
Create or support:
- `AN_Bike_Bike01_Finish`.

Recommended baseline:
- `2` frames;
- enough to communicate completion state without becoming a celebration system.

## Production note
At this stage, motion should support the programmer’s first gameplay build.
Do not invest in expensive animation polish before seeing the bike in actual gameplay rhythm.

## Minimum output of Phase 3
The bike has enough motion support to participate in a first playable race loop.

## Definition of done for Phase 3
The bike no longer looks like a static placeholder in the key race states: pre-start, drive, jump, landing, finish.

---

# Phase 4 — `map_01` core track tiles for gameplay readability

## Goal
Produce the minimum tile set required to assemble a readable playable `map_01`.

## Tasks
### 4.1 Ground and flat tiles
Create:
- `SPR_Map_Map01_Tile_Ground_A`;
- `SPR_Map_Map01_Tile_Ground_B`;
- `SPR_Map_Map01_Tile_Flat_A`.

Detailed visual target:
- active rideable surface must be visually stable;
- texture must stay simple enough to avoid shimmer or noise;
- color mass must clearly separate track from background.

Prompt-style execution note:
- 16x16 pixel art dirt racing track tile, readable active surface, low texture noise, strong gameplay clarity, arcade style, designed for fast horizontal movement.

### 4.2 Edge and form-definition tiles
Create:
- `SPR_Map_Map01_Tile_Edge_A`;
- `SPR_Map_Map01_Tile_Crest_A`.

Detailed visual target:
- edges must clarify where the track volume begins and ends;
- crest shapes must help the player read terrain silhouette quickly.

### 4.3 Slope and ramp tiles
Create:
- `SPR_Map_Map01_Tile_Slope_Up_Short`;
- `SPR_Map_Map01_Tile_Slope_Down_Short`;
- `SPR_Map_Map01_Tile_Ramp_Short`.

Detailed visual target:
- slope direction must be obvious even at speed;
- ramp shape must be readable before the player reaches it;
- do not hide useful geometry inside decorative texture.

Prompt-style execution note:
- pixel art side-view dirt racing slope tile, strong silhouette readability, low clutter, designed for fast player recognition in arcade motorcycle game.

### 4.4 Finish set
Create:
- `SPR_Map_Map01_FinishBanner`;
- `SPR_Map_Map01_FinishPost_Left`;
- `SPR_Map_Map01_FinishPost_Right`.

Detailed visual target:
- finish must be obvious and celebratory enough to read instantly;
- must not become visually heavier than the track itself;
- must survive browser-scale readability.

## Minimum output of Phase 4
After Phase 4, the programmer can assemble a first visually readable `map_01` instead of using fully raw placeholders.

## Definition of done for Phase 4
The track can be built from tiles that communicate flat ground, slope, ramp, crest and finish clearly.

---

# Phase 5 — `map_01` background and low-noise environmental support

## Goal
Provide only enough background to make the scene feel complete without harming gameplay readability.

## Tasks
### 5.1 Sky and horizon
Create:
- `SPR_Map_Map01_BG_Sky`;
- `SPR_Map_Map01_BG_Horizon`.

Detailed visual target:
- soft contrast;
- simple broad shapes;
- no busy banding or noisy clouds;
- track and bike must remain the highest-contrast gameplay layer.

Prompt-style execution note:
- side-view pixel art racing background sky and horizon, low contrast, broad shapes, minimal noise, supports bright readable foreground track and bike.

### 5.2 One background decor object
Create:
- `SPR_Map_Map01_BG_Decor_01`.

Detailed visual target:
- one simple repeating environmental accent;
- should add world feel without competing with the race layer;
- low-frequency placement only.

## Minimum output of Phase 5
The race scene looks intentional, but the background still stays subordinate to gameplay.

## Definition of done for Phase 5
A tester sees a full scene, but the eye still goes to the bike and track first.

---

# Phase 6 — minimum VFX for motion support

## Goal
Provide the smallest useful VFX set that improves feel without visual clutter.

## Tasks
### 6.1 Start and running dust
Create:
- `SPR_VFX_Dust_Start_01` / `AN_VFX_Dust_Start_01`;
- `SPR_VFX_Dust_Run_01` / `AN_VFX_Dust_Run_01`.

Detailed visual target:
- short-lived;
- readable as dust, not smoke wall;
- should support motion energy;
- must never hide the whole bike.

Prompt-style execution note:
- small pixel art dirt dust burst for side-view motorcycle racing game, short duration, readable shape, low clutter, supports acceleration and speed feel.

### 6.2 Landing impact
Create:
- `SPR_VFX_Land_Impact_01` / `AN_VFX_Land_Impact_01`.

Detailed visual target:
- quick contact accent;
- should reinforce weight and landing readability;
- should not become a giant splash.

### 6.3 Finish burst
Create:
- `SPR_VFX_Finish_Burst_01` / `AN_VFX_Finish_Burst_01`.

Detailed visual target:
- short finish accent;
- must feel like completion feedback;
- must not delay result readability.

## Minimum output of Phase 6
The playable loop has small readable feedback accents for start, movement, landing and finish.

## Definition of done for Phase 6
The scene feels more alive, but VFX still clearly stays secondary to bike and track readability.

---

# Phase 7 — race HUD support assets

## Goal
Create the minimum visual support for in-race UI.

## Tasks
### 7.1 Timer panel support
Create:
- `SPR_UI_RaceHud_TimerPanel`.

Detailed visual target:
- compact and clean;
- must support strong readability of timer text;
- should not feel like a heavy framed box.

Prompt-style execution note:
- minimal pixel UI timer panel for 2D arcade race HUD, clean silhouette, readable backing, low decoration, designed for top-of-screen placement.

### 7.2 Countdown set
Create:
- `SPR_UI_Countdown_03`;
- `SPR_UI_Countdown_02`;
- `SPR_UI_Countdown_01`;
- `SPR_UI_Countdown_Go`.

Detailed visual target:
- very large readable forms;
- high contrast;
- immediate scan recognition;
- no over-detailed stylization.

Prompt-style execution note:
- large pixel countdown numerals for arcade race start, bold and highly readable, strong contrast, minimal decoration, browser-friendly readability.

### 7.3 Optional countdown motion support
If cheap and safe, support:
- `AN_UI_Countdown_Pop`.

Only if it does not complicate the pipeline.

## Minimum output of Phase 7
The in-race UI can be shown with assets that look production-ready enough for MVP validation.

## Definition of done for Phase 7
Timer and countdown are readable instantly in browser-scale play.

---

# Phase 8 — result screen support assets

## Goal
Provide the visual assets required for a strong post-race result and restart loop.

## Tasks
### 8.1 Result panel background
Create:
- `SPR_UI_ResultPanel_Background`.

Detailed visual target:
- centered clean panel;
- readable over race background;
- modern arcade competition feel;
- minimal frame noise;
- supports hierarchy instead of replacing it.

Prompt-style execution note:
- clean pixel result panel for arcade racing game, centered overlay, low clutter, semi-transparent or light backing feel, supports large result numerals and one dominant restart button.

### 8.2 Button states
Create at minimum:
- `SPR_UI_Button_Primary`;
- `SPR_UI_Button_Secondary`;
- optionally `SPR_UI_Button_Pressed` if cheap enough.

Detailed visual target:
- primary button must feel fast and obvious;
- secondary button must stay visible but lower-emphasis;
- no bulky mobile-style decoration.

### 8.3 Result labels support
Create if needed as graphic supports, not baked full language solutions:
- `SPR_UI_ResultPanel_TimeLabel`;
- any small decorative support pieces only if text is not hard-baked unnecessarily.

Important rule:
Avoid baking large amounts of text into graphics unless there is a very strong reason.

### 8.4 Optional result show animation support
If cheap and useful, support:
- `AN_UI_ResultPanel_Show`.

Only if it remains short and does not slow restart.

## Minimum output of Phase 8
The result screen can look intentional and support the restart-first hierarchy.

## Definition of done for Phase 8
A tester clearly sees:
- current result as main item;
- restart as primary action;
- exit as secondary action.

---

# Phase 9 — main menu minimum shell support

## Goal
Provide only the minimum menu art required for clear entry into the race loop.

## Tasks
### 9.1 Buttons and core icons
Create:
- `SPR_UI_Panel_Base`;
- `SPR_UI_Icon_Race`;
- `SPR_UI_Icon_Leaderboard`;
- `SPR_UI_Icon_Settings`.

Detailed visual target:
- large readable forms;
- one-click clarity;
- supports quick browser navigation;
- no over-styled menu framing.

### 9.2 Only placeholder-grade optional shell icons
If needed and only if they do not block MVP, create:
- `SPR_UI_Icon_Garage`;
- `SPR_UI_Icon_DailyReward`.

These are strictly lower priority.

## Minimum output of Phase 9
The main menu can look coherent without eating resources needed for race readability.

## Definition of done for Phase 9
The menu visually supports the race-first product flow without becoming a separate art project.

---

# Immediate task order summary
For convenience, here is the strict first-order sequence:
1. confirm grid, palette and export baseline;
2. draw `bike_01` body silhouette;
3. draw front and rear wheels;
4. draw rider base;
5. prepare minimum bike state support for animation;
6. draw core `map_01` gameplay tiles;
7. draw finish set;
8. draw soft background and one decor object;
9. draw minimum VFX set;
10. draw timer panel and countdown set;
11. draw result panel background and core buttons;
12. draw menu support icons and base panel only after race assets are stable.

If priorities conflict, follow this list.

---

# What can stay placeholder-grade in this pack
The artist may keep these lightweight or deferred:
- rich button states;
- second background decor layer;
- heavy finish flourish;
- garage and daily shell art;
- extra bike color presentation assets beyond compatibility planning;
- expensive frame-by-frame polish beyond MVP readability needs.

These must not block first playable validation.

---

# What must not be postponed in this pack
Do not postpone:
- player-bike readability;
- track readability;
- countdown readability;
- result panel readability;
- naming correctness;
- browser-safe clarity.

These are foundational and expensive to fix late if ignored.

---

# Hand-off expectations to Unity
For every major asset group, provide exports that are easy to integrate.

Recommended hand-off package per group:
- final named PNG exports;
- source file with clean layer naming if relevant;
- anchor / pivot notes when needed;
- any palette-swap notes for future compatibility;
- short note if an asset must be layered in a specific order.

Examples:
- body layer below rider, wheels separated;
- VFX intended above ground but below UI;
- result panel backing intended for centered Canvas placement.

---

# Acceptance checklist for the artist
This pack is complete when all statements below are true:
1. `bike_01` reads instantly as the player-controlled object;
2. the core tile set for `map_01` supports a readable playable track;
3. background remains visually quieter than the gameplay layer;
4. VFX support motion without obscuring bike or track;
5. countdown is readable at a glance;
6. result panel support assets reinforce restart-first hierarchy;
7. menu art does not consume effort needed by the race loop;
8. exports use canonical names.

---

# Final instruction to the artist / pixel artist
The first objective is not to make the project look content-rich.
The first objective is to make the playable race loop look readable, intentional and worth replaying.

If an asset does not help the team validate:
- bike readability;
- track readability;
- countdown clarity;
- result and restart clarity;
then it is probably not the next asset to produce.
