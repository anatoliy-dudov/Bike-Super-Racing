# Bike Super Racing — First Art Batch Execution Pack

## 1. Назначение документа
Документ фиксирует первый реальный production batch на отрисовку для current first playable Bike Super Racing.

Цель документа:
- перевести арт-документацию в конкретный список работы;
- задать строгий порядок отрисовки;
- зафиксировать размеры, имена, hand-off и definition of done;
- не допустить расползания в shell-арт до проверки core loop.

Документ используется художником / pixel artist, Unity-интегратором, UI/UX и продюсером как практический рабочий пакет.

## 2. Main production rule
Первый батч существует не для того, чтобы “визуально наполнить игру”.
Он существует для того, чтобы команда как можно раньше получила один читаемый playable race loop.

Если ассет не помогает проверить:
- читаемость байка;
- читаемость трассы;
- читаемость countdown;
- читаемость result / restart;
то этот ассет не должен попадать в первый батч.

## 3. Состав первого батча
В первый батч входят только следующие группы:

### Group A — Player vehicle
- `SPR_Bike_Bike01_Body`;
- `SPR_Bike_Bike01_WheelFront`;
- `SPR_Bike_Bike01_WheelRear`;
- `SPR_Rider_Bike01_Base`;
- `SPR_Bike_Bike01_Shadow` — только если нужен для читаемости.

### Group B — Core track readability
- `SPR_Map_Map01_Tile_Flat_A`;
- `SPR_Map_Map01_Tile_Ground_A`;
- `SPR_Map_Map01_Tile_Ground_B`;
- `SPR_Map_Map01_Tile_Edge_A`;
- `SPR_Map_Map01_Tile_Crest_A`;
- `SPR_Map_Map01_Tile_Slope_Up_Short`;
- `SPR_Map_Map01_Tile_Slope_Down_Short`;
- `SPR_Map_Map01_Tile_Ramp_Short`;
- `SPR_Map_Map01_FinishBanner`;
- `SPR_Map_Map01_FinishPost_Left`;
- `SPR_Map_Map01_FinishPost_Right`.

### Group C — Low-noise scene support
- `SPR_Map_Map01_BG_Sky`;
- `SPR_Map_Map01_BG_Horizon`;
- `SPR_Map_Map01_BG_Decor_01`.

### Group D — Race UI must-have
- `SPR_UI_Button_Primary`;
- `SPR_UI_Button_Secondary`;
- `SPR_UI_RaceHud_TimerPanel`;
- `SPR_UI_Countdown_03`;
- `SPR_UI_Countdown_02`;
- `SPR_UI_Countdown_01`;
- `SPR_UI_Countdown_Go`;
- `SPR_UI_ResultPanel_Background`;
- `SPR_UI_Icon_Race`.

### Group E — Minimum VFX support
- `SPR_VFX_Dust_Start_01`;
- `SPR_VFX_Dust_Run_01`;
- `SPR_VFX_Land_Impact_01`;
- `SPR_VFX_Finish_Burst_01`.

## 4. Порядок отрисовки
Строгий порядок выполнения:

### Stage 1 — `bike_01`
Сначала рисуются:
1. `SPR_Bike_Bike01_Body`;
2. `SPR_Bike_Bike01_WheelFront`;
3. `SPR_Bike_Bike01_WheelRear`;
4. `SPR_Rider_Bike01_Base`;
5. `SPR_Bike_Bike01_Shadow` — только если нужен.

### Stage 2 — `map_01` core tiles
После этого рисуются:
1. `SPR_Map_Map01_Tile_Flat_A`;
2. `SPR_Map_Map01_Tile_Ground_A`;
3. `SPR_Map_Map01_Tile_Ground_B`;
4. `SPR_Map_Map01_Tile_Edge_A`;
5. `SPR_Map_Map01_Tile_Crest_A`;
6. `SPR_Map_Map01_Tile_Slope_Up_Short`;
7. `SPR_Map_Map01_Tile_Slope_Down_Short`;
8. `SPR_Map_Map01_Tile_Ramp_Short`.

### Stage 3 — finish and scene support
Затем рисуются:
1. `SPR_Map_Map01_FinishBanner`;
2. `SPR_Map_Map01_FinishPost_Left`;
3. `SPR_Map_Map01_FinishPost_Right`;
4. `SPR_Map_Map01_BG_Sky`;
5. `SPR_Map_Map01_BG_Horizon`;
6. `SPR_Map_Map01_BG_Decor_01`.

### Stage 4 — race UI
Затем рисуются:
1. `SPR_UI_Button_Primary`;
2. `SPR_UI_Button_Secondary`;
3. `SPR_UI_RaceHud_TimerPanel`;
4. `SPR_UI_Countdown_03` / `02` / `01` / `Go`;
5. `SPR_UI_ResultPanel_Background`;
6. `SPR_UI_Icon_Race`.

### Stage 5 — VFX
В конце первого батча рисуются:
1. `SPR_VFX_Dust_Start_01`;
2. `SPR_VFX_Dust_Run_01`;
3. `SPR_VFX_Land_Impact_01`;
4. `SPR_VFX_Finish_Burst_01`.

Если сроки конфликтуют, приоритет всегда выше у предыдущего stage.

## 5. Размеры и baseline
### 5.1. Global baseline
- base grid: `16x16 px`;
- UI alignment rhythm: кратно `8 px`, где это уместно;
- integer upscale only.

### 5.2. `bike_01`
- bike + rider canvas: `64x40 px`;
- допускается `64x48 px`, если без этого ломается прыжковая поза;
- wheel diameter: `12–16 px`.

### 5.3. Track tiles
- base tile: `16x16 px`;
- крупные элементы — только кратные `16 px`.

### 5.4. Background
- фоновые элементы могут быть крупнее, но должны собираться без шума и с учётом browser readability.

### 5.5. VFX
- small effects: `8x8`, `16x16` или `32x16 px`.

## 6. Требования к каждому stage

## 6.1. Stage 1 — `bike_01`
### Что игрок должен почувствовать
- это главный объект управления;
- он читается мгновенно;
- он выглядит быстрым и аркадным.

### Что обязательно сохранить
- два колеса;
- понятную массу корпуса;
- голову / шлем гонщика;
- посадку, поддерживающую движение вперёд.

### Что нельзя делать
- перегружать мотор и подвеску деталями;
- делать корпус слишком длинным или слишком тонким;
- допускать слияние байка с грунтом.

### Definition of done
Stage 1 завершён, если:
- байк читается на gameplay scale;
- гонщик читается как часть player vehicle;
- колёса не теряются на фоне трека;
- экспорт выполнен с каноническим naming.

## 6.2. Stage 2 — `map_01` core tiles
### Что игрок должен почувствовать
- трасса понятна с первого взгляда;
- рельеф читается честно;
- трамплин считывается до наезда на него.

### Что обязательно сохранить
- чёткую верхнюю линию поверхности;
- понятное различие flat / slope / crest / ramp;
- минимум внутреннего шумового паттерна.

### Что нельзя делать
- делать грунт слишком текстурным;
- ломать силуэт поверхности случайными пикселями;
- прятать полезную геометрию внутри декора.

### Definition of done
Stage 2 завершён, если:
- из набора можно собрать базовую playable `map_01`;
- flat, slope, crest и ramp читаются мгновенно;
- тайлы собираются без визуального хаоса.

## 6.3. Stage 3 — finish and background
### Что игрок должен почувствовать
- у трассы есть завершённая сцена;
- финиш виден и понятен;
- фон поддерживает мир, но не спорит с gameplay.

### Что обязательно сохранить
- финиш как ясную цель;
- фон как low-noise слой;
- низкую частоту декора.

### Что нельзя делать
- делать финиш крупнее визуального смысла;
- делать фон контрастнее, чем трасса и байк;
- ставить агрессивный декор рядом с активной поверхностью.

### Definition of done
Stage 3 завершён, если:
- финишная зона читается без объяснений;
- фон не спорит с gameplay layer;
- один декор-элемент не превращается в ложное препятствие.

## 6.4. Stage 4 — race UI
### Что игрок должен почувствовать
- countdown понятен и собирает внимание;
- timer читается без усилия;
- result screen сразу ведёт к restart.

### Что обязательно сохранить
- primary / secondary hierarchy у кнопок;
- высокий контраст countdown;
- простую и быструю форму result panel.

### Что нельзя делать
- делать countdown декоративным вместо читаемого;
- делать exit визуально равным restart;
- перегружать panel рамками и украшениями.

### Definition of done
Stage 4 завершён, если:
- timer читается в реальном browser scale;
- countdown читается моментально;
- restart visually dominates на result screen.

## 6.5. Stage 5 — VFX
### Что игрок должен почувствовать
- движение стало живее;
- старт, приземление и финиш получили ясный feedback.

### Что обязательно сохранить
- короткий life time эффекта;
- читаемую форму;
- вторичность по отношению к байку и трассе.

### Что нельзя делать
- перекрывать эффектами player object;
- делать из dust визуальную стену;
- превращать finish feedback в задержку цикла.

### Definition of done
Stage 5 завершён, если:
- эффекты усиливают motion feedback;
- эффекты не ломают readability;
- эффекты легко интегрируются как отдельные сущности.

## 7. Hand-off package for Unity
Для каждой asset group hand-off должен включать:
- финальные PNG с каноническими именами;
- source file с чистыми названиями слоёв, если применимо;
- краткую note по pivot / anchor, если это неочевидно;
- note по layer order, если это критично.

### Примеры hand-off notes
- body layer below rider;
- wheels exported separately with center pivots;
- VFX intended above ground but below UI;
- result panel intended for centered canvas placement.

## 8. Что можно оставить на потом
В первый батч не включаются и не должны тормозить работу:
- `bike_02`;
- дополнительные цвета как отдельные полные презентационные наборы;
- Garage UI;
- Daily Reward UI;
- map selection cards;
- Leaderboard full panel art beyond non-blocking basics;
- дополнительные фоновые декоры;
- богатые анимационные состояния.

## 9. Риски и ограничения
### Основные риски
- слишком ранний уход в shell-арт;
- перегруз тайлов деталями;
- попытка сразу отполировать всё вместо получения работающего readable loop;
- несоблюдение naming baseline;
- экспорт без единой логики pivot и layer order.

### Ограничение MVP
Первый батч должен быть достаточно хорошим для валидного тестирования, но не обязан быть post-MVP polished.

## 10. Критерии готовности всего первого батча
Первый батч считается завершённым, если:
1. `bike_01` читается мгновенно;
2. `map_01` собирается в playable readable track;
3. finish zone понятна;
4. background остаётся подчинённым gameplay;
5. timer и countdown читаются мгновенно;
6. result panel поддерживает restart-first hierarchy;
7. VFX добавляют feedback без визуального шума;
8. экспорт выполнен по naming baseline.

## 11. Следующий шаг после первого батча
После завершения первого батча необходимо:
- интегрировать все ассеты в Unity;
- проверить browser-scale readability;
- выявить реальные проблемы по bike / track / HUD / result;
- только после этого решать, какие ассеты требуют второго art batch.
