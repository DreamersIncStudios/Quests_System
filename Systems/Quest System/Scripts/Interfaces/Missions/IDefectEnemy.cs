using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DreamersInc.Quests
{
    public interface IDefectEnemy 
    {
        public Vector3 Location { get; }
        public List<uint> EnemyID{get;}
        
    }
}
