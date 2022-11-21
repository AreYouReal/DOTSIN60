using Unity.Entities;
using UnityEngine;

namespace DOTSIN60{
    public class SpeedAuthoring : MonoBehaviour{
        public float Value;
    }

    public class SpeedBaker : Baker<SpeedAuthoring>{
        
        public override void Bake(SpeedAuthoring authoring){
            AddComponent(new Speed{
                Value = authoring.Value
            });
        }
        
    }
}