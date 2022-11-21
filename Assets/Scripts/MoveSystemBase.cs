using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace DOTSIN60{
    public partial class MoveSystemBase : SystemBase{
        
        protected override void OnUpdate(){
            foreach (var Entry in SystemAPI.Query<TransformAspect, Speed>()){
                Entry.Item1.Position += new float3(Entry.Item2.Value * SystemAPI.Time.DeltaTime, 0, 0);
            }
        }
        
    }
}