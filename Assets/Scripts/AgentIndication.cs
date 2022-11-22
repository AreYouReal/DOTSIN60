using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

namespace DOTSIN60
{
    public class AgentIndication : MonoBehaviour{

        private Entity TargetEntity;
        
        private void LateUpdate(){
            if (Input.GetKeyDown(KeyCode.Space)){
                TargetEntity = GetRandomEntity();
            }

            if (TargetEntity != Entity.Null){

                LocalToWorld LTW = Unity.Entities.World.DefaultGameObjectInjectionWorld.EntityManager.GetComponentData<LocalToWorld>(
                    TargetEntity);

                transform.position = LTW.Position;
            }
        }

        private Entity GetRandomEntity(){
            EntityQuery EQ = Unity.Entities.World.DefaultGameObjectInjectionWorld.EntityManager.CreateEntityQuery(typeof(WorldAgentTag));
            NativeArray<Entity> ChooseFrom = EQ.ToEntityArray(Allocator.Temp);
            if (ChooseFrom.Length > 0){
                return(ChooseFrom[UnityEngine.Random.Range(0, ChooseFrom.Length)]);
            }else{
                return (Entity.Null);
            }
        }


    }
}
