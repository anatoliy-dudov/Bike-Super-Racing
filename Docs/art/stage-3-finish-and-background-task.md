# Bike Super Racing — Stage 3 Drawing Task for `map_01` Finish Set and Background

## 1. Назначение задачи
Документ фиксирует отдельное рабочее ТЗ на Stage 3 для `map_01` в current first playable Bike Super Racing.

Задача Stage 3:
- отрисовать минимальный finish set;
- отрисовать low-noise background support;
- получить production-ready визуальную опору для завершённой сцены первой трассы;
- подготовить основу для интеграции в Unity и проверки читаемости на gameplay scale.

Stage 3 не покрывает:
- расширенный декоративный фон;
- сложный параллакс;
- погодные варианты;
- богатую анимацию окружения;
- пост-MVP декоративное разнообразие.

## 2. Состав Stage 3
В Stage 3 входят только следующие ассеты:
- `SPR_Map_Map01_FinishBanner`;
- `SPR_Map_Map01_FinishPost_Left`;
- `SPR_Map_Map01_FinishPost_Right`;
- `SPR_Map_Map01_BG_Sky`;
- `SPR_Map_Map01_BG_Horizon`;
- `SPR_Map_Map01_BG_Decor_01`.

## 3. Главная задача Stage 3
Игрок должен за долю секунды понять:
- где находится финиш;
- что сцена завершена визуально;
- что фон поддерживает мир, но не спорит с трассой и байком.

Если финиш красивый, но мешает чтению трассы или байка — Stage 3 провален.

## 4. Художественный target
Финиш и фон должны восприниматься как:
- чистые;
- аркадные;
- спортивные;
- лёгкие по деталям;
- читаемые на скорости.

Они не должны восприниматься как:
- тяжёлые декоративные объекты;
- визуальные барьеры;
- шумные фоновые иллюстрации;
- более важные, чем gameplay layer.

## 5. Размеры
### 5.1. Finish set
Размеры допускаются свободнее, чем у core tiles, но должны сохранять pixel-art дисциплину и compatibility с scene scale.

### 5.2. Background
Фоновые элементы могут быть крупнее, но должны оставаться простыми по форме и low-noise по контрасту.

## 6. Finish readability rules
### 6.1. Что должно читаться сразу
Игрок должен мгновенно понимать:
- это финишная линия;
- это цель текущей попытки;
- это не препятствие и не декоративный шум.

### 6.2. Что обязательно сохранить
- ясный силуэт двух стоек и баннера;
- хороший контраст с небом;
- ограниченную ширину и высоту без визуальной стены.

### 6.3. Что запрещено
Не допускается:
- чрезмерная ширина баннера;
- тяжёлый орнамент;
- слишком толстые стойки;
- визуальное перекрытие player object в критичный момент.

## 7. Background rules
### 7.1. Что должно работать
Фон должен:
- поддерживать ощущение мира;
- быть светлее и спокойнее трассы;
- усиливать разделение sky / grass / track;
- оставаться вторичным по отношению к bike и road profile.

### 7.2. Что запрещено
Не допускается:
- активная текстурность неба;
- слишком контрастный горизонт;
- декор, похожий на препятствие;
- фон, который спорит с финишем.

## 8. Reference direction
Для Stage 3 ориентиром остаётся Excite Bike как benchmark по читаемости:
- простое небо;
- чёткая полоса горизонта;
- минимум фонового шума;
- ясный аркадный финиш.

## 9. Порядок исполнения
Строгий порядок:
1. `SPR_Map_Map01_BG_Sky`;
2. `SPR_Map_Map01_BG_Horizon`;
3. `SPR_Map_Map01_BG_Decor_01`;
4. `SPR_Map_Map01_FinishPost_Left`;
5. `SPR_Map_Map01_FinishPost_Right`;
6. `SPR_Map_Map01_FinishBanner`;
7. собрать mockup сцены с core track, bike и finish set.

## 10. Промпт-ориентир для художника
Использовать следующие смысловые ориентиры:

Background:
- pixel art side-view racing background inspired by Excite Bike readability, simple blue sky, low-noise horizon, minimal decorative element, arcade clarity, secondary to bike and track.

Finish set:
- pixel art arcade racing finish line for side-view motorcycle game, two slim readable posts and compact banner, clean silhouette, visible against sky, no heavy decoration, browser-safe readability.

## 11. Hand-off в Unity
На выходе Stage 3 должны быть переданы:
- PNG-файлы с каноническими именами;
- source file с чистыми слоями, если применимо;
- краткая note по placement и layer order.

## 12. Definition of done
Stage 3 считается завершённым, если:
1. финиш мгновенно читается как цель;
2. фон завершает сцену, но не спорит с gameplay;
3. bike остаётся главным движущимся объектом;
4. finish set не превращается в визуальную стену;
5. naming соответствует канону.

## 13. Что проверять сразу после отрисовки
После первой отрисовки необходимо проверить:
- хорошо ли banner виден на фоне неба;
- не слишком ли толстые posts;
- не спорит ли decor с road profile;
- остаётся ли трасса главной по читаемости;
- не теряется ли bike рядом с finish zone.

## 14. Следующий шаг
После завершения Stage 3 необходимо:
- показать finish/background mockup;
- проверить сцепку с `bike_01` и `map_01` core tiles;
- затем переходить к race UI must-have assets.
