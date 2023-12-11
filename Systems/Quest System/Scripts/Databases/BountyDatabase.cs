using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DreamersInc.Quests
{
    public sealed class BountyDatabase : IDatabase
    {
        
        private static List<Bounty> bountyList;
        private static bool IsLoaded { get; set; }
        public static uint Count => (uint)bountyList.Count;
        public static void ValidateDatabase()
        {
            if (bountyList == null || !IsLoaded)
            {
                bountyList = new List<Bounty>();
            }
            else
                IsLoaded = true;
        }
        public static void LoadDatabase(bool forceLoad = false)
        {
            if (IsLoaded && !forceLoad)
                return;
            bountyList = new List<Bounty>();
            var items = Resources.LoadAll<Bounty>("Bounty");
            foreach (var item in items)
            {
                if (!bountyList.Contains(item))
                    bountyList.Add(item);
            }

            IsLoaded = true;
        }
        public void ClearDatabase()
        {
            bountyList = new List<Bounty>();
            IsLoaded = false;
        }

        public static Bounty Bounty(uint ID)
        {
            ValidateDatabase();
            LoadDatabase();
            return bountyList.FirstOrDefault(item => item.ID == ID);
        }

    
    }
}