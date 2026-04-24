using System.IO;
using BikeSuperRacing.Bootstrap.EntryPoint;
using BikeSuperRacing.Domain.Bikes;
using BikeSuperRacing.Domain.Game;
using BikeSuperRacing.Domain.Maps;
using BikeSuperRacing.Gameplay.Bike.Controllers;
using BikeSuperRacing.Gameplay.Bike.View;
using BikeSuperRacing.Gameplay.Finish;
using BikeSuperRacing.Gameplay.RaceFlow;
using BikeSuperRacing.UI.HUD;
using BikeSuperRacing.UI.Popups.Leaderboard;
using BikeSuperRacing.UI.Popups.Settings;
using BikeSuperRacing.UI.Screens.MainMenu;
using BikeSuperRacing.UI.Screens.Result;
using BikeSuperRacing.UI.Widgets;
using TMPro;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace BikeSuperRacing.Editor.Tools
{
    public static class MvpConfigAssetCreator
    {
        private const string RootPath = "Assets/_Project";
        private const string ConfigsPath = RootPath + "/Configs";
        private const string GamePath = ConfigsPath + "/Game";
        private const string MapsPath = ConfigsPath + "/Maps";
        private const string BikesPath = ConfigsPath + "/Bikes";
        private const string ColorsPath = ConfigsPath + "/Colors";
        private const string ScenesPath = RootPath + "/Scenes";

        private const string GameConfigPath = GamePath + "/CFG_Game_Main.asset";
        private const string MapConfigPath = MapsPath + "/CFG_Map_Map01.asset";
        private const string BikeConfigPath = BikesPath + "/CFG_Bike_Bike01.asset";
        private const string ColorConfigPath = ColorsPath + "/CFG_Color_Red.asset";

        private const string BootstrapScenePath = ScenesPath + "/00_Bootstrap.unity";
        private const string MainMenuScenePath = ScenesPath + "/01_MainMenu.unity";
        private const string RaceScenePath = ScenesPath + "/02_Race.unity";

        [MenuItem("Bike Super Racing/Setup/Create MVP Config Assets")]
        public static void CreateMvpConfigAssets()
        {
            EnsureFolder("Assets", "_Project");
            EnsureFolder(RootPath, "Configs");
            EnsureFolder(ConfigsPath, "Game");
            EnsureFolder(ConfigsPath, "Maps");
            EnsureFolder(ConfigsPath, "Bikes");
            EnsureFolder(ConfigsPath, "Colors");

            var mapDefinition = CreateOrLoad<MapDefinition>(MapConfigPath);
            ConfigureMap(mapDefinition);

            var bikeDefinition = CreateOrLoad<BikeDefinition>(BikeConfigPath);
            ConfigureBike(bikeDefinition);

            var bikeColorDefinition = CreateOrLoad<BikeColorDefinition>(ColorConfigPath);
            ConfigureBikeColor(bikeColorDefinition);

            var gameConfig = CreateOrLoad<GameConfig>(GameConfigPath);
            ConfigureGameConfig(gameConfig, mapDefinition, bikeDefinition, bikeColorDefinition);

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            Selection.activeObject = gameConfig;
            EditorGUIUtility.PingObject(gameConfig);
            Debug.Log("MvpConfigAssetCreator: MVP config assets are ready.");
        }

        [MenuItem("Bike Super Racing/Setup/Create MVP Scenes and Build Settings")]
        public static void CreateMvpScenesAndBuildSettings()
        {
            EnsureFolder("Assets", "_Project");
            EnsureFolder(RootPath, "Scenes");

            var gameConfig = AssetDatabase.LoadAssetAtPath<GameConfig>(GameConfigPath);

            if (gameConfig == null)
            {
                Debug.LogError("MvpConfigAssetCreator: CFG_Game_Main is missing. Create config assets first.");
                return;
            }

            CreateBootstrapScene(gameConfig);
            CreateMainMenuScene();
            CreateRaceScene();
            ConfigureBuildSettings();
            AssetDatabase.Refresh();
            Debug.Log("MvpConfigAssetCreator: MVP scenes and build settings are ready.");
        }

        [MenuItem("Bike Super Racing/Setup/Create Full MVP Setup")]
        public static void CreateFullMvpSetup()
        {
            CreateMvpConfigAssets();
            CreateMvpScenesAndBuildSettings();
            AssetDatabase.Refresh();
            Debug.Log("MvpConfigAssetCreator: full MVP setup is ready.");
        }

        private static void CreateBootstrapScene(GameConfig gameConfig)
        {
            var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
            CreateCamera("Main Camera", new Vector3(0f, 0f, -10f), true, 5f);

            var bootstrapRoot = new GameObject("BootstrapRoot");
            var bootstrapper = bootstrapRoot.AddComponent<Bootstrapper>();
            var serializedObject = new SerializedObject(bootstrapper);
            serializedObject.FindProperty("_gameConfig").objectReferenceValue = gameConfig;
            serializedObject.FindProperty("_loadMainMenuOnStart").boolValue = true;
            serializedObject.FindProperty("_verboseLogging").boolValue = true;
            serializedObject.ApplyModifiedPropertiesWithoutUndo();
            EditorUtility.SetDirty(bootstrapper);

            EditorSceneManager.SaveScene(scene, BootstrapScenePath);
        }

        private static void CreateMainMenuScene()
        {
            var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
            CreateCamera("Main Camera", new Vector3(0f, 0f, -10f), true, 5f);
            CreateEventSystem();

            var canvas = CreateCanvas();
            var titleText = CreateText(canvas.transform, "TitleText", "Bike Super Racing", new Vector2(0f, 220f), new Vector2(600f, 90f), 48f);
            var playButton = CreateButton(canvas.transform, "PlayButton", "Play", new Vector2(0f, 80f), new Vector2(280f, 80f));
            var settingsButton = CreateButton(canvas.transform, "SettingsButton", "Settings", new Vector2(0f, -20f), new Vector2(280f, 70f));
            var leaderboardButton = CreateButton(canvas.transform, "LeaderboardButton", "Leaderboard", new Vector2(0f, -110f), new Vector2(280f, 70f));

            var settingsPopupRoot = CreatePopup(canvas.transform, "SettingsPopupRoot", "Settings Placeholder", out var settingsCloseButton);
            var leaderboardPopupRoot = CreatePopup(canvas.transform, "LeaderboardPopupRoot", "Leaderboard Placeholder", out var leaderboardCloseButton);

            var settingsPopup = settingsPopupRoot.AddComponent<SettingsPopup>();
            AssignSettingsPopup(settingsPopup, settingsPopupRoot, settingsCloseButton);
            settingsPopupRoot.SetActive(false);

            var leaderboardPopup = leaderboardPopupRoot.AddComponent<LeaderboardPopup>();
            AssignLeaderboardPopup(leaderboardPopup, leaderboardPopupRoot, leaderboardCloseButton);
            leaderboardPopupRoot.SetActive(false);

            var mainMenuRoot = new GameObject("MainMenuRoot");
            var mainMenuScreen = mainMenuRoot.AddComponent<MainMenuScreen>();
            AssignMainMenuScreen(mainMenuScreen, playButton, settingsButton, leaderboardButton, settingsPopupRoot, leaderboardPopupRoot);

            EditorSceneManager.SaveScene(scene, MainMenuScenePath);
        }

        private static void CreateRaceScene()
        {
            var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene, NewSceneMode.Single);
            CreateCamera("Main Camera", new Vector3(0f, 0f, -10f), true, 5.5f);
            CreateEventSystem();

            var startPoint = new GameObject("StartPoint").transform;
            startPoint.position = new Vector3(-7f, -1.6f, 0f);

            var ground = new GameObject("Ground");
            ground.transform.position = new Vector3(0f, -3f, 0f);
            ground.transform.localScale = new Vector3(30f, 1f, 1f);
            var groundRenderer = ground.AddComponent<SpriteRenderer>();
            groundRenderer.sprite = GetBuiltinSprite();
            groundRenderer.color = new Color(0.35f, 0.23f, 0.12f, 1f);
            var groundCollider = ground.AddComponent<BoxCollider2D>();
            groundCollider.size = new Vector2(1f, 1f);

            var bikeRoot = new GameObject("PREF_Bike_Bike01");
            bikeRoot.transform.position = startPoint.position;
            var rigidbody2D = bikeRoot.AddComponent<Rigidbody2D>();
            rigidbody2D.gravityScale = 3f;
            rigidbody2D.freezeRotation = true;
            bikeRoot.AddComponent<BoxCollider2D>();
            var bikeController2D = bikeRoot.AddComponent<BikeController2D>();
            var bikeColorApplier = bikeRoot.AddComponent<BikeColorApplier>();

            var bikeBody = new GameObject("Body");
            bikeBody.transform.SetParent(bikeRoot.transform, false);
            var bikeBodyRenderer = bikeBody.AddComponent<SpriteRenderer>();
            bikeBodyRenderer.sprite = GetBuiltinSprite();
            bikeBodyRenderer.color = Color.red;
            bikeBody.transform.localScale = new Vector3(1.6f, 0.6f, 1f);

            AssignBikeColorApplier(bikeColorApplier, new[] { bikeBodyRenderer });

            var finishLine = new GameObject("FinishLine");
            finishLine.transform.position = new Vector3(12f, -1.5f, 0f);
            var finishRenderer = finishLine.AddComponent<SpriteRenderer>();
            finishRenderer.sprite = GetBuiltinSprite();
            finishRenderer.color = Color.white;
            finishLine.transform.localScale = new Vector3(0.3f, 4f, 1f);
            var finishCollider = finishLine.AddComponent<BoxCollider2D>();
            finishCollider.isTrigger = true;
            var finishTrigger = finishLine.AddComponent<FinishTrigger>();

            var canvas = CreateCanvas();
            var timerText = CreateText(canvas.transform, "TimerText", "00:00.000", new Vector2(0f, 290f), new Vector2(300f, 60f), 32f);
            var pauseButton = CreateButton(canvas.transform, "PauseButton", "Pause", new Vector2(-520f, 290f), new Vector2(140f, 50f));
            var countdownRoot = new GameObject("CountdownRoot", typeof(RectTransform), typeof(CanvasRenderer), typeof(Image));
            countdownRoot.transform.SetParent(canvas.transform, false);
            var countdownRect = countdownRoot.GetComponent<RectTransform>();
            countdownRect.sizeDelta = new Vector2(260f, 180f);
            countdownRect.anchoredPosition = Vector2.zero;
            var countdownBackground = countdownRoot.GetComponent<Image>();
            countdownBackground.color = new Color(0f, 0f, 0f, 0.35f);
            var countdownText = CreateText(countdownRoot.transform, "CountdownText", string.Empty, Vector2.zero, new Vector2(200f, 120f), 72f);
            countdownRoot.SetActive(false);

            var resultRoot = new GameObject("ResultRoot", typeof(RectTransform), typeof(CanvasRenderer), typeof(Image));
            resultRoot.transform.SetParent(canvas.transform, false);
            var resultRect = resultRoot.GetComponent<RectTransform>();
            resultRect.sizeDelta = new Vector2(520f, 360f);
            resultRect.anchoredPosition = new Vector2(0f, -10f);
            var resultBackground = resultRoot.GetComponent<Image>();
            resultBackground.color = new Color(0f, 0f, 0f, 0.65f);
            var currentTimeText = CreateText(resultRoot.transform, "CurrentTimeText", "00:00.000", new Vector2(0f, 100f), new Vector2(360f, 60f), 38f);
            var bestTimeText = CreateText(resultRoot.transform, "BestTimeText", "00:00.000", new Vector2(0f, 45f), new Vector2(320f, 50f), 26f);
            var newBestRoot = CreateText(resultRoot.transform, "NewBestText", "NEW BEST", new Vector2(0f, 150f), new Vector2(240f, 40f), 24f).gameObject;
            var restartButton = CreateButton(resultRoot.transform, "RestartButton", "Restart", new Vector2(0f, -40f), new Vector2(240f, 70f));
            var backButton = CreateButton(resultRoot.transform, "BackButton", "Back to Menu", new Vector2(0f, -130f), new Vector2(240f, 60f));
            resultRoot.SetActive(false);
            newBestRoot.SetActive(false);

            var raceHudView = new GameObject("PREF_UI_RaceHudView").AddComponent<RaceHudView>();
            raceHudView.transform.SetParent(canvas.transform, false);
            AssignRaceHudView(raceHudView, timerText, pauseButton, raceHudView.gameObject);

            var countdownWidget = countdownRoot.AddComponent<CountdownWidget>();
            AssignCountdownWidget(countdownWidget, countdownText, countdownRoot);

            var resultPanel = resultRoot.AddComponent<ResultPanel>();
            AssignResultPanel(resultPanel, currentTimeText, bestTimeText, newBestRoot, restartButton, backButton, resultRoot);

            var raceRoot = new GameObject("RaceRoot");
            var raceFlowController = raceRoot.AddComponent<RaceFlowController>();
            AssignRaceFlowController(
                raceFlowController,
                bikeRoot.transform,
                rigidbody2D,
                bikeController2D,
                bikeColorApplier,
                new Behaviour[] { bikeController2D },
                startPoint,
                finishTrigger,
                raceHudView,
                countdownWidget,
                resultPanel);

            AssignFinishTrigger(finishTrigger, raceFlowController);
            EditorSceneManager.SaveScene(scene, RaceScenePath);
        }

        private static void ConfigureBuildSettings()
        {
            EditorBuildSettings.scenes = new[]
            {
                new EditorBuildSettingsScene(BootstrapScenePath, true),
                new EditorBuildSettingsScene(MainMenuScenePath, true),
                new EditorBuildSettingsScene(RaceScenePath, true),
            };
        }

        private static void ConfigureMap(MapDefinition mapDefinition)
        {
            var serializedObject = new SerializedObject(mapDefinition);
            serializedObject.FindProperty("_id").stringValue = "map_01";
            serializedObject.FindProperty("_displayName").stringValue = "Map 01";
            serializedObject.FindProperty("_sceneName").stringValue = "02_Race";
            serializedObject.FindProperty("_leaderboardId").stringValue = "leaderboard_map_01";
            serializedObject.FindProperty("_isEnabled").boolValue = true;
            serializedObject.ApplyModifiedPropertiesWithoutUndo();
            EditorUtility.SetDirty(mapDefinition);
        }

        private static void ConfigureBike(BikeDefinition bikeDefinition)
        {
            var serializedObject = new SerializedObject(bikeDefinition);
            serializedObject.FindProperty("_id").stringValue = "bike_01";
            serializedObject.FindProperty("_displayName").stringValue = "Bike 01";
            serializedObject.FindProperty("_acceleration").floatValue = 20f;
            serializedObject.FindProperty("_maxSpeed").floatValue = 18f;
            serializedObject.FindProperty("_handling").floatValue = 12f;
            serializedObject.FindProperty("_isEnabled").boolValue = true;
            serializedObject.ApplyModifiedPropertiesWithoutUndo();
            EditorUtility.SetDirty(bikeDefinition);
        }

        private static void ConfigureBikeColor(BikeColorDefinition bikeColorDefinition)
        {
            var serializedObject = new SerializedObject(bikeColorDefinition);
            serializedObject.FindProperty("_id").stringValue = "color_red";
            serializedObject.FindProperty("_displayName").stringValue = "Red";
            serializedObject.FindProperty("_colorHex").stringValue = "#FF0000";
            serializedObject.FindProperty("_isEnabled").boolValue = true;
            serializedObject.ApplyModifiedPropertiesWithoutUndo();
            EditorUtility.SetDirty(bikeColorDefinition);
        }

        private static void ConfigureGameConfig(GameConfig gameConfig, MapDefinition mapDefinition, BikeDefinition bikeDefinition, BikeColorDefinition bikeColorDefinition)
        {
            var serializedObject = new SerializedObject(gameConfig);
            serializedObject.FindProperty("_bootstrapSceneName").stringValue = "00_Bootstrap";
            serializedObject.FindProperty("_mainMenuSceneName").stringValue = "01_MainMenu";
            serializedObject.FindProperty("_raceSceneName").stringValue = "02_Race";
            serializedObject.FindProperty("_defaultMap").objectReferenceValue = mapDefinition;
            serializedObject.FindProperty("_defaultBike").objectReferenceValue = bikeDefinition;
            serializedObject.FindProperty("_defaultColor").objectReferenceValue = bikeColorDefinition;
            serializedObject.FindProperty("_saveFileName").stringValue = "bike_super_racing_profile.json";

            var mapsProperty = serializedObject.FindProperty("_maps");
            mapsProperty.arraySize = 1;
            mapsProperty.GetArrayElementAtIndex(0).objectReferenceValue = mapDefinition;

            var bikesProperty = serializedObject.FindProperty("_bikes");
            bikesProperty.arraySize = 1;
            bikesProperty.GetArrayElementAtIndex(0).objectReferenceValue = bikeDefinition;

            var bikeColorsProperty = serializedObject.FindProperty("_bikeColors");
            bikeColorsProperty.arraySize = 1;
            bikeColorsProperty.GetArrayElementAtIndex(0).objectReferenceValue = bikeColorDefinition;

            serializedObject.ApplyModifiedPropertiesWithoutUndo();
            EditorUtility.SetDirty(gameConfig);
        }

        private static void AssignMainMenuScreen(MainMenuScreen mainMenuScreen, Button playButton, Button settingsButton, Button leaderboardButton, GameObject settingsPopupRoot, GameObject leaderboardPopupRoot)
        {
            var serializedObject = new SerializedObject(mainMenuScreen);
            serializedObject.FindProperty("_playButton").objectReferenceValue = playButton;
            serializedObject.FindProperty("_settingsButton").objectReferenceValue = settingsButton;
            serializedObject.FindProperty("_leaderboardButton").objectReferenceValue = leaderboardButton;
            serializedObject.FindProperty("_settingsPopupRoot").objectReferenceValue = settingsPopupRoot;
            serializedObject.FindProperty("_leaderboardPopupRoot").objectReferenceValue = leaderboardPopupRoot;
            serializedObject.ApplyModifiedPropertiesWithoutUndo();
            EditorUtility.SetDirty(mainMenuScreen);
        }

        private static void AssignSettingsPopup(SettingsPopup settingsPopup, GameObject root, Button closeButton)
        {
            var serializedObject = new SerializedObject(settingsPopup);
            serializedObject.FindProperty("_root").objectReferenceValue = root;
            serializedObject.FindProperty("_closeButton").objectReferenceValue = closeButton;
            serializedObject.ApplyModifiedPropertiesWithoutUndo();
            EditorUtility.SetDirty(settingsPopup);
        }

        private static void AssignLeaderboardPopup(LeaderboardPopup leaderboardPopup, GameObject root, Button closeButton)
        {
            var serializedObject = new SerializedObject(leaderboardPopup);
            serializedObject.FindProperty("_root").objectReferenceValue = root;
            serializedObject.FindProperty("_closeButton").objectReferenceValue = closeButton;
            serializedObject.ApplyModifiedPropertiesWithoutUndo();
            EditorUtility.SetDirty(leaderboardPopup);
        }

        private static void AssignRaceHudView(RaceHudView raceHudView, TMP_Text timerText, Button pauseButton, GameObject root)
        {
            var serializedObject = new SerializedObject(raceHudView);
            serializedObject.FindProperty("_timerText").objectReferenceValue = timerText;
            serializedObject.FindProperty("_pauseButton").objectReferenceValue = pauseButton;
            serializedObject.FindProperty("_root").objectReferenceValue = root;
            serializedObject.ApplyModifiedPropertiesWithoutUndo();
            EditorUtility.SetDirty(raceHudView);
        }

        private static void AssignCountdownWidget(CountdownWidget countdownWidget, TMP_Text valueText, GameObject root)
        {
            var serializedObject = new SerializedObject(countdownWidget);
            serializedObject.FindProperty("_valueText").objectReferenceValue = valueText;
            serializedObject.FindProperty("_root").objectReferenceValue = root;
            serializedObject.ApplyModifiedPropertiesWithoutUndo();
            EditorUtility.SetDirty(countdownWidget);
        }

        private static void AssignResultPanel(ResultPanel resultPanel, TMP_Text currentTimeText, TMP_Text bestTimeText, GameObject newBestRoot, Button restartButton, Button backButton, GameObject root)
        {
            var serializedObject = new SerializedObject(resultPanel);
            serializedObject.FindProperty("_currentTimeText").objectReferenceValue = currentTimeText;
            serializedObject.FindProperty("_bestTimeText").objectReferenceValue = bestTimeText;
            serializedObject.FindProperty("_newBestRoot").objectReferenceValue = newBestRoot;
            serializedObject.FindProperty("_restartButton").objectReferenceValue = restartButton;
            serializedObject.FindProperty("_backButton").objectReferenceValue = backButton;
            serializedObject.FindProperty("_root").objectReferenceValue = root;
            serializedObject.ApplyModifiedPropertiesWithoutUndo();
            EditorUtility.SetDirty(resultPanel);
        }

        private static void AssignBikeColorApplier(BikeColorApplier bikeColorApplier, SpriteRenderer[] targetRenderers)
        {
            var serializedObject = new SerializedObject(bikeColorApplier);
            var targetRenderersProperty = serializedObject.FindProperty("_targetRenderers");
            targetRenderersProperty.arraySize = targetRenderers.Length;

            for (var i = 0; i < targetRenderers.Length; i++)
            {
                targetRenderersProperty.GetArrayElementAtIndex(i).objectReferenceValue = targetRenderers[i];
            }

            serializedObject.ApplyModifiedPropertiesWithoutUndo();
            EditorUtility.SetDirty(bikeColorApplier);
        }

        private static void AssignFinishTrigger(FinishTrigger finishTrigger, RaceFlowController raceFlowController)
        {
            var serializedObject = new SerializedObject(finishTrigger);
            serializedObject.FindProperty("_raceFlowController").objectReferenceValue = raceFlowController;
            serializedObject.ApplyModifiedPropertiesWithoutUndo();
            EditorUtility.SetDirty(finishTrigger);
        }

        private static void AssignRaceFlowController(
            RaceFlowController raceFlowController,
            Transform bikeTransform,
            Rigidbody2D bikeRigidbody2D,
            BikeController2D bikeController2D,
            BikeColorApplier bikeColorApplier,
            Behaviour[] controlBehaviours,
            Transform startPoint,
            FinishTrigger finishTrigger,
            RaceHudView raceHudView,
            CountdownWidget countdownWidget,
            ResultPanel resultPanel)
        {
            var serializedObject = new SerializedObject(raceFlowController);
            serializedObject.FindProperty("_bikeTransform").objectReferenceValue = bikeTransform;
            serializedObject.FindProperty("_bikeRigidbody2D").objectReferenceValue = bikeRigidbody2D;
            serializedObject.FindProperty("_bikeController2D").objectReferenceValue = bikeController2D;
            serializedObject.FindProperty("_bikeColorApplier").objectReferenceValue = bikeColorApplier;
            serializedObject.FindProperty("_startPoint").objectReferenceValue = startPoint;
            serializedObject.FindProperty("_finishTrigger").objectReferenceValue = finishTrigger;
            serializedObject.FindProperty("_raceHudView").objectReferenceValue = raceHudView;
            serializedObject.FindProperty("_countdownWidget").objectReferenceValue = countdownWidget;
            serializedObject.FindProperty("_resultPanel").objectReferenceValue = resultPanel;
            serializedObject.FindProperty("_countdownDurationSeconds").floatValue = 5f;
            serializedObject.FindProperty("_autoStartCountdownOnStart").boolValue = true;

            var controlBehavioursProperty = serializedObject.FindProperty("_controlBehaviours");
            controlBehavioursProperty.arraySize = controlBehaviours.Length;

            for (var i = 0; i < controlBehaviours.Length; i++)
            {
                controlBehavioursProperty.GetArrayElementAtIndex(i).objectReferenceValue = controlBehaviours[i];
            }

            serializedObject.ApplyModifiedPropertiesWithoutUndo();
            EditorUtility.SetDirty(raceFlowController);
        }

        private static Canvas CreateCanvas()
        {
            var canvasObject = new GameObject("Canvas", typeof(RectTransform), typeof(Canvas), typeof(CanvasScaler), typeof(GraphicRaycaster));
            var canvas = canvasObject.GetComponent<Canvas>();
            canvas.renderMode = RenderMode.ScreenSpaceOverlay;

            var canvasScaler = canvasObject.GetComponent<CanvasScaler>();
            canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
            canvasScaler.referenceResolution = new Vector2(1280f, 720f);
            canvasScaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
            canvasScaler.matchWidthOrHeight = 0.5f;
            return canvas;
        }

        private static void CreateEventSystem()
        {
            if (Object.FindFirstObjectByType<EventSystem>() != null)
            {
                return;
            }

            new GameObject("EventSystem", typeof(EventSystem), typeof(StandaloneInputModule));
        }

        private static Camera CreateCamera(string objectName, Vector3 position, bool orthographic, float orthographicSize)
        {
            var cameraObject = new GameObject(objectName, typeof(Camera), typeof(AudioListener));
            cameraObject.transform.position = position;
            var camera = cameraObject.GetComponent<Camera>();
            camera.orthographic = orthographic;
            camera.orthographicSize = orthographicSize;
            camera.clearFlags = CameraClearFlags.SolidColor;
            camera.backgroundColor = new Color(0.54f, 0.78f, 0.98f, 1f);
            return camera;
        }

        private static TextMeshProUGUI CreateText(Transform parent, string objectName, string text, Vector2 anchoredPosition, Vector2 sizeDelta, float fontSize)
        {
            var textObject = new GameObject(objectName, typeof(RectTransform), typeof(TextMeshProUGUI));
            textObject.transform.SetParent(parent, false);
            var rectTransform = textObject.GetComponent<RectTransform>();
            rectTransform.sizeDelta = sizeDelta;
            rectTransform.anchoredPosition = anchoredPosition;
            var tmpText = textObject.GetComponent<TextMeshProUGUI>();
            tmpText.text = text;
            tmpText.fontSize = fontSize;
            tmpText.alignment = TextAlignmentOptions.Center;
            tmpText.color = Color.white;
            tmpText.font = TMP_Settings.defaultFontAsset;
            return tmpText;
        }

        private static Button CreateButton(Transform parent, string objectName, string label, Vector2 anchoredPosition, Vector2 sizeDelta)
        {
            var buttonObject = new GameObject(objectName, typeof(RectTransform), typeof(Image), typeof(Button));
            buttonObject.transform.SetParent(parent, false);
            var rectTransform = buttonObject.GetComponent<RectTransform>();
            rectTransform.sizeDelta = sizeDelta;
            rectTransform.anchoredPosition = anchoredPosition;

            var image = buttonObject.GetComponent<Image>();
            image.sprite = GetBuiltinSprite();
            image.type = Image.Type.Sliced;
            image.color = new Color(0.12f, 0.12f, 0.12f, 0.92f);

            var labelText = CreateText(buttonObject.transform, "Label", label, Vector2.zero, sizeDelta, 28f);
            labelText.raycastTarget = false;
            return buttonObject.GetComponent<Button>();
        }

        private static GameObject CreatePopup(Transform parent, string objectName, string title, out Button closeButton)
        {
            var popupRoot = new GameObject(objectName, typeof(RectTransform), typeof(CanvasRenderer), typeof(Image));
            popupRoot.transform.SetParent(parent, false);
            var rectTransform = popupRoot.GetComponent<RectTransform>();
            rectTransform.sizeDelta = new Vector2(540f, 320f);
            rectTransform.anchoredPosition = Vector2.zero;
            var image = popupRoot.GetComponent<Image>();
            image.sprite = GetBuiltinSprite();
            image.type = Image.Type.Sliced;
            image.color = new Color(0f, 0f, 0f, 0.7f);

            CreateText(popupRoot.transform, "Title", title, new Vector2(0f, 100f), new Vector2(420f, 60f), 34f);
            CreateText(popupRoot.transform, "Body", "Placeholder", new Vector2(0f, 20f), new Vector2(380f, 40f), 22f);
            closeButton = CreateButton(popupRoot.transform, "CloseButton", "Close", new Vector2(0f, -90f), new Vector2(220f, 64f));
            return popupRoot;
        }

        private static Sprite GetBuiltinSprite()
        {
            return AssetDatabase.GetBuiltinExtraResource<Sprite>("UI/Skin/UISprite.psd");
        }

        private static T CreateOrLoad<T>(string assetPath) where T : ScriptableObject
        {
            var asset = AssetDatabase.LoadAssetAtPath<T>(assetPath);

            if (asset != null)
            {
                return asset;
            }

            asset = ScriptableObject.CreateInstance<T>();
            AssetDatabase.CreateAsset(asset, assetPath);
            return asset;
        }

        private static void EnsureFolder(string parentPath, string folderName)
        {
            var fullPath = Path.Combine(parentPath, folderName).Replace("\\", "/");

            if (AssetDatabase.IsValidFolder(fullPath))
            {
                return;
            }

            AssetDatabase.CreateFolder(parentPath, folderName);
        }
    }
}
