using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DreamersInc.Quests
{
    public interface IBounty 
    {
        string Name { get; }
        Sprite Icon { get; }
        string Description { get; }
        uint RewardEXP { get; }
        uint RewardGold { get; }

        void AcceptBounty();
        void CancelBounty();
        void CompleteBounty();
    }
}
