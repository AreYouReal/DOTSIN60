using Unity.Entities;
using UnityEngine;

namespace DOTSIN60{
    public class WorldAgentAuthoring : MonoBehaviour{
        
    }

    public class WorldAgentBaker : Baker<WorldAgentAuthoring>{
        public override void Bake(WorldAgentAuthoring authoring){
            AddComponent<WorldAgentTag>();
        }
    }
}