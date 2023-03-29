﻿using UnityEngine;
using Debug = UnityEngine.Debug;

namespace DiningCombat
{
    public static class GameGlobal
    {
        public static class GameObjectName
        {
            public const string k_Player = "Player";
            public const string k_PickUpPoint = "PickUpPoint";
            public const string k_Ground = "Ground";
        }
        public static class TagNames
        {
            public const string k_Ground = "Ground";
            public const string k_Capsule = "Capsule";
            public const string k_FoodObj = "FoodObj";
            public const string k_ThrowFoodObj = "ThrownObject";
            public const string k_Player = "Player";
            public const string k_Picked = "Picked";
        }

        public static class AnimationName
        {
            public const string k_Running = "isRunning";
            public const string k_RunningSide = "isSideRun";
            public const string k_Throwing = "isThrowing";
        }

        public static class FoodObjData
        {
            public const byte k_NumOfPrefab = 4; 
            // hit 
            public const string k_Apple = "Apple";
            public const byte k_AppleVar = 0;
            public const string k_AppleLocation = @"FoodPrefab\Apple";

            public const string k_Tomato = "Tomato";
            public const byte k_TomatoVar = 1;
            public const string k_TomatoLocation = @"FoodPrefab\Tomato";

            // Dispersing
            public const string k_Cabbage = "Cabbage";
            public const byte k_CabbageVar = 2;
            public const string k_CabbageLocation = @"FoodPrefab\Cabbage";

            // 
            public const string k_Flour = "Flour";
            public const byte k_FlourVar = 3;
            public const string k_FlourLocation = @"FoodPrefab\Flour";

        }

        public static class PlayerDataG
        {
            public const float k_MaxPlayerLife = 100;

            public const float k_DefaultPlayerMovementJumpHeight = 2f;
            public const float k_DefaultPlayerMovementRunSpeed = 20;
            public const float k_DefaultPlayerMovementRunSideSpeed = 5;
            public const float k_DefaultPlayerMovementGroundCheckDistance = 0.2F;
            public const float k_DefaultPlayerMovementGravity = -9.81F;

            public const float k_DefaultCameraFollowMouseSensetivity = 1000f;

            public const float k_MinDistanceToPickUp = 2f;
            public const int k_MaxItemToPick = 1;
        }
        // ==================================================
        // Default-SerializeField-val
        // k_ Default - class name - var name
        // ==================================================

        public static void Dedugger(string i_ClassName, string i_FuncName, string i_Vars)
        {
            Debug.Log(i_ClassName+"->( "+ i_FuncName +"):  "+ i_Vars);  
        }

        public static string GetGameGlobalLocation()
        {
            return null;
        }

        public enum ePlayerModeType
        {
            OfflinePlayer,
            OfflineAiPlayer,
            OfflineTestPlayer,
            OnlinePlayer,
            OnlineAiPlayer,
            OnlineTestPlayer,
        }
    }
}