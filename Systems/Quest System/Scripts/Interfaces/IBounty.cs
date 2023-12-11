using System.Collections;
using System.Collections.Generic;
using DreamersInc.Quests.Editor;
using UnityEngine;

namespace DreamersInc.Quests
{
    public interface IBounty
    {
        string Name { get; }
        uint ID { get; }

        Sprite Icon { get; }
        string Description { get; }
        uint RewardEXP { get; }
        uint RewardGold { get; }
        bool MissionBounty { get; }
        uint MissionID { get; }

        void AcceptBounty();
        void CancelBounty();
        void CompleteBounty();
    }

    public abstract class Bounty : ScriptableObject, IBounty
    {
        public string Name { get; }
        public uint ID => id;
        [SerializeField] private uint id;

        public Sprite Icon { get; }
        public string Description { get; }
        public bool MissionBounty { get; }
        public uint MissionID { get; }
        public uint RewardEXP { get; }
        public uint RewardGold { get; }

        public virtual void AcceptBounty()
        {
            if (MissionBounty)
                QuestManagerC.MissionBounties.Add(Instantiate(this));
            else
            {
                for (var i = 0; i < QuestManagerC.Bounties.Length; i++)
                {
                    if (QuestManagerC.Bounties[i] == null)
                        QuestManagerC.Bounties[i] = Instantiate(this);
                }
            }
        }

        public virtual void CancelBounty()
        {
            if (MissionBounty)
                QuestManagerC.MissionBounties.Remove(this);
            else
            {
                for (var i = 0; i < QuestManagerC.Bounties.Length; i++)
                {
                    if (QuestManagerC.Bounties[i] == this)
                        QuestManagerC.Bounties[i] = null;
                }
            }
        }

        public virtual void CompleteBounty()
        {
            if (!MissionBounty)
            {
                if (QuestManagerC.CompleteActiveBounty(ID))
                    Debug.Log(
                        $"Get player singleton and Character Inventory and Give player {RewardEXP} EXP and {RewardGold}G");
            }
            else
            {

                foreach (var mission in QuestManagerC.ActiveMissions)
                {
                    if (mission.ID != MissionID) return;
                    var temp = (MultiStageMission)mission;
                    temp.CompleteStage();
                }
            }
        }
        public void SetBountyID(uint count)
        {
            id = count;
        }
    }
}
