using UnityEngine;

namespace DreamersInc.Quests
{
    public class ScanLocation : Mission, IGotoLocation
    {


        public Vector3 Size => size;
        public Vector3 Location => location;
        [SerializeField] private Vector3 size;
        [SerializeField] private Vector3 location;
        private GameObject go;
        public override void ActivateMission()
        {
            if(HasIntroCutscene)
                Intro.PlayCutscene();
            go = new GameObject();
            var box = go.AddComponent<BoxCollider>();
            box.size =size;
            go.transform.position = location;
            go.AddComponent<LocationInteract>().Setup(ID, InteractionType.CompleteOnInteract);
            
        }

        public override void DeactivateMission()
        {
            if(HasOutroCutscene)
                Outro.PlayCutscene();

            Destroy(go); 
        }


    }
}
