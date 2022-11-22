using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace DOTSIN60{
    public readonly partial struct MoveToPositionAspect : IAspect{

        #region Fields
        private readonly Entity E;
        
        private readonly TransformAspect MyTransform;
        private readonly RefRO<Speed> MySpeed;
        private readonly RefRW<TargetPosition> MyTargetPos;
        #endregion

        #region Public
        public void Move(float InDeltaTime){
            float3 MoveDirection = math.normalize(MyTargetPos.ValueRO.Value - MyTransform.Position);
            MyTransform.Position += MoveDirection * MySpeed.ValueRO.Value * InDeltaTime;
        }

        public void TestPosReachAndGenerateNewPos(RefRW<MyRandom> InMyRandom){
            if (math.distance(MyTransform.Position, MyTargetPos.ValueRO.Value) < 0.5f){
                MyTargetPos.ValueRW.Value = GetNewRandomPos(InMyRandom);
            }
        }
        #endregion

        #region Helpers
        private float3 GetNewRandomPos( RefRW<MyRandom> Rnd){
            return (new float3(
                Rnd.ValueRW.Rnd.NextFloat(-5, 5),
                0.0f,
                Rnd.ValueRW.Rnd.NextFloat(-5, 5)
            ));

        }
        #endregion

    }
}