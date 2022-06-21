using UnityEngine;
using Leopotam.Ecs;

namespace Ecs
{
    sealed class MovementSystem : IEcsRunSystem
    {
        //обязательно с маленькой и подчеркивания и обязательно =null
        private readonly EcsWorld _world = null;
        private readonly EcsFilter<ModelComponent,MovableComponent,DirectionComponent> movableFilter = null;
        public void Run()
        {
            foreach (var item in movableFilter)
            {
                ref var modelComponent = ref movableFilter.Get1(item);
                ref var movableComponent = ref movableFilter.Get2(item);
                ref var directionComponent = ref movableFilter.Get3(item);

                ref var direction = ref directionComponent.Direction;
                ref var transform = ref modelComponent.ModelTransform;

                ref var characterController = ref movableComponent.CharacterController;
                ref var speed = ref movableComponent.Speed;

                var rawDirection = (transform.right * direction.x) + (transform.forward * direction.z);

                characterController.Move(rawDirection * speed * Time.deltaTime);

            }
        }
    }
}
