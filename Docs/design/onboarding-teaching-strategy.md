# Bike Super Racing — Onboarding & Teaching Strategy

## Purpose
This document fixes how the MVP teaches the player, what the first track must communicate and how difficulty should grow inside `map_01`.

## Teaching philosophy
The game should teach primarily through:
- flow;
- track geometry;
- bike response;
- result feedback;
- retry.

The game should teach only minimally through text.

## Onboarding goal
The onboarding layer must help the player understand:
1. how to start racing quickly;
2. that the goal is to finish as fast and cleanly as possible;
3. that the bike is predictable enough to learn;
4. that mistakes cost time;
5. that a second attempt can be better.

## What must be learned in MVP
### Must be learned immediately
- basic control of the bike;
- meaning of start and finish;
- role of the timer;
- value of clean execution;
- existence of retry as a natural continuation.

### Can be deferred
- deep bike differentiation;
- meta progression;
- advanced shell systems;
- large content structure.

## Teaching layers
### Layer 1. Flow teaching
The game teaches by making the path to the race obvious and short.

### Layer 2. Track teaching
The first track teaches by using readable sections that introduce challenge in sequence.

### Layer 3. Feedback teaching
The game teaches by showing the consequence of a mistake through time loss, rhythm break and visible result.

### Layer 4. Retry teaching
The second attempt is part of onboarding.
The player should naturally want to correct the most obvious earlier mistake.

## Text usage rule
Text should be used only if it:
- is very short;
- reduces confusion quickly;
- does not interrupt the pace;
- cannot be replaced by clearer visual or gameplay teaching.

If the design requires long explanation, the underlying UX or gameplay readability should be reconsidered.

## First track design purpose
`map_01` must be both:
- a real race track;
- the main teaching device for MVP.

It must not feel like a separate tutorial level.

## Difficulty curve for `map_01`
### Segment A — control introduction (0–15%)
Goal:
- let the player feel movement and response;
- avoid harsh punishment too early.

Expected player thought:
- the bike moves the way I expect.

### Segment B — first readable challenge (15–35%)
Goal:
- show that the track needs attention;
- create the first meaningful rhythm choice.

Expected player thought:
- I cannot just hold forward mindlessly.

### Segment C — first understandable mistake (35–50%)
Goal:
- create one moment where the player likely loses time in a way that can be understood.

Expected player thought:
- I know where I lost momentum.

### Segment D — combination of known demands (50–70%)
Goal:
- ask the player to apply already introduced lessons in a denser sequence.

Expected player thought:
- now I am racing the whole track, not only reacting to one obstacle.

### Segment E — pressure peak (70–90%)
Goal:
- make the end of the track feel skill-based and meaningful without introducing a new unreadable rule.

Expected player thought:
- to get a good time, I need a cleaner run here.

### Segment F — finish reinforcement (90–100%)
Goal:
- end the attempt clearly and preserve the player's motivation to improve.

Expected player thought:
- I finished and I already know where I can save time next run.

## Difficulty rules
1. The first harsh punishment must not happen before the player gets minimal control confidence.
2. One new challenge at a time is better than many mixed unreadable demands.
3. Punishment should mainly be time loss and rhythm loss, not session destruction.
4. Later sections should combine already known demands instead of adding random new logic.
5. The finish should reinforce mastery desire, not kill the run unfairly.

## Good first-track outcome
The player:
- makes one or more understandable mistakes;
- still reaches the finish;
- sees a meaningful result;
- wants to retry immediately.

## Bad first-track outcome
The player:
- gets punished before understanding the bike;
- cannot explain where the error happened;
- finishes without caring about the time;
- sees no reason to retry.

## Test questions for `map_01`
When playtesting, validate:
1. at what point the player first loses time;
2. whether the player can explain why;
3. whether the player reaches the finish on attempt one;
4. whether the player wants attempt two;
5. whether the player can name at least one section to improve.

## Deliverable intent for level design and programming
The first track should be implemented as a teaching race, not as a flat easy level.

The bike controller must support fast understanding of cause and effect.

If the player cannot feel why a section went wrong, the issue is likely in one of these areas:
- control clarity;
- geometry readability;
- feedback timing;
- punishment severity.
