using Leopotam.Ecs;
using UnityEngine;

namespace Client 
{
    sealed class GameplayStartup : MonoBehaviour 
    {
        private EcsWorld _world;
        private EcsSystems _systems;

        void Start() 
        {
            // void can be switched to IEnumerator for support coroutines.
            
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
            #if UNITY_EDITOR
                        Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
                        Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
            #endif
            _systems
                .Init();
        }

        void Update()
        {
            _systems?.Run();
        }

        void OnDestroy()
        {
            if (_systems != null) 
            {
                _systems.Destroy();
                _systems = null;
                _world.Destroy();
                _world = null;
            }
        }
    }
}