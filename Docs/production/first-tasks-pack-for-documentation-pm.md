# Bike Super Racing — First Tasks Pack for Documentation / PM

## Purpose
This document provides the first concrete production pack for the Documentation / PM role working on the MVP / vertical slice.

It is not a generic project-management checklist.
It is the ordered starting sequence for coordination, documentation control, blocker visibility and scope protection during MVP production.

The document answers:
- what the Documentation / PM role must do first;
- which baseline documents must stay synchronized;
- how to keep critical path visible;
- how to detect and stop scope drift early;
- what counts as done for the first management pass of the MVP milestone.

## Scope of this pack
This pack covers the first production-critical management and documentation slice only:
- documentation index and baseline control;
- naming consistency control;
- milestone tracking;
- blocker tracking;
- scope classification;
- cross-role decision capture;
- MVP status visibility.

This pack does not attempt to complete:
- long-term roadmap planning beyond MVP;
- full release operations process;
- post-MVP milestone planning in depth;
- heavy reporting overhead that slows the team.

## Working rule
At every step, prefer:
- one clear up-to-date source of truth;
over
- multiple half-updated documents and informal assumptions.

## Hard references
Documentation / PM work must follow and protect:
- `Docs/architecture/naming-convention.md`;
- `Docs/architecture/project-structure.md`;
- `Docs/architecture/architecture-baseline.md`;
- `Docs/design/game-vision.md`;
- `Docs/design/mvp-scope-and-feature-priority-matrix.md`;
- `Docs/production/task-breakdown-for-mvp-milestone.md`;
- `Docs/production/first-tasks-pack-for-unity-programmer.md`;
- `Docs/production/first-tasks-pack-for-artist-pixel-artist.md`;
- `Docs/production/first-tasks-pack-for-ui-ux.md`;
- `Docs/production/qa-smoke-pack-for-mvp.md`.

## Global outcome target
At the end of this pack, the Documentation / PM role should have created a project state where:
- the repo docs are the trusted baseline;
- the MVP boundary is visible and enforced;
- blockers have owners;
- critical path status is visible;
- new decisions are captured before they fragment across chats.

---

# Phase 1 — Source-of-truth lock

## Goal
Ensure the repository documentation is the current source of truth for the team.

## Tasks
### 1.1 Confirm README documentation index
Required result:
- `README.md` links to all current baseline documents under Art, Architecture, Design and Production.

### 1.2 Confirm required baseline groups exist
Required groups:
- Art;
- Architecture;
- Design;
- Production.

### 1.3 Confirm naming baseline ownership
Required result:
- all newly added docs or tasks use canonical names such as `map_01`, `bike_01`, `leaderboard_map_01`, `00_Bootstrap`, `01_MainMenu`, `02_Race`.

### 1.4 Freeze document authority rule
Required rule:
- if a decision changes naming, scope, flow or milestone expectations, the repo docs must be updated before the team treats the new assumption as official.

## Minimum output of Phase 1
The team has one visible documentation baseline and one visible place to verify current project truth.

## Definition of done for Phase 1
A team member can open the repo and understand where the current official project baseline lives without relying on scattered chat memory.

---

# Phase 2 — MVP scope control baseline

## Goal
Make sure every meaningful task is classified against the MVP boundary.

## Tasks
### 2.1 Enforce feature classification
Every new task or proposal should be classified as one of:
- Must have;
- Should have;
- Could have;
- Out of scope.

Reference baseline:
- `Docs/design/mvp-scope-and-feature-priority-matrix.md`.

### 2.2 Create simple scope review habit
For every new proposal, confirm:
1. does it strengthen the playable race loop;
2. does it strengthen first-minute experience;
3. does it strengthen result/restart behavior;
4. is it cheap enough for MVP;
5. does it risk widening the milestone.

### 2.3 Protect the vertical slice
Required enforcement rule:
- if a proposal widens content or shell scope without helping the current loop, it must be explicitly marked post-MVP or out of scope.

## Minimum output of Phase 2
Scope discussions stop being subjective and start referencing the same visible matrix.

## Definition of done for Phase 2
The team can clearly answer what is inside MVP and what is not, without role-by-role reinterpretation.

---

# Phase 3 — Critical path and blocker board

## Goal
Make milestone progress visible through a small number of truly critical items.

## Tasks
### 3.1 Track critical path items
At minimum track these as first-class items:
- playable `02_Race` scene;
- controllable `bike_01`;
- playable `map_01`;
- countdown / timer / finish;
- result screen;
- safe restart loop;
- best local time save;
- leaderboard non-blocking hook or stub;
- QA smoke pass on the full loop.

### 3.2 Track blockers explicitly
Every blocker must have:
- blocker description;
- owner;
- blocked role / task;
- expected unblock action.

### 3.3 Separate blocked work from optional work
Do not mix:
- critical blockers;
with
- nice-to-have pending polish.

## Minimum output of Phase 3
The team can distinguish between “we are blocked” and “we still have polish ideas”.

## Definition of done for Phase 3
At any moment, the team can answer:
- what is on the critical path;
- what is blocked;
- who owns each blocker.

---

# Phase 4 — Cross-role sync and decision capture

## Goal
Prevent repeated ambiguity between programmer, art, UI/UX, QA and design.

## Tasks
### 4.1 Capture cross-role decisions
Capture decisions that affect multiple roles, especially around:
- naming;
- scene flow;
- result and restart logic;
- asset priority;
- UI hierarchy;
- test expectations.

### 4.2 Update repo docs when decisions become official
If a decision changes baseline behavior, update the relevant repo file instead of leaving the decision trapped inside chat.

### 4.3 Keep role packs aligned
Verify that these documents still point toward the same MVP:
- programmer pack;
- artist pack;
- UI/UX pack;
- QA pack.

If one pack begins assuming broader scope than the others, correct it.

## Minimum output of Phase 4
The project no longer depends on memory-based coordination for important production decisions.

## Definition of done for Phase 4
New cross-role assumptions are traceable in repo docs rather than buried in chat history.

---

# Phase 5 — Milestone status reporting baseline

## Goal
Create a lightweight reporting rhythm that helps, not slows, the MVP.

## Tasks
### 5.1 Use one short milestone status template
Recommended structure:
- current milestone goal;
- completed critical-path items;
- current blockers;
- next 3 most important actions;
- scope warnings;
- risk warnings.

### 5.2 Report by loop relevance, not by raw task count
Prefer reporting:
- “countdown, timer and finish now work together”;
over
- “6 tasks closed”.

### 5.3 Keep updates production-meaningful
Good status updates answer:
- can we validate more of the real race loop now;
- what still prevents a full playable MVP candidate.

## Minimum output of Phase 5
The team can see milestone progress in product terms, not just backlog terms.

## Definition of done for Phase 5
A project status update helps someone understand playable progress immediately.

---

# Phase 6 — Repo hygiene and change control

## Goal
Prevent silent documentation drift as the repo grows.

## Tasks
### 6.1 Keep README updated
Every new baseline document that changes project coordination should be added to `README.md`.

### 6.2 Keep naming changes controlled
No renamed entity should appear in docs, code or art without corresponding update to `naming-convention.md`.

### 6.3 Keep production docs discoverable
If a new role pack or milestone doc is added, place it under `Docs/production` and link it from `README.md`.

### 6.4 Prefer update over duplication
If a document supersedes older assumptions, update the current file or clearly mark the newer file as authoritative instead of creating near-duplicate files with overlapping truth.

## Minimum output of Phase 6
The repo remains navigable as a working production tool, not just a document dump.

## Definition of done for Phase 6
A new contributor can locate the current baseline quickly and does not need to guess which document is current.

---

# Immediate task order summary
For convenience, here is the strict first-order sequence:
1. confirm repo documentation index;
2. confirm naming baseline enforcement;
3. enforce MVP classification on new tasks;
4. track critical path and blockers explicitly;
5. capture cross-role decisions into repo docs;
6. introduce lightweight milestone status rhythm;
7. keep README and repo structure current.

If priorities conflict, follow this list.

---

# What can stay lightweight in this pack
The Documentation / PM role may keep these lightweight for MVP:
- formal meeting-heavy rituals;
- broad release planning beyond MVP;
- deep analytics dashboards;
- rich reporting templates;
- post-MVP roadmap documentation.

These must not compete with protecting the real playable milestone.

---

# What must not be postponed in this pack
Do not postpone:
- naming enforcement;
- MVP scope labeling;
- blocker ownership;
- critical path visibility;
- repo source-of-truth hygiene;
- cross-role decision capture.

These are foundational and expensive to fix late if ignored.

---

# Hand-off expectations to the Documentation / PM role
## Needed from programmer
- notice of state-flow, save, restart or architecture changes;
- visibility on blockers and current implementation state.

## Needed from design
- notice of scope decisions and baseline changes;
- clear must/should/could classification when ambiguity appears.

## Needed from art and UI/UX
- notice when production needs shift asset priority or integration assumptions.

## Needed from QA
- early signal when the build is no longer valid for MVP loop verification.

---

# Acceptance checklist for Documentation / PM
This pack is complete when all statements below are true:
1. the repo is the obvious source of truth for the project baseline;
2. the MVP boundary is visible and referenced in discussions;
3. blockers have owners;
4. the critical path is visible;
5. cross-role decisions are captured rather than left in chat only;
6. new documents are discoverable from `README.md`;
7. scope drift is surfaced early rather than after work is already done.

---

# Final instruction to the Documentation / PM role
The first objective is not to create management overhead.
The first objective is to keep the team aligned on one small, real, playable MVP.

If a coordination activity does not help the team protect:
- the playable race loop;
- the critical path;
- the MVP boundary;
then it is probably not the next management task.
