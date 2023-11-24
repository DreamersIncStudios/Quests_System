using System.Collections;
using System.Collections.Generic;
using DreamersInc.Quests.Editor;
using UnityEngine;
using UnityEngine.UI;

namespace DreamersInc.Quests
{
    public class QuestModalWindow : MonoBehaviour
    {
        [SerializeField] private Transform QuestContentArea;
        [SerializeField] private Transform BountyContentArea;
        [SerializeField] private GameObject QuestPanel;
        private void DisplayActiveBounties()
        {
            var bountyImages = BountyContentArea.transform.GetComponentsInChildren<Image>();
            for (var i = 0; i < QuestManagerC.Bounties.Length; i++)
            {
                bountyImages[i].sprite = QuestManagerC.Bounties[i]?.Icon;
            }
        }

        private void DisplayActiveQuest()
        {
            foreach (var quest in QuestManagerC.ActiveQuests)
            {
                Instantiate(QuestPanel, QuestContentArea);
            }
            foreach (var quest in QuestManagerC.ActiveMissions)
            {
                Instantiate(QuestPanel, QuestContentArea);
            }
        }
    }
}
