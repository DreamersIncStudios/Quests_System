using System.Collections;
using System.Collections.Generic;
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
            for (var i = 0; i < QuestManager.Bounties.Length; i++)
            {
                bountyImages[i].sprite = QuestManager.Bounties[i]?.Icon;
            }
        }

        private void DisplayActiveQuest()
        {
            foreach (var quest in QuestManager.ActiveQuests)
            {
                Instantiate(QuestPanel, QuestContentArea);
            }
            foreach (var quest in QuestManager.ActiveMissions)
            {
                Instantiate(QuestPanel, QuestContentArea);
            }
        }
    }
}
