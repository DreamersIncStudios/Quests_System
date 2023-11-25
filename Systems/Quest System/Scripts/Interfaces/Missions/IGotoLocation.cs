using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DreamersInc.Quests
{
    public interface IGotoLocation 
    {
        public Vector3 Size { get; }
        public Vector3 Location { get; }
    }
}
