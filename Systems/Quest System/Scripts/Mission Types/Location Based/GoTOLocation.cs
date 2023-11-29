using UnityEngine;

namespace DreamersInc.Quests
{
    public class GoToLocation:Mission,IGotoLocation
    {
        public Vector3 Size => size;
        public Vector3 Location => location;
        [SerializeField] private Vector3 size;
        [SerializeField] private Vector3 location;
        private GameObject go;

        public override void ActivateMission()
        {
            go = new GameObject();
            var box = go.AddComponent<BoxCollider>();
            box.size =size;
            go.transform.position = location;
            go.AddComponent<LocationInteract>().Setup(ID, InteractionType.CompleteOnEnter);
        }

        public override void DeactivateMission()
        {
            Destroy(go); 
        }
    }
}