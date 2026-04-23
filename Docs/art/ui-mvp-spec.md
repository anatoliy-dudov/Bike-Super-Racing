# Bike Super Racing — UI MVP Specification

## 1. Назначение документа
Документ фиксирует художественные и production-требования к UI первого playable vertical slice Bike Super Racing.

Цель документа:
- определить узкий UI-скоуп для current first playable;
- зафиксировать визуальные правила для HUD, countdown, result loop и минимального shell;
- синхронизировать художника, UI/UX, Unity-интегратора и программиста;
- исключить расползание UI в сторону дорогой оболочки до доказательства core loop.

Документ применяется совместно с:
- `Docs/design/game-vision.md`;
- `Docs/design/race-flow-and-hud.md`;
- `Docs/design/result-screen-and-restart-loop.md`;
- `Docs/design/mvp-scope-and-feature-priority-matrix.md`;
- `Docs/art/art-direction-mvp.md`.

## 2. Product scope for current first playable
Для current first playable UI должен обслуживать только один подтверждённый loop:
- вход в игру;
- быстрый старт гонки;
- countdown;
- активная гонка;
- finish;
- result;
- quick restart.

Важное правило:
- `map_01` выбирается автоматически;
- `bike_01` выбирается автоматически;
- `color_red` применяется автоматически.

Следовательно, в current first playable не требуются как обязательные:
- manual map selection UI;
- manual bike selection UI;
- manual color selection UI;
- полноценный Garage UI;
- широкая shell-навигация.

Если какие-то shell-элементы показываются как заглушки, они не должны мешать быстрому входу в гонку.

## 3. Роль UI в продукте
UI должен поддерживать одну ключевую эмоцию:

**игрок быстро понимает, что делать, быстро начинает заезд, быстро понимает результат и быстро перезапускает попытку.**

UI не должен:
- спорить с трассой и байком;
- становиться отдельным визуальным аттракционом;
- требовать длинного чтения;
- задерживать переход к новой попытке.

## 4. Базовые UI-принципы
### 4.1. Readability first
Любой важный UI-элемент должен считываться за долю секунды.

### 4.2. Race-first hierarchy
Во время гонки главный приоритет такой:
1. трасса;
2. байк;
3. countdown / finish signal в ключевой момент;
4. timer;
5. вторичный UI.

### 4.3. Low-noise shape language
Используются:
- крупные простые формы;
- чистые силуэты;
- минимум декоративных рамок;
- понятная иерархия размеров.

### 4.4. Browser-safe clarity
UI должен оставаться читаемым в реальном браузерном размере, а не только в увеличенном макете.

### 4.5. Restart-first logic
Post-race UI всегда должен вести к повторной попытке быстрее, чем к возврату в меню.

## 5. Визуальный стиль UI
### 5.1. Общее ощущение
UI должен восприниматься как:
- быстрый;
- спортивный;
- чистый;
- аркадный;
- современный, но не перегруженный.

### 5.2. Что запрещено
Не допускаются:
- тяжёлые декоративные рамки;
- шумные подложки;
- избыточная пиксельная орнаментальность;
- мелкие иконки без необходимости;
- длинные надписи, зашитые в графику, если этого можно избежать.

## 6. Обязательные UI-блоки current first playable
Для current first playable обязательны только следующие UI-блоки:
- main menu race entry;
- timer panel;
- countdown widget;
- optional pause access as secondary control;
- finish signal;
- result panel;
- primary restart CTA;
- secondary back / exit CTA.

## 7. Main Menu — minimal shell
### 7.1. Роль
Main Menu нужен для одного главного действия: очевидно отправить игрока в гонку.

### 7.2. Обязательные элементы
Для first playable достаточно:
- `SPR_UI_Button_Primary` — основная кнопка старта гонки;
- `SPR_UI_Panel_Base` — если нужна базовая панель или подложка;
- `SPR_UI_Icon_Race` — если иконка реально улучшает считывание.

### 7.3. Визуальные требования
Главный вход в Race должен:
- быть самым заметным действием на экране;
- считываться мгновенно;
- не конкурировать с низкоприоритетными действиями.

### 7.4. Допустимые вторичные элементы
Если они уже нужны по сборке, допускаются более тихие элементы:
- `SPR_UI_Icon_Leaderboard`;
- `SPR_UI_Icon_Settings`.

Они должны быть визуально слабее, чем Race CTA.

### 7.5. Что не является приоритетом
Не является near-MVP приоритетом:
- визуально богатый Garage entry;
- визуально богатый Daily Reward entry;
- сложная карточная навигация по контенту.

## 8. Race HUD — timer panel
### 8.1. Роль
Timer panel — основной постоянный HUD-элемент активной гонки.

### 8.2. Размещение
Рекомендуемое размещение:
- top center.

### 8.3. Ассет
- `SPR_UI_RaceHud_TimerPanel`.

### 8.4. Визуальные требования
Timer panel должен:
- быть компактным;
- иметь чистую читаемую форму;
- помогать тексту читаться на светлом и тёмном фоне;
- не выглядеть тяжёлой коробкой.

### 8.5. Prompt-style описание
- minimal pixel HUD timer panel for 2D arcade motorcycle racing game, compact top-center readable backing, low decoration, sport-oriented clean silhouette, browser-safe readability.

## 9. Countdown Widget
### 9.1. Роль
Countdown открывает ритм заезда и должен мгновенно собирать внимание игрока.

### 9.2. Ассеты
- `SPR_UI_Countdown_03`;
- `SPR_UI_Countdown_02`;
- `SPR_UI_Countdown_01`;
- `SPR_UI_Countdown_Go`.

Опционально:
- `AN_UI_Countdown_Pop`.

### 9.3. Размещение
- screen center.

### 9.4. Визуальные требования
Countdown должен:
- быть крупным;
- иметь очень высокий контраст;
- считываться без усилия на фоне трассы;
- жить коротко и энергично;
- не превращаться в мини-сцену.

### 9.5. Prompt-style описание
- large pixel arcade race countdown, centered, bold readable numerals, strong contrast, short energetic presentation, minimal decoration, immediate start focus.

## 10. Pause access
### 10.1. Статус
Pause является `Should Have`, а не ядром product proof.

### 10.2. Если реализуется
Используется:
- `SPR_UI_RaceHud_PauseButton`.

### 10.3. Размещение
- top-left, если timer расположен по центру.

### 10.4. Визуальные требования
Pause button должен:
- быть легко узнаваемым;
- быть заметным, но вторичным;
- не спорить по весу с timer и countdown.

## 11. Finish signal
### 11.1. Роль
Finish signal должен быстро и однозначно подтвердить завершение попытки.

### 11.2. Визуальное поведение
Finish signal должен:
- появляться кратко;
- быть читаемым на фоне трассы;
- передавать лёгкий соревновательный акцент;
- не задерживать переход к result state.

### 11.3. Исполнение
Для MVP допускается текстовый или графически поддержанный сигнал без дорогой анимации.

## 12. Result Panel
### 12.1. Роль
Result Panel — ключевой UI-блок post-race loop.

Его задача:
- показать итог;
- показать лучший результат;
- сделать restart естественным следующим действием.

### 12.2. Ассеты
Обязательные:
- `SPR_UI_ResultPanel_Background`;
- `SPR_UI_ResultPanel_TimeLabel` — только если это реально нужно как отдельный графический support-элемент;
- `SPR_UI_Button_Primary`;
- `SPR_UI_Button_Secondary`.

Опционально:
- `SPR_UI_Button_Pressed`;
- `AN_UI_ResultPanel_Show`.

### 12.3. Размещение
- centered или slightly lower-than-center.

### 12.4. Информационная иерархия
На Result Panel визуальный приоритет должен быть таким:
1. current time;
2. best time;
3. new best accent;
4. restart CTA;
5. exit / back CTA.

### 12.5. Визуальные требования
Panel должен:
- иметь чистый силуэт;
- хорошо читаться на фоне сцены;
- не быть раздутым по площади;
- поддерживать hierarchy, а не забивать её декором.

### 12.6. Prompt-style описание
- clean pixel result overlay for short competitive motorcycle racing game, centered readable panel, large current time, smaller best time, primary restart button, secondary back button, low clutter, immediate replay emphasis.

## 13. Restart CTA
### 13.1. Роль
Restart — главное действие после финиша.

### 13.2. Ассет
- `SPR_UI_Button_Primary`.

### 13.3. Визуальные требования
Primary button должен:
- быть самым очевидным интерактивным элементом result screen;
- иметь более сильный акцент, чем secondary button;
- выглядеть быстрым и уверенным, а не тяжёлым.

### 13.4. Размер и считывание
Кнопка должна быть:
- достаточной по размеру для браузерной кликабельности;
- короткой по надписи;
- визуально собранной.

## 14. Exit / Back CTA
### 14.1. Роль
Позволяет выйти из result loop, не споря с restart.

### 14.2. Ассет
- `SPR_UI_Button_Secondary`.

### 14.3. Визуальные требования
Secondary button должен:
- быть читаемым;
- быть явно слабее по весу, чем restart;
- не перетягивать взгляд первым.

## 15. New Best accent
### 15.1. Роль
Показывает, что попытка была значимой.

### 15.2. Визуальные требования
New Best accent должен:
- быть заметным;
- быть компактным;
- не превращаться в долгую победную анимацию;
- не тормозить restart loop.

### 15.3. Допустимое исполнение
Допускается:
- компактный badge;
- короткая строка;
- маленький ribbon-like акцент.

Не допускается:
- огромный баннер;
- долгая celebratory sequence;
- экранный флэш, ухудшающий читаемость.

## 16. Button system
### 16.1. Базовый набор
Для current first playable достаточно:
- `SPR_UI_Button_Primary`;
- `SPR_UI_Button_Secondary`;
- optional `SPR_UI_Button_Pressed`.

### 16.2. Стиль
Button system должен быть:
- единым;
- простым;
- хорошо читаемым;
- пригодным для reuse в main menu и result screen.

### 16.3. Правило
Лучше один сильный reusable button kit, чем набор разных “почти одинаковых” кнопок.

## 17. Текст и локализация
### 17.1. Главное правило
Не следует жёстко вшивать большие массивы текста в графику.

### 17.2. Разрешённое исключение
Допустимы графические support-элементы, если они:
- реально улучшают читаемость;
- не создают отдельный дорогостоящий локализационный хвост.

### 17.3. Рекомендуемые короткие лейблы
Поддерживаются краткие варианты:
- `Race`;
- `Result`;
- `Best` / `Best Time`;
- `Restart`;
- `Back` / `Back to Menu`;
- `New Best`.

## 18. Motion rules
### 18.1. Разрешено
Для MVP допускаются:
- короткий fade-in HUD;
- быстрый pulse / pop для countdown;
- короткое reveal result panel;
- быстрые press-state отклики.

### 18.2. Запрещено
Для MVP запрещены:
- длинные переходы;
- тяжёлая button choreography;
- многоступенчатая анимация меню;
- motion ради красоты без пользы для state readability.

## 19. Browser readability checks
UI должен проверяться не только в крупном мокапе, но и в реальном браузерном масштабе.

Обязательные проверки:
- Race CTA читается сразу;
- timer читается в гонке;
- countdown не теряется на фоне трассы;
- result panel остаётся читаемой;
- restart button остаётся очевидным.

## 20. Naming for UI assets
Используются следующие канонические имена:
- `SPR_UI_Button_Primary`;
- `SPR_UI_Button_Secondary`;
- `SPR_UI_Button_Pressed`;
- `SPR_UI_Panel_Base`;
- `SPR_UI_Icon_Race`;
- `SPR_UI_Icon_Leaderboard`;
- `SPR_UI_Icon_Settings`;
- `SPR_UI_RaceHud_TimerPanel`;
- `SPR_UI_RaceHud_PauseButton`;
- `SPR_UI_Countdown_03`;
- `SPR_UI_Countdown_02`;
- `SPR_UI_Countdown_01`;
- `SPR_UI_Countdown_Go`;
- `SPR_UI_ResultPanel_Background`;
- `SPR_UI_ResultPanel_TimeLabel`.

Не допускаются:
- `button_new_last`;
- `hud_fix_final2`;
- `countdown_best_new`;
- `result_good_panel`.

## 21. Что входит в current first playable
В current first playable по UI входит:
- один явный race entry;
- один timer panel;
- один countdown set;
- optional simple pause button;
- один result panel;
- один primary restart CTA;
- один secondary exit/back CTA;
- один небольшой `New Best` accent.

## 22. Что не должно блокировать current first playable
Не должно блокировать milestone:
- rich menu polish;
- Garage shell;
- Daily Reward shell;
- map selection cards;
- bike selection cards;
- color swatch presentation;
- decorative menu transitions.

## 23. Критерии приёмки
UI current first playable считается достаточным, если:
- Race CTA очевиден;
- timer читается мгновенно;
- countdown читается мгновенно;
- result screen ясно показывает current time и best time;
- restart выглядит главным действием;
- exit не спорит с restart;
- UI не перекрывает critical track space;
- browser-scale readability сохранена;
- naming соответствует канону.

## 24. Следующий production шаг
После утверждения документа команда может переходить к практической отрисовке первого UI-пакета:
- `SPR_UI_Button_Primary`;
- `SPR_UI_Button_Secondary`;
- `SPR_UI_RaceHud_TimerPanel`;
- `SPR_UI_Countdown_03` / `02` / `01` / `Go`;
- `SPR_UI_ResultPanel_Background`;
- `SPR_UI_Icon_Race`;
- optional `SPR_UI_Icon_Leaderboard` и `SPR_UI_Icon_Settings`.
