using Unity.Entities;
using UnityEngine;
using UnityEngine.UIElements;

namespace DOTSIN60{
    public class TargetPositionAuthoring : MonoBehaviour{
        public Vector3 Position;
    }

    public class TargetPositionBaker : Baker<TargetPositionAuthoring>{

        public override void Bake(TargetPositionAuthoring authoring){
            AddComponent(new TargetPosition{
                Value = authoring.Position
            });
        }
    }
}