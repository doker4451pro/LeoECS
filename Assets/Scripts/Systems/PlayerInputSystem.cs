using UnityEngine;
using Leopotam.Ecs;

namespace Ecs
{
    sealed class PlayerInputSystem : IEcsRunSystem
    {
        private readonly EcsFilter<PlayerTag, DirectionComponent> directionFilter = null;

        private float moveX;
        private float moveZ;

        public void Run()
        {
            SetDirection();

            foreach (int item in directionFilter)
            {
                //делаем всегда так ref var потому что работаем со структрами чтобы не происходила упаковка и распаковка
                ref var directionComponent = ref directionFilter.Get2(item);
                ref var direction = ref directionComponent.Direction;

                direction.x = moveX;
                direction.z = moveZ;
            }
            
        }

        private void SetDirection() 
        {
            moveX = Input.GetAxis("Horizontal");
            moveZ = Input.GetAxis("Vertical");
        }
    }
}
