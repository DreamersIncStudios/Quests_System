using System.Collections;
using System.Collections.Generic;
using System.Linq;
//using DreamersInc.BestiarySystem;
using UnityEngine;
//using Utilities;

namespace DreamersInc.Quests
{
    public class DefeatEnemy : Mission,IDefeatEnemy
    {

        public Vector3 Location => location;
        [SerializeField] private Vector3 location;
        public List<EnemySpawnInfo> Enemies => enemies;       
        [SerializeField] private List<EnemySpawnInfo> enemies;
        public override void ActivateMission()
        {
            foreach (var enemy in Enemies.Where(enemy => !enemy.UseStandardSpawn))
            {
                for (var i = 0; i < enemy.NumberOfEnemyToSpawn; i++)
                {
                 //   if (GlobalFunctions.RandomPoint(location, 75.0f, out Vector3 pos))
                 //   {
                       // BestiaryDB.SpawnNPC(enemy.EnemyID,pos, out _, out _);
                   // }
                }
            }
        }

        public override void DeactivateMission()
        {
            throw new System.NotImplementedException();
        }

        public override void CompleteMission()
        {
            Debug.Log($"Get player singleton and Character Inventory and Give player {RewardExp} EXP and {RewardGold}G");
        }

    }
}
