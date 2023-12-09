using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace DreamersInc.Quests
{
    public interface IDatabase
    {
       static bool IsLoaded { get; }
        static void ValidateDatabase()
        {
            
        }

        static void LoadDatabase(bool forceLoad)
        {
        }

        static void ClearDatabase()
        {
        }

    }

    public sealed class MissionDatabase : IDatabase

    {
        private static List<Mission> missionList;
        private static bool IsLoaded { get; set; }
        public static uint Count => (uint)missionList.Count;
        public static void ValidateDatabase()
        {
            if (missionList == null || !IsLoaded)
            {
                missionList = new List<Mission>();
            }
            else
                IsLoaded = true;
        }

        private static void LoadDatabase(bool forceLoad = false)
        {
            if (IsLoaded && !forceLoad)
                return;
            missionList = new List<Mission>();
            var items = Resources.LoadAll<Mission>("Missions");
            foreach (var item in items)
            {
                if (!missionList.Contains(item))
                    missionList.Add(item);
            }

            IsLoaded = true;
        }

        public void ClearDatabase()
        {
            missionList = new List<Mission>();
            IsLoaded = false;
        }

        public static Mission GetMission(uint ID)
        {
            ValidateDatabase();
            LoadDatabase();
            return missionList.FirstOrDefault(item => item.ID == ID);
        }
        
    
    }
}
