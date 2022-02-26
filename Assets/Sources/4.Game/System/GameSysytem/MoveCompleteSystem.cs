using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// 运动完成的响应系统
    /// </summary>
    public class MoveCompleteSystem : ReactiveSystem<GameEntity>
    {

        public MoveCompleteSystem(Contexts context) : base(context.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GameMoveComplete);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.isGameMoveComplete;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                entity.ReplaceGameFall(FallState.STEADY);
                entity.isGameGetSameColor = true;
                entity.isGameMoveComplete = false;
            }
        }
    }

}

