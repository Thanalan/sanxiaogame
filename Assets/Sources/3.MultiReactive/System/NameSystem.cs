using Entitas;
using System.Collections;
using System.Collections.Generic;
using MultiReactive;
using UnityEngine;

public class NameSystem : ReactiveSystem<GameEntity> {

    public NameSystem(IContext<GameEntity> context) : base(context)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        throw new System.NotImplementedException();
    }

    protected override bool Filter(GameEntity entity)
    {
        throw new System.NotImplementedException();
    }

    protected override void Execute(List<GameEntity> entities)
    {
    }
}
