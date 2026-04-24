# Bike Super Racing — Final Art Handoff Manifest

## 1. Назначение документа
Документ фиксирует финальный handoff-пакет ассетов в зоне ответственности арт-направления для current first playable.

Цель документа:
- зафиксировать канонические имена финальных файлов;
- убрать неоднозначность между вариантами `_draft`, `_second_pass`, `_polish`, `_polish_pass`;
- дать программистам и интеграторам единый список ассетов для внедрения.

## 2. Правило использования
Для интеграции необходимо использовать только канонические имена ниже.

Промежуточные варианты файлов с суффиксами:
- `_draft`;
- `_second_pass`;
- `_polish`;
- `_polish_pass`;
не считаются рабочими именами для production-integration.

## 3. Final handoff list
### 3.1. Bike 01
- `SPR_Bike_Bike01_Body.png`;
- `SPR_Bike_Bike01_WheelFront.png`;
- `SPR_Bike_Bike01_WheelRear.png`;
- `SPR_Rider_Bike01_Base.png`;
- `SPR_Bike_Bike01_Shadow.png`.

### 3.2. Map 01 core tiles
- `SPR_Map_Map01_Tile_Flat_A.png`;
- `SPR_Map_Map01_Tile_Ground_A.png`;
- `SPR_Map_Map01_Tile_Ground_B.png`;
- `SPR_Map_Map01_Tile_Edge_A.png`;
- `SPR_Map_Map01_Tile_Crest_A.png`;
- `SPR_Map_Map01_Tile_Slope_Up_Short.png`;
- `SPR_Map_Map01_Tile_Slope_Down_Short.png`;
- `SPR_Map_Map01_Tile_Ramp_Short.png`.

### 3.3. Map 01 finish and background
- `SPR_Map_Map01_FinishBanner.png`;
- `SPR_Map_Map01_FinishPost_Left.png`;
- `SPR_Map_Map01_FinishPost_Right.png`;
- `SPR_Map_Map01_BG_Sky.png`;
- `SPR_Map_Map01_BG_Horizon.png`;
- `SPR_Map_Map01_BG_Decor_01.png`.

### 3.4. Race UI must-have
- `SPR_UI_Button_Primary.png`;
- `SPR_UI_Button_Secondary.png`;
- `SPR_UI_RaceHud_TimerPanel.png`;
- `SPR_UI_Countdown_03.png`;
- `SPR_UI_Countdown_02.png`;
- `SPR_UI_Countdown_01.png`;
- `SPR_UI_Countdown_Go.png`;
- `SPR_UI_ResultPanel_Background.png`;
- `SPR_UI_Icon_Race.png`.

### 3.5. VFX must-have
- `SPR_VFX_Dust_Start_01.png`;
- `SPR_VFX_Dust_Run_01.png`;
- `SPR_VFX_Land_Impact_01.png`;
- `SPR_VFX_Finish_Burst_01.png`.

## 4. Integration note
Для current first playable данный список считается достаточным финальным baseline в зоне ответственности art direction.

Если после интеграции в Unity потребуются корректировки, изменения должны вноситься поверх этих канонических имён, а не путём создания новых альтернативных имён.

## 5. Scope note
Данный handoff покрывает:
- player bike;
- first track baseline;
- finish and low-noise background support;
- race UI must-have;
- VFX must-have.

Данный handoff не покрывает:
- расширенный shell UI;
- garage presentation;
- map selection shell;
- additional bikes;
- post-MVP content growth.
