using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace DreamersInc.Quests
{
    public interface IDefeatEnemy 
    {
        public Vector3 Location { get; }
        public List<EnemySpawnInfo> Enemies{get;}
        
    }

    [Serializable]
    public struct EnemySpawnInfo
    {
        public uint EnemyID;
        public bool UseStandardSpawn;
        public uint NumberOfEnemyToSpawn;
        public uint CountDefeated;

        public bool Complete => NumberOfEnemyToSpawn <= CountDefeated;
    }
}
