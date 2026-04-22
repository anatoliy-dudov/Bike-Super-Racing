# Bike Super Racing — Asset List MVP

## 1. Назначение документа
Документ фиксирует минимальный список арт-ассетов для первого вертикального среза Bike Super Racing и задаёт порядок их производства.

Цель документа:
- определить, что именно требуется для MVP;
- исключить лишнее производство;
- синхронизировать художника, аниматора и Unity-интегратора;
- зафиксировать naming для ассетов.

## 2. Принцип приоритета
Порядок приоритета:
1. Игровая читаемость в гонке.
2. Состояния race flow.
3. UI, необходимый для завершённого цикла.
4. Лёгкий polish без раздувания production cost.

Категории:
- **Must Have** — без этого MVP не работает;
- **Should Have** — желательно для качества, но не блокирует первую играбельную версию;
- **Later** — post-MVP.

## 3. Must Have — игровые ассеты
### 3.1. Байк и гонщик
#### Обязательно
- `SPR_Bike_Bike01_Body`;
- `SPR_Bike_Bike01_WheelFront`;
- `SPR_Bike_Bike01_WheelRear`;
- `SPR_Rider_Bike01_Base`;
- `SPR_Bike_Bike01_Shadow` — при необходимости для лучшей читаемости;
- `AN_Bike_Bike01_Idle`;
- `AN_Bike_Bike01_Drive`;
- `AN_Bike_Bike01_Jump`;
- `AN_Bike_Bike01_Landing`;
- `AN_Bike_Bike01_Finish`.

#### Требования
- главный силуэт должен хорошо читаться на фоне трассы;
- колёса не должны визуально сливаться с грунтом;
- гонщик должен восприниматься как часть одного читаемого объекта, а не как шумная надстройка.

### 3.2. Трасса `map_01`
#### Обязательно
- `SPR_Map_Map01_Tile_Ground_A`;
- `SPR_Map_Map01_Tile_Ground_B`;
- `SPR_Map_Map01_Tile_Edge_A`;
- `SPR_Map_Map01_Tile_Slope_Up_Short`;
- `SPR_Map_Map01_Tile_Slope_Down_Short`;
- `SPR_Map_Map01_Tile_Ramp_Short`;
- `SPR_Map_Map01_Tile_Crest_A`;
- `SPR_Map_Map01_Tile_Flat_A`;
- `SPR_Map_Map01_FinishBanner`;
- `SPR_Map_Map01_FinishPost_Left`;
- `SPR_Map_Map01_FinishPost_Right`.

#### Требования
- рельеф должен считываться в движении без дополнительных подсказок;
- активная поверхность трассы должна быть визуально стабильной;
- не допускается перегруз мелкими текстурами.

### 3.3. Фон `map_01`
#### Обязательно
- `SPR_Map_Map01_BG_Sky`;
- `SPR_Map_Map01_BG_Horizon`;
- `SPR_Map_Map01_BG_Decor_01` — один простой повторяемый декоративный объект.

#### Требования
- фон должен быть тише по контрасту, чем трасса и байк;
- фон не должен спорить с игровым слоем.

## 4. Must Have — VFX
### 4.1. Игровые эффекты
#### Обязательно
- `SPR_VFX_Dust_Start_01`;
- `SPR_VFX_Dust_Run_01`;
- `SPR_VFX_Land_Impact_01`;
- `SPR_VFX_Finish_Burst_01`.

#### Анимации
- `AN_VFX_Dust_Start_01`;
- `AN_VFX_Dust_Run_01`;
- `AN_VFX_Land_Impact_01`;
- `AN_VFX_Finish_Burst_01`.

#### Требования
- эффект должен длиться коротко;
- эффект не должен перекрывать байк полностью;
- эффект не должен превращаться в визуальную кашу на фоне трассы.

## 5. Must Have — UI ассеты
### 5.1. Главное меню и навигация
#### Обязательно
- `SPR_UI_Button_Primary`;
- `SPR_UI_Button_Secondary`;
- `SPR_UI_Panel_Base`;
- `SPR_UI_Icon_Race`;
- `SPR_UI_Icon_Leaderboard`;
- `SPR_UI_Icon_Settings`.

### 5.2. HUD гонки
#### Обязательно
- `SPR_UI_RaceHud_TimerPanel`;
- `SPR_UI_Countdown_03`;
- `SPR_UI_Countdown_02`;
- `SPR_UI_Countdown_01`;
- `SPR_UI_Countdown_Go`.

### 5.3. Result и leaderboard
#### Обязательно
- `SPR_UI_ResultPanel_Background`;
- `SPR_UI_ResultPanel_TimeLabel`;
- `SPR_UI_ResultPanel_RestartButton`;
- `SPR_UI_ResultPanel_MenuButton`;
- `SPR_UI_LeaderboardPanel_Background`.

#### Требования к UI
- крупные и контрастные формы;
- минимум мелких декоративных элементов;
- текст по возможности не запекать в графику;
- все панели должны быть читаемы на браузерном размере.

## 6. Should Have
### 6.1. Дополнительный polish
- `SPR_Bike_Bike01_Highlight` — если нужен дополнительный акцент формы;
- `SPR_Map_Map01_Tile_Ground_C` — для лёгкой вариативности поверхности;
- `SPR_Map_Map01_BG_Decor_02`;
- `SPR_UI_Button_Pressed`;
- `AN_UI_ResultPanel_Show`;
- `AN_UI_Countdown_Pop`.

### 6.2. Поддерживающий shell и необязательные элементы current milestone
- `SPR_UI_Icon_Garage` — только как non-blocking placeholder;
- `SPR_UI_Icon_DailyReward` — только как non-blocking placeholder;
- `SPR_UI_RaceHud_PauseButton` — только если pause подтверждена в текущем production scope.

### 6.3. Подготовка под palette swap
- слой или группа цветов корпуса байка, пригодная для замены под:
  - `color_red`;
  - `color_yellow`;
  - `color_black`;
  - `color_purple`;
  - `color_pink`.

## 7. Later / post-MVP
Не входит в ближайший production priority:
- отдельный визуально уникальный `bike_02`;
- расширенный набор трекового декора;
- сложные погодные VFX;
- глубокий анимированный фон;
- дорогие переходы меню;
- дополнительные позы гонщика ради косметики;
- расширенный набор победных / проигрышных анимаций;
- `SPR_UI_BikeCard_Base`;
- `SPR_UI_MapCard_Map01`;
- `SPR_UI_ColorSwatch_Red`;
- `SPR_UI_ColorSwatch_Yellow`;
- `SPR_UI_ColorSwatch_Black`;
- `SPR_UI_ColorSwatch_Purple`;
- `SPR_UI_ColorSwatch_Pink`.

## 8. Порядок производства
### Этап 1. Базовая игровая читаемость
Сначала необходимо сделать:
- `bike_01`;
- базовые колёса;
- базовый гонщик;
- минимальный набор тайлов трассы;
- базовый фон;
- таймер и countdown.

### Этап 2. Основные состояния гонки
После этого необходимо сделать:
- jump / landing;
- finish-элементы;
- пыль и impact VFX;
- result panel;
- leaderboard panel.

### Этап 3. Базовый menu shell
Далее необходимо сделать:
- menu buttons;
- settings icon;
- leaderboard icon;
- при необходимости дешёвые placeholder-иконки Garage и Daily Rewards без усложнения flow.

### Этап 4. Лёгкий polish
Только после проверки читабельности и темпа игры допустимо добавить:
- pressed-state кнопок;
- второй фоновый decor;
- мягкое появление result panel;
- небольшой дополнительный вариативный тайл трассы;
- pause button, если он остаётся в рабочем scope.

## 9. Критерии готовности MVP-арта
MVP-арт считается достаточным для первой играбельной версии, если:
- один полный заезд выглядит целостно;
- байк не теряется на фоне трассы;
- игрок легко читает рельеф;
- countdown, timer и result понятны без дополнительных объяснений;
- VFX не шумит;
- все ассеты названы по канону.

## 10. Замечания по интеграции
- текущий first playable flow использует автоподбор `map_01`, `bike_01` и `color_red`;
- ассеты для ручного выбора карты, байка и цвета не являются блокером текущего milestone;
- любые новые сущности сначала фиксируются в naming-документации, затем создаются в контенте;
- альтернативные имена одной и той же сущности запрещены;
- при конфликте между красотой и читаемостью выбирается читаемость;
- при конфликте между богатством анимации и стабильностью pixel art выбирается стабильность.
