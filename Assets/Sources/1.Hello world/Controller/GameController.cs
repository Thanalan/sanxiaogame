using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace HelloWorld
{
    public class GameController : MonoBehaviour
    {
        private Systems _systems;
        // Use this for initialization
        void Start()
        {
            var context = Contexts.sharedInstance;
            _systems = new Feature("Systems").Add(new AddGameSystems(context));
            _systems.Initialize();
        }

        // Update is called once per frame
        void Update()
        {
            _systems.Execute();
            _systems.Cleanup();
        }
    }
}

