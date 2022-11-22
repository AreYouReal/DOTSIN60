using Unity.Burst;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Jobs;

namespace DOTSIN60{

    [BurstCompile]
    public partial struct MoveISystem : ISystem{
        
        [BurstCompile]
        public void OnCreate(ref SystemState state){ }

        [BurstCompile]
        public void OnDestroy(ref SystemState state){ }
        
        [BurstCompile]
        public void OnUpdate(ref SystemState state){
            float DeltaTime = SystemAPI.Time.DeltaTime;
            JobHandle MoveJH = new MoveJob{ DeltaTime = DeltaTime }.ScheduleParallel(state.Dependency);
            MoveJH.Complete();
            RefRW<MyRandom> Rnd = SystemAPI.GetSingletonRW<MyRandom>();
            
            new CheckJob{ MyRandom = Rnd }.Run();
        }
    }

    [BurstCompile]
    public partial struct MoveJob : IJobEntity{

        public float DeltaTime;
        private void Execute(MoveToPositionAspect InMoveAspect){
            InMoveAspect.Move(DeltaTime);
        }
    }

    [BurstCompile]
    public partial struct CheckJob : IJobEntity{
        
        [NativeDisableUnsafePtrRestriction]
        public RefRW<MyRandom> MyRandom;

        private void Execute(MoveToPositionAspect InMoveAspect){
            InMoveAspect.TestPosReachAndGenerateNewPos(MyRandom);
        }
    }
}