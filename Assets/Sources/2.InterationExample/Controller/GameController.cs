using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace InterationExample
{
    public class GameController : MonoBehaviour
    {
        private Systems _systems;
        private Contexts _contexts;

        // Use this for initialization
        void Start()
        {
            _contexts = Contexts.sharedInstance;
            _systems = Creatsystems(_contexts);
        }

        // Update is called once per frame
        void Update()
        {
            _systems.Execute();
            _systems.Cleanup();
        }

        private Systems Creatsystems(Contexts contexts)
        {
            return new Feature("System")
                .Add(new GameFeature(contexts))
                .Add(new InputFeature(contexts));
        }
    }
}
