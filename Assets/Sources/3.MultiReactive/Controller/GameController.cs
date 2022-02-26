using System;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace MultiReactive
{
    public class GameController : MonoBehaviour,ICleanupSystem
    {
        private Systems _systems;

        public void Cleanup()
        {
            throw new NotImplementedException();
        }

        // Use this for initialization
        void Start()
        {
            _systems = new Feature("Systems").Add(new MultiFeature(Contexts.sharedInstance));
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
