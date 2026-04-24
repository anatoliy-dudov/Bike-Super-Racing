# Bike Super Racing — Stage 4 Drawing Task for Race UI Must-Have Assets

## 1. Назначение задачи
Документ фиксирует отдельное рабочее ТЗ на Stage 4 для current first playable Bike Super Racing.

Задача Stage 4:
- отрисовать минимальный обязательный UI-пакет для гонки и post-race loop;
- получить production-ready основу для countdown, timer, result and restart hierarchy;
- подготовить базу для интеграции в Unity и проверки browser-scale readability.

Stage 4 не покрывает:
- богатый shell UI;
- расширенный menu flow;
- декоративные transition-heavy экраны;
- post-MVP complexity.

## 2. Состав Stage 4
В Stage 4 входят только следующие ассеты:
- `SPR_UI_Button_Primary`;
- `SPR_UI_Button_Secondary`;
- `SPR_UI_RaceHud_TimerPanel`;
- `SPR_UI_Countdown_03`;
- `SPR_UI_Countdown_02`;
- `SPR_UI_Countdown_01`;
- `SPR_UI_Countdown_Go`;
- `SPR_UI_ResultPanel_Background`;
- `SPR_UI_Icon_Race`.

## 3. Главная задача Stage 4
Игрок должен за долю секунды понять:
- где текущее время;
- когда начинается попытка;
- какой результат получен;
- что restart — главное действие после финиша.

Если UI читается только в большом мокапе, но не в browser-scale — Stage 4 провален.

## 4. Художественный target
UI должен восприниматься как:
- чистый;
- быстрый;
- спортивный;
- аркадный;
- low-noise.

Он не должен восприниматься как:
- тяжёлый мобильный shell;
- декоративно перегруженный интерфейс;
- более важный, чем gameplay layer.

## 5. Иерархия
Обязательная visual hierarchy:
1. track + bike;
2. countdown / finish signal в ключевой момент;
3. timer;
4. current result on result panel;
5. restart CTA;
6. secondary exit/back CTA.

## 6. Button rules
### 6.1. Primary button
`SPR_UI_Button_Primary` должен:
- быть самым уверенным интерактивным элементом;
- быстро читаться;
- быть пригодным и для menu race entry, и для restart.

### 6.2. Secondary button
`SPR_UI_Button_Secondary` должен:
- быть явно слабее primary;
- быть читаемым;
- не спорить с restart.

## 7. Timer rules
`SPR_UI_RaceHud_TimerPanel` должен:
- быть компактным;
- иметь clean silhouette;
- поддерживать сильную читаемость цифр;
- не быть тяжёлой рамкой.

## 8. Countdown rules
`SPR_UI_Countdown_03` / `02` / `01` / `Go` должны:
- быть крупными;
- иметь очень высокий контраст;
- читаться мгновенно на фоне трассы;
- жить коротко и энергично.

## 9. Result panel rules
`SPR_UI_ResultPanel_Background` должен:
- быть clean centered panel;
- поддерживать hierarchy current time / best time / restart;
- не быть раздутым по площади;
- не превращаться в меню-хаб.

## 10. Icon rule
`SPR_UI_Icon_Race` должен:
- быть простым;
- считываться мгновенно;
- быть пригодным для minimal shell, а не для витринного меню.

## 11. Порядок исполнения
Строгий порядок:
1. `SPR_UI_Button_Primary`;
2. `SPR_UI_Button_Secondary`;
3. `SPR_UI_RaceHud_TimerPanel`;
4. `SPR_UI_Countdown_03`;
5. `SPR_UI_Countdown_02`;
6. `SPR_UI_Countdown_01`;
7. `SPR_UI_Countdown_Go`;
8. `SPR_UI_ResultPanel_Background`;
9. `SPR_UI_Icon_Race`;
10. собрать UI mockup над gameplay scene.

## 12. Промпт-ориентир для художника
Использовать следующие смысловые ориентиры:

Buttons:
- pixel art arcade racing UI button, clean shape, high readability, low decoration, sporty but simple, browser-safe, reusable primary action.

Timer panel:
- minimal pixel HUD timer panel for 2D motorcycle arcade racing game, compact top-center backing, readable, low-noise, competitive feel.

Countdown:
- large pixel countdown numerals for arcade race start, bold readable forms, strong contrast, minimal decoration, instant scan readability.

Result panel:
- clean pixel result panel for short competitive 2D racer, centered, large current result area, strong restart-first hierarchy, low clutter.

## 13. Hand-off в Unity
На выходе Stage 4 должны быть переданы:
- PNG-файлы с каноническими именами;
- source file с чистыми слоями, если применимо;
- note по intended placement и scale.

## 14. Definition of done
Stage 4 считается завершённым, если:
1. timer читается мгновенно;
2. countdown читается мгновенно;
3. result panel поддерживает restart-first hierarchy;
4. primary и secondary button различаются по весу;
5. UI не спорит с gameplay layer;
6. naming соответствует канону.

## 15. Что проверять сразу после отрисовки
После первой отрисовки необходимо проверить:
- читается ли timer на уменьшенном масштабе;
- теряются ли countdown элементы на фоне трассы;
- достаточно ли очевиден restart как главное действие;
- не перегружен ли result panel;
- не выглядит ли button system слишком тяжёлым.

## 16. Следующий шаг
После завершения Stage 4 необходимо:
- показать race UI mockup и result mockup;
- проверить browser-scale readability;
- затем переходить к VFX must-have set.
