# Config Asset Baseline

These ScriptableObject asset instances must be created in Unity Editor:
- `CFG_Game_Main`
- `CFG_Map_Map01`
- `CFG_Bike_Bike01`
- `CFG_Color_Red`

Recommended canonical locations:
- `Assets/_Project/Configs/Game/CFG_Game_Main.asset`
- `Assets/_Project/Configs/Maps/CFG_Map_Map01.asset`
- `Assets/_Project/Configs/Bikes/CFG_Bike_Bike01.asset`
- `Assets/_Project/Configs/Bikes/CFG_Color_Red.asset`

## Why these are not committed here yet
Valid `.asset` files require Unity-generated script GUID references and should be created by the Unity programmer in Unity Editor.
