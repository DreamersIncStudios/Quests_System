using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DreamersInc.Quests
{
    public class QuestDatabase : IDatabase
    {
 
        private static List<Quest> questsList;
        private static bool IsLoaded { get; set; }

        public static void ValidateDatabase()
        {
            if (questsList == null || !IsLoaded)
            {
                questsList = new List<Quest>();
            }
            else
                IsLoaded = true;
        }

        private static void LoadDatabase(bool forceLoad = false)
        {
            if (IsLoaded && !forceLoad)
                return;
            questsList = new List<Quest>();
            var items = Resources.LoadAll<Quest>("Quests");
            foreach (var item in items)
            {
                if (!questsList.Contains(item))
                    questsList.Add(item);
            }

            IsLoaded = true;
        }

        public void ClearDatabase()
        {
            questsList = new List<Quest>();
            IsLoaded = false;
        }

        public static Quest GetQuest(uint ID)
        {
            ValidateDatabase();
            LoadDatabase();
            return questsList.FirstOrDefault(item => item.ID == ID);
        }


    }
}
