# Bike Super Racing — Stage 5 Drawing Task for VFX Must-Have Set

## 1. Назначение задачи
Документ фиксирует отдельное рабочее ТЗ на Stage 5 для current first playable Bike Super Racing.

Задача Stage 5:
- отрисовать минимальный обязательный VFX-набор для core race loop;
- усилить ощущение старта, движения, приземления и финиша;
- подготовить production-ready визуальную основу для интеграции в Unity и проверки gameplay readability.

Stage 5 не покрывает:
- богатые атмосферные эффекты;
- погодные эффекты;
- сложные layered particles ради полировки;
- пост-MVP spectacle VFX.

## 2. Состав Stage 5
В Stage 5 входят только следующие ассеты:
- `SPR_VFX_Dust_Start_01`;
- `SPR_VFX_Dust_Run_01`;
- `SPR_VFX_Land_Impact_01`;
- `SPR_VFX_Finish_Burst_01`.

## 3. Главная задача Stage 5
Игрок должен за долю секунды чувствовать:
- стартовый импульс;
- постоянное движение по трассе;
- контакт с поверхностью при приземлении;
- ясный finish feedback.

Если VFX заметен, но ухудшает читаемость bike или track — Stage 5 провален.

## 4. Художественный target
VFX должен восприниматься как:
- короткий;
- читаемый;
- аркадный;
- лёгкий по массе;
- функциональный.

Он не должен восприниматься как:
- дымовая стена;
- шумная декорация;
- отдельное шоу поверх gameplay.

## 5. Правила читаемости
### 5.1. Что должно работать
VFX должен:
- усиливать state readability;
- жить коротко;
- не перекрывать колёса и корпус байка надолго;
- не спорить с bright lip трассы и HUD.

### 5.2. Что запрещено
Не допускается:
- большой мутный облачный shape;
- тяжёлые alpha-like пятна;
- длинные lingering эффекты;
- финишный burst, перекрывающий player object.

## 6. Назначение каждого эффекта
### 6.1. `SPR_VFX_Dust_Start_01`
Назначение:
- дать стартовый импульс;
- подчеркнуть начало попытки.

### 6.2. `SPR_VFX_Dust_Run_01`
Назначение:
- поддерживать ощущение контакта и движения;
- работать тихо и ритмично.

### 6.3. `SPR_VFX_Land_Impact_01`
Назначение:
- подчеркнуть точку приземления;
- быстро отыграть контакт с поверхностью.

### 6.4. `SPR_VFX_Finish_Burst_01`
Назначение:
- коротко подтвердить finish state;
- не задерживать переход к result.

## 7. Размеры и формат
- small VFX elements: `8x8`, `16x16` или `32x16 px`;
- допускается немного больший canvas, если это оправдано силуэтом;
- integer upscale only.

## 8. Порядок исполнения
Строгий порядок:
1. `SPR_VFX_Dust_Start_01`;
2. `SPR_VFX_Dust_Run_01`;
3. `SPR_VFX_Land_Impact_01`;
4. `SPR_VFX_Finish_Burst_01`;
5. собрать short VFX mockups в связке с `bike_01` и `map_01`.

## 9. Промпт-ориентир для художника
Использовать следующие смысловые ориентиры:

Start dust:
- small pixel dust burst for arcade motorcycle race start, short, readable, angled backward, light shape, no smoke wall.

Run dust:
- minimal pixel dirt trail for side-view racing bike, low-noise, subtle, short-lived, secondary to bike silhouette.

Land impact:
- compact pixel ground impact puff for landing, quick burst, readable contact point, low clutter.

Finish burst:
- short celebratory pixel burst for finish confirmation, compact, readable, not blocking the rider.

## 10. Hand-off в Unity
На выходе Stage 5 должны быть переданы:
- PNG-файлы с каноническими именами;
- source file с чистыми слоями, если применимо;
- note по intended placement relative to wheels / ground / finish zone.

## 11. Definition of done
Stage 5 считается завершённым, если:
1. каждый эффект усиливает нужный state;
2. эффект читается быстро и живёт коротко;
3. bike и track остаются визуально приоритетными;
4. finish burst не мешает увидеть rider near finish;
5. naming соответствует канону.

## 12. Что проверять сразу после отрисовки
После первой отрисовки необходимо проверить:
- не перекрывает ли dust колёса слишком сильно;
- не выглядит ли run dust как постоянное грязное пятно;
- достаточно ли ясен landing impact;
- не спорит ли finish burst с finish set и result transition.

## 13. Следующий шаг
После завершения Stage 5 необходимо:
- показать VFX mockup pack;
- проверить эффекты на gameplay readability;
- затем переходить к интеграционной проверке всего first playable visual slice.
