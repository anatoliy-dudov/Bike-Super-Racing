# Bike Super Racing — Final Art Export Status

## 1. Назначение документа
Документ фиксирует статус финального экспорта ассетов art slice для current first playable.

Цель документа:
- показать, какие группы ассетов считаются собранными в финальный handoff-пакет;
- дать команде прозрачный статус перед интеграцией в Unity;
- зафиксировать, что текущий пакет является рабочим baseline, а не набором разрозненных промежуточных вариантов.

## 2. Статус по группам
### 2.1. Bike 01
Статус: **готово как handoff baseline**.

Включено:
- body;
- wheels;
- rider;
- shadow.

### 2.2. Map 01 core tiles
Статус: **готово как handoff baseline**.

Включено:
- flat;
- ground A/B;
- edge;
- crest;
- slope up/down;
- ramp.

### 2.3. Finish and background
Статус: **готово как handoff baseline**.

Включено:
- finish banner;
- finish posts;
- sky;
- horizon;
- decor 01.

### 2.4. Race UI must-have
Статус: **готово как handoff baseline**.

Включено:
- button system;
- timer panel;
- countdown set;
- result panel background;
- race icon.

### 2.5. VFX must-have
Статус: **готово как handoff baseline**.

Включено:
- start dust;
- run dust;
- land impact;
- finish burst.

## 3. Practical meaning of the status
Фраза **"готово как handoff baseline"** означает:
- пакет достаточно стабилен для передачи программистам и интеграторам;
- дальнейшие доработки допускаются только по результатам реальной Unity-интеграции и browser-scale проверки;
- новые альтернативные имена файлов не должны создаваться.

## 4. Integration rule
Любые дальнейшие визуальные исправления необходимо проводить:
- поверх уже утверждённых канонических имён;
- без раздувания scope;
- только по итогам фактической проверки в сцене и в браузерном масштабе.

## 5. Recommended next action
Следующее рекомендованное действие для команды:
- интегрировать пакет в Unity;
- проверить `02_Race` на gameplay readability;
- после этого зафиксировать список реальных, а не предполагаемых визуальных правок.
