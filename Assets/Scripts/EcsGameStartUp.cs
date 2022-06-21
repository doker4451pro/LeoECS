using Leopotam.Ecs;
using UnityEngine;
using Voody.UniLeo;
using Leopotam.Ecs.UnityIntegration;


namespace Ecs {
    public sealed class EcsGameStartUp : MonoBehaviour
    {
        private EcsWorld world;
        private EcsSystems systems;

        private void Start()
        {
            world = new EcsWorld();


#if UNITY_EDITOR
            EcsWorldObserver.Create(world);
#endif
            systems = new EcsSystems(world);

            systems.ConvertScene();
            AddInject();
            AddOnFrame();
            AddSystems();

            systems.Init();

#if UNITY_EDITOR
            EcsSystemsObserver.Create(systems);
#endif
        }

        private void AddInject()
        {

        }

        private void AddSystems()
        {
            systems.Add(new PlayerInputSystem())
                .Add(new MovementSystem());
        }

        private void AddOnFrame()
        {

        }

        private void Update()
        {
            systems?.Run();
        }

        private void OnDestroy()
        {
            systems?.Destroy();
            systems = null;
            world?.Destroy();
            world = null;
        }

    }
}
