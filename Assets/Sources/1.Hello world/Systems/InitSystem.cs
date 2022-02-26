using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace HelloWorld
{
    /// <summary>
    /// 初始化系统
    /// </summary>
    public class InitSystem : IInitializeSystem
    {

        private readonly GameContext _gameContext;

        public InitSystem(Contexts contexts)
        {
            _gameContext = contexts.game;
        }

        public void Initialize()
        {
            _gameContext.CreateEntity().AddHelloWorldLog("Hello World");
        }
    }
}

