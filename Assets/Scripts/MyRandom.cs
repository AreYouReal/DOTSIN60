using Unity.Entities;

namespace DOTSIN60{
    public struct MyRandom : IComponentData{
        public Unity.Mathematics.Random Rnd;
    }
}