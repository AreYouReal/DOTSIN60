using Unity.Entities;
using UnityEngine;

namespace DOTSIN60{
    public class WorldAuthoring : MonoBehaviour{
        public GameObject AgentPrefab;
    }

    public class WorldBaker : Baker<WorldAuthoring>{
        public override void Bake(WorldAuthoring authoring){
            AddComponent(new World{
                AgentEntityPrefab = GetEntity(authoring.AgentPrefab)
            });
        }
    }
}