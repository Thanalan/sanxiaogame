using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Game
{
    public class GameController : MonoBehaviour
    {
        private Systems _systems;

        private void Awake()
        {
            var contexts = Contexts.sharedInstance;
            _systems = GetSystems(contexts);
            new Services(contexts, transform);
            Models.Instance.Init();
        }

        private void Start()
        {
            _systems.Initialize();
        }

        private void Update()
        {
            _systems.Execute();
            _systems.Cleanup();
        }

        private Systems GetSystems(Contexts contexts)
        {
            return new GameFeature(contexts)
                .Add(new GameEventSystems(contexts))
                .Add(new InputFeature(contexts));
        }
    }

}

