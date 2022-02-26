using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// 消除响应系统
    /// </summary>
    public class EliminationSystem : ReactiveSystem<GameEntity>
    {
        public EliminationSystem(Contexts context) : base(context.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.GameEliminate);
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasGameEliminate && entity.gameEliminate.canEliinate;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            List<IEntity> sameEntities = GetSameEntities(entities);

            GameEntity temp;
            foreach (IEntity entity in sameEntities)
            {
                temp = entity as GameEntity;
                if (temp != null) temp.isGameDestroy = true;
            }

        }

        private List<IEntity> GetSameEntities(List<GameEntity> entities)
        {
            List<IEntity> sameEntities = new List<IEntity>();
            foreach (GameEntity entity in entities)
            {
                if (!entity.isGameJudgeFormation)
                {
                    sameEntities.Add(entity);
                }
                else
                {
                    entity.isGameJudgeFormation = false;
                }

                int left = entity.gameDetectionSameItem._leftEntities.Count;
                int right = entity.gameDetectionSameItem._rightEntities.Count;
                int up = entity.gameDetectionSameItem._upEntities.Count;
                int down = entity.gameDetectionSameItem._downEntities.Count;

                if (left + right >= 2)
                {
                    sameEntities.AddRange(entity.gameDetectionSameItem._leftEntities);
                    sameEntities.AddRange(entity.gameDetectionSameItem._rightEntities);
                }

                if (up + down >= 2)
                {
                    sameEntities.AddRange(entity.gameDetectionSameItem._upEntities);
                    sameEntities.AddRange(entity.gameDetectionSameItem._downEntities);
                }
            }

            return sameEntities;
        }
    }
}

