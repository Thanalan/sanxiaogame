using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace HelloWorld
{
    ///// <summary>
    /// 打印消息系统
    /// </summary>
    public class LogSystem : ReactiveSystem<GameEntity>
    {
        public LogSystem(Contexts contexts) : base(contexts.game)
        {

        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasHelloWorldLog;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.HelloWorldLog);
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                Debug.Log(entity.helloWorldLog.message);
            }
        }
    }
}

