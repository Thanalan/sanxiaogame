using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterationExample
{
    /// <summary>
    /// 位置变化系统
    /// </summary>
    public class PositionSystem : ReactiveSystem<GameEntity>
    {
        public PositionSystem(Contexts context) : base(context.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.InterationExamplePosition);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasInterationExamplePosition && entity.hasInterationExampleView;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                entity.interationExampleView.viewTrans.position = entity.interationExamplePosition.postion;
            }
        }
    }
}
