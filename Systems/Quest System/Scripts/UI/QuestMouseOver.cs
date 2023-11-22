using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DreamersInc.Quests
{
    public class QuestMouseOver : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
    {
        private GameObject window;
        public void OnPointerEnter(PointerEventData eventData)
        {
            window = new GameObject();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
         Destroy(window);
        }
    }
}
