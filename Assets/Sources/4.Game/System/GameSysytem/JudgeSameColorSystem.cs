
using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// 判断是否满足消除条件
    /// </summary>
    public class JudgeSameColorSystem : ReactiveSystem<GameEntity>
    {
        public JudgeSameColorSystem(Contexts context) : base(context.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GameDetectionSameItem);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasGameDetectionSameItem;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (GameEntity entity in entities)
            {
                if (IsMeetCondition(entity))
                {
                    entity.isGameJudgeFormation = true;
                }
                else
                {
                    entity.ReplaceGameEliminate(false);
                }
            }
        }

        private bool IsMeetCondition(GameEntity entity)
        {
            int left = entity.gameDetectionSameItem._leftEntities.Count;
            int right = entity.gameDetectionSameItem._rightEntities.Count;
            int up = entity.gameDetectionSameItem._upEntities.Count;
            int down = entity.gameDetectionSameItem._downEntities.Count;

            return left + right >= 2
                   || up + down >= 2;
        }
    }

}

