using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace DOTSIN60{
    public class MyRandomAuthoring : MonoBehaviour{ }

    public class MyRandomBaker : Baker<MyRandomAuthoring>{
        public override void Bake(MyRandomAuthoring authoring){
            AddComponent(new MyRandom{
                Rnd = new Unity.Mathematics.Random(1)
            });
        }
    }
}