using Unity.Entities;

namespace DOTSIN60{
    public partial class SpawnAgentSystem : SystemBase{
        
        protected override void OnUpdate(){

            EntityQuery EQuery = EntityManager.CreateEntityQuery(typeof(WorldAgentTag));

            if (EQuery.CalculateEntityCount() < 20){

                EntityCommandBuffer ECB = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>().CreateCommandBuffer(World.Unmanaged);
                
                RefRW<MyRandom> Rnd = SystemAPI.GetSingletonRW<MyRandom>();
                
                World W = SystemAPI.GetSingleton<World>();

                Entity NewEntity = ECB.Instantiate(W.AgentEntityPrefab);
                
                ECB.SetComponent(NewEntity, new Speed{Value = Rnd.ValueRW.Rnd.NextFloat(1, 5f) });
                
            }

        }
        
    }
}