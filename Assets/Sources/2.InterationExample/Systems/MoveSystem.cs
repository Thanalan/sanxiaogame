using Entitas;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;


namespace InterationExample
{
    /// <summary>
    /// 移动系统
    /// </summary>
    public class MoveSystem : ReactiveSystem<GameEntity>
    {
        public MoveSystem(Contexts context) : base(context.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.InterationExampleMoveConponent);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasInterationExampleMoveConponent
                   && entity.isInterationExampleMoveComplete
                   && entity.hasInterationExampleView;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                entity.interationExampleView.viewTrans.DOMove(entity.interationExampleMoveConponent.targetPos, 3);
            }
        }
    }
}
