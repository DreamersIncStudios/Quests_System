using System.Collections.Generic;
using DreamersInc.Quests.Editor;
using UnityEngine;

namespace DreamersInc.Quests.Bounties
{
    public class DefeatEnemies: Bounty,IDefeatEnemy
    {
        public Vector3 Location => location;
        [SerializeField] private Vector3 location;
        public List<EnemySpawnInfo> Enemies => enemies;       
        [SerializeField] private List<EnemySpawnInfo> enemies;
        public override void AcceptBounty()
        {
        
        }

        public override void CancelBounty()
        {
            throw new System.NotImplementedException();
        }
    }
}