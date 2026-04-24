using System;
using System.Collections.Generic;
using UnityEngine;

namespace BikeSuperRacing.Domain
{
    public enum RaceFlowState
    {
        None,
        EnterRaceScene,
        PreStart,
        Countdown,
        RaceActive,
        RaceFinished,
        ResultPresentation,
        RestartRequested,
        Pause
    }

    [CreateAssetMenu(menuName = "Bike Super Racing/Configs/Game Config", fileName = "CFG_Game_Main")]
    public sealed class GameConfig : ScriptableObject
    {
        public MapDefinition DefaultMap;
        public BikeDefinition DefaultBike;
        public BikeColorDefinition DefaultColor;
        public string DefaultLeaderboardId = "leaderboard_map_01";
        public string DefaultLanguage = "en";
        [Range(0f, 1f)] public float DefaultMusicVolume = 1f;
        [Range(0f, 1f)] public float DefaultSfxVolume = 1f;
    }

    [CreateAssetMenu(menuName = "Bike Super Racing/Configs/Map Definition", fileName = "CFG_Map_Map01")]
    public sealed class MapDefinition : ScriptableObject
    {
        public string Id = "map_01";
        public string DisplayName = "Map 01";
        public string SceneName = "02_Race";
        public string LeaderboardId = "leaderboard_map_01";
        public bool IsEnabled = true;
    }

    [CreateAssetMenu(menuName = "Bike Super Racing/Configs/Bike Definition", fileName = "CFG_Bike_Bike01")]
    public sealed class BikeDefinition : ScriptableObject
    {
        public string Id = "bike_01";
        public string DisplayName = "Bike 01";
        public float Acceleration = 1f;
        public float MaxSpeed = 1f;
        public float Handling = 1f;
        public bool IsEnabled = true;
    }

    [CreateAssetMenu(menuName = "Bike Super Racing/Configs/Bike Color Definition", fileName = "CFG_Color_Red")]
    public sealed class BikeColorDefinition : ScriptableObject
    {
        public string Id = "color_red";
        public string DisplayName = "Red";
        public string ColorHex = "#FF0000";
        public bool IsEnabled = true;
    }

    [Serializable]
    public sealed class MapBestTimeEntry
    {
        public string MapId = "map_01";
        public long BestTimeMs;
    }

    [Serializable]
    public sealed class PlayerProfile
    {
        public string SelectedBikeId = "bike_01";
        public string SelectedColorId = "color_red";
        public List<MapBestTimeEntry> BestTimesByMap = new List<MapBestTimeEntry>();
        public float MusicVolume = 1f;
        public float SfxVolume = 1f;
    }

    [Serializable]
    public sealed class RaceSession
    {
        public string MapId = "map_01";
        public string BikeId = "bike_01";
        public string ColorId = "color_red";
        public RaceFlowState State = RaceFlowState.None;
        public bool TimerRunning;
        public bool IsFinished;
    }

    [Serializable]
    public sealed class RaceResult
    {
        public string MapId = "map_01";
        public string BikeId = "bike_01";
        public string ColorId = "color_red";
        public long TotalTimeMs;
        public bool IsNewBest;
    }
}
