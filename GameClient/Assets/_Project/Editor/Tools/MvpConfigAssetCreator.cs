using System.IO;
using BikeSuperRacing.Domain.Bikes;
using BikeSuperRacing.Domain.Game;
using BikeSuperRacing.Domain.Maps;
using UnityEditor;
using UnityEngine;

namespace BikeSuperRacing.Editor.Tools
{
    public static class MvpConfigAssetCreator
    {
        private const string RootPath = "Assets/_Project/Configs";
        private const string GamePath = RootPath + "/Game";
        private const string MapsPath = RootPath + "/Maps";
        private const string BikesPath = RootPath + "/Bikes";
        private const string ColorsPath = RootPath + "/Colors";

        [MenuItem("Bike Super Racing/Setup/Create MVP Config Assets")]
        public static void CreateMvpConfigAssets()
        {
            EnsureFolder("Assets", "_Project");
            EnsureFolder("Assets/_Project", "Configs");
            EnsureFolder(RootPath, "Game");
            EnsureFolder(RootPath, "Maps");
            EnsureFolder(RootPath, "Bikes");
            EnsureFolder(RootPath, "Colors");

            var mapDefinition = CreateOrLoad<MapDefinition>(MapsPath + "/CFG_Map_Map01.asset");
            ConfigureMap(mapDefinition);

            var bikeDefinition = CreateOrLoad<BikeDefinition>(BikesPath + "/CFG_Bike_Bike01.asset");
            ConfigureBike(bikeDefinition);

            var bikeColorDefinition = CreateOrLoad<BikeColorDefinition>(ColorsPath + "/CFG_Color_Red.asset");
            ConfigureBikeColor(bikeColorDefinition);

            var gameConfig = CreateOrLoad<GameConfig>(GamePath + "/CFG_Game_Main.asset");
            ConfigureGameConfig(gameConfig, mapDefinition, bikeDefinition, bikeColorDefinition);

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
            Selection.activeObject = gameConfig;
            EditorGUIUtility.PingObject(gameConfig);
            Debug.Log("MvpConfigAssetCreator: MVP config assets are ready.");
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

        private static void ConfigureGameConfig(
            GameConfig gameConfig,
            MapDefinition mapDefinition,
            BikeDefinition bikeDefinition,
            BikeColorDefinition bikeColorDefinition)
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
